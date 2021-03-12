using Microsoft.AspNetCore.Mvc;
using Shopping.Models.View_Models;
using Shopping.Services.Interface;
using System;
using System.Threading.Tasks;


namespace Shopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductsController : ControllerBase
    {
        private readonly IOrderProductService _orderProductService;

        public OrderProductsController(IOrderProductService orderProductService)
        {
            _orderProductService = orderProductService;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _orderProductService.GetOrderDetails();
            return Ok(result);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _orderProductService.GetOrderDetail(id);
            if (result == null)
            {
                return NotFound("Order not Found");
            }
            return Ok(result);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderProductViewModel order)
        {
            var newOrder = await _orderProductService.PlaceOrder(order);
            return Ok();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _orderProductService.DeleteOrder(id);
            return Ok();
        }
    }
}
