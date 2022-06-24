using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IspProject.Models;
using IspProject.DTOs.Payment;
using IspProject.Services.Payment;
using System.Security.Claims;

namespace IspProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly AccountDbContext _context;
        private readonly IPaymentService _paymentService;

        public PaymentController(AccountDbContext context, IPaymentService paymentService)
        {
            _context = context;
            _paymentService = paymentService;
        }

        // GET: api/Payment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> Getpayments()
        {
          if (_context.payments == null)
          {
              return NotFound();
          }
            return await _context.payments.ToListAsync();
        }

        // GET: api/Payment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
          if (_context.payments == null)
          {
              return NotFound();
          }
            var payment = await _context.payments.FindAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // PUT: api/Payment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, Payment payment)
        {
            if (id != payment.idPayment)
            {
                return BadRequest();
            }

            _context.Entry(payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Payment>> CreatePotentialClient(CreatePaymentRequest request)
        {
            var user = HttpContext.User;
            var nameIdentifier = int.Parse(user.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var response = await _paymentService.CreatePayment(request, nameIdentifier);
            return CreatedAtAction(nameof(CreatePotentialClient), response);
        }

        // DELETE: api/Payment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            if (_context.payments == null)
            {
                return NotFound();
            }
            var payment = await _context.payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            _context.payments.Remove(payment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentExists(int id)
        {
            return (_context.payments?.Any(e => e.idPayment == id)).GetValueOrDefault();
        }
    }
}
