using Ecommerce.Payment.Application.Payment;
using Ecommerce.Payment.Application.Payment.Dto;
using Ecommerce.Payment.CrossCutting.Exception;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace Ecommerce.Payment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private readonly ILogger _logger;
        private readonly IPaymentService _paymentService;

        public PaymentController(ILogger<PaymentController> logger, IPaymentService PaymentService)
        {
            _logger = logger;
            _paymentService = PaymentService;
        }
        #region Web API Methods
        [HttpGet("GetPaymentById")]

        public async Task<IActionResult> GetPaymentById(int PaymentId)
        {
            var result = await _paymentService.GetPayment(PaymentId);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("GetAllPayments")]
        public async Task<IActionResult> GetAllPayments([FromQuery] string responseContentType = "application/x-protobuf")
        {
            var result = await _paymentService.GetAllPayments();
            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [HttpPost("SavePayment")]
        public async Task<IActionResult> SavePayment(int orderSessionId, double amount)
        {
            var result = await _paymentService.SavePayment(orderSessionId, amount);

            if (result == null)
                return NotFound();

            return Created($"/{result.Id}", result);
        }
        //[HttpPost("SavePayment")]
        //public async Task<IActionResult> SavePayment([FromBody] PaymentDto PaymentDto)
        //{
        //    var result = await _paymentService.SavePayment(PaymentDto);

        //    if (result == null)
        //        return NotFound();

        //    return Created($"/{result.Id}", result);
        //}
        [HttpDelete("DeletePayment")]
        public async Task<IActionResult> DeltePayment(int PaymentId)
        {
            var result = await _paymentService.DeletePayment(PaymentId);
            if (!result)
                return NotFound();

            return Ok(result);
        }
        #endregion


    }
}
