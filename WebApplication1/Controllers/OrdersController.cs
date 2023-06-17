using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IDbService _dbService;
        public OrdersController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersData(string? clientLastName = null)
        {
            var orders = await _dbService.GetOrdersData(clientLastName);

            //Przemapuj obiekt zamówień na DTO
            return Ok(orders.Select(e => new OrderDTO
            {
                ID = e.ID,
                AcceptedAt = e.AcceptedAt,
                FulfilledAt = e.FulfilledAt,
                Comments = e.Comments,
                Pastries = e.OrderPastries.Select(p => new PastryDTO
                {
                    Name = p.Pastry.Name,
                    Price = p.Pastry.Price,
                    Amount = p.Amount
                }).ToList()
            }));
        }
    }
}