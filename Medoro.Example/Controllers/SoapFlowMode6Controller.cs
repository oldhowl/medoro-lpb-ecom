using System;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Medoro.Example.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Medoro.Example.Controllers
{
    [Route("soap")]
    public class SoapFlowMode6Controller : ControllerBase
    {
        [HttpGet]
        public async Task Payment(
            [FromServices] IMedoroEcomService ecomService,
            [FromServices] IMemoryCache memoryCache)
        {
            var orderId = Guid.NewGuid().ToString();


            var paymentResponse = await ecomService.PaymentMode6(
                true,
                "test",
                orderId,
                100,
                "EUR",
                "Test order",
                "Ivan Ivanov",
                "Lenina 1",
                "Tomsk",
                "RU",
                "123456",
                "+79123456789",
                "random-email@test.ru",
                "Notification test",
                CardFactory.ChallengeFlow()
            );

            var hash = Convert.ToBase64String(
                MD5.Create()
                    .ComputeHash(
                        Encoding.UTF8.GetBytes(orderId + "secret")));
            
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
                Data = await ecomService.AuthorizeSoapPayment(paymentId, paRes)
            });
        }
    }
}