using Common.DTOs.Response;
using Common.Models;
using Data.Entities;
using Data.Repositories.interfaces;
using Service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTOs.Request;

namespace Service
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;
        // etc... (repositorios de Payment, etc. si los necesitas)

        public SaleService(ISaleRepository saleRepository,
                           IProductRepository productRepository)
        {
            _saleRepository = saleRepository;
            _productRepository = productRepository;
            // ...
        }

        public SaleResponseDto CreateSale(CreateSaleDto dto)
        {
            // 1) Mapear CreateSaleDto -> Entidad Sale
            var saleEntity = new Sale
            {
                Date = dto.Date,
                Total = dto.Total,
                SaleDetails = dto.SaleDetails.Select(d => new SaleDetail
                {
                    ProductId = d.ProductId,
                    Quantity = d.Quantity,
                    Subtotal = d.Subtotal
                }).ToList(),
                Payments = dto.Payments.Select(p => new Payment
                {
                    PaymentMethod = p.PaymentMethod,
                    Amount = p.Amount
                }).ToList()
            };

            // 2) Validar stock y descontar
            foreach (var detail in saleEntity.SaleDetails)
            {
                // Buscar el producto
                var product = _productRepository.GetById(detail.ProductId);
                if (product == null)
                {
                    throw new Exception($"El producto con ID {detail.ProductId} no existe.");
                }

                // Revisar si hay stock suficiente
                if (product.Stock < detail.Quantity)
                {
                    throw new Exception($"No hay stock suficiente para '{product.Name}'. " +
                                        $"Solicitado: {detail.Quantity}, Disponible: {product.Stock}");
                }

                // Descontar stock
                product.Stock -= detail.Quantity;

                // Actualizar el producto en la BD
                _productRepository.Update(product);
            }

            // 3) Guardar la venta
            _saleRepository.Add(saleEntity);

            // 4) Mapear a SaleResponseDto para retornar
            var response = new SaleResponseDto
            {
                Id = saleEntity.Id,
                Date = saleEntity.Date,
                Total = saleEntity.Total,
                SaleDetails = saleEntity.SaleDetails.Select(sd => new SaleDetailResponseDto
                {
                    Id = sd.Id,
                    ProductId = sd.ProductId,
                    Quantity = sd.Quantity,
                    Subtotal = sd.Subtotal
                }).ToList(),
                Payments = saleEntity.Payments.Select(pay => new PaymentResponseDto
                {
                    Id = pay.Id,
                    PaymentMethod = pay.PaymentMethod,
                    Amount = pay.Amount
                }).ToList()
            };

            return response;
        }


        public List<SaleResponseDto> GetAllSales()
        {
            // 1) Obtener las ventas de la base
            var sales = _saleRepository.GetAll();
            // Asumo que hace un Include(s => s.SaleDetails).Include(s => s.Payments)

            // 2) Mapear a DTO
            var result = sales.Select(sale => new SaleResponseDto
            {
                Id = sale.Id,
                Date = sale.Date,
                Total = sale.Total,
                SaleDetails = sale.SaleDetails.Select(sd => new SaleDetailResponseDto
                {
                    Id = sd.Id,
                    ProductId = sd.ProductId,
                    // ProductName = sd.Product?.Name (opcional, si incluiste Product)
                    Quantity = sd.Quantity,
                    Subtotal = sd.Subtotal
                }).ToList(),
                Payments = sale.Payments.Select(p => new PaymentResponseDto
                {
                    Id = p.Id,
                    PaymentMethod = p.PaymentMethod,
                    Amount = p.Amount
                }).ToList()
            }).ToList();

            return result;
        }

        public SaleResponseDto GetSaleById(int id)
        {
            var sale = _saleRepository.GetById(id);
            if (sale == null) return null;

            var dto = new SaleResponseDto
            {
                Id = sale.Id,
                Date = sale.Date,
                Total = sale.Total,
                SaleDetails = sale.SaleDetails?.Select(sd => new SaleDetailResponseDto
                {
                    Id = sd.Id,
                    ProductId = sd.ProductId,
                    Quantity = sd.Quantity,
                    Subtotal = sd.Subtotal
                }).ToList(),
                Payments = sale.Payments?.Select(p => new PaymentResponseDto
                {
                    Id = p.Id,
                    PaymentMethod = p.PaymentMethod,
                    Amount = p.Amount
                }).ToList()
            };

            return dto;
        }

        public bool DeleteSale(int id)
        {
            // Llamas al repo
            return _saleRepository.Delete(id);
            // o si tu repo solo borra, retornas true/false si existía
        }
    }
}
