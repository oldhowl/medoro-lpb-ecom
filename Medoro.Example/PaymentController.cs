using System;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Medoro.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Medoro.Example
{
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpGet("/")]
        public async Task Payment(
            [FromServices] IMedoroEcomService ecomService,
            [FromServices] IMemoryCache memoryCache)
        {
            var orderId = Guid.NewGuid().ToString();


            var paymentResponse = await ecomService.PaymentMode6(
                false,
                "test",
                orderId,
                100,
                "EUR",
                "Test order",
                CardFactory.ChallengeFlow(),
                "Ivan Ivanov",
                "Lenina 1",
                "Tomsk",
                "RU",
                "123456",
                "+79123456789",
                "random-email@test.ru",
                "Notification test"
            );

            var hash = GetHash(orderId);
            memoryCache.Set(hash, paymentResponse.Payment.ID);

            var threeDsDataCollection = new NameValueCollection();

            threeDsDataCollection.Add("PaReq", paymentResponse.D3D.ACS.PaReq);
            threeDsDataCollection.Add("TermUrl", Request.Scheme + "://" + Request.Host + "/callback");
            threeDsDataCollection.Add("MD", hash);

            await Response.RedirectWithData(threeDsDataCollection, paymentResponse.D3D.ACS.URL);
        }

        [HttpPost("callback")]
        public async Task<IActionResult> Callback(
            [FromServices] IMemoryCache memoryCache,
            [FromServices] IMedoroEcomService ecomService,
            [FromForm] string md,
            [FromForm] string paRes)
        {
            var paymentId = memoryCache.Get<string>(md);
            return Ok(new
            {
                Result = "Success payment!",
                Data = await ecomService.AuthorizePayment(paymentId, paRes)
            });
        }

        private string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input + "secret"));

            return Convert.ToBase64String(hash);
        }
    }
}