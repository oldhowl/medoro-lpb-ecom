using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Medoro.Example.Extensions;
using Medoro.Example.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medoro.Example.Controllers
{
    [Route("form")]
    public class FormFlowMode5Controller : ControllerBase
    {
        [HttpGet]
        public async Task Mode5(
            [FromServices] IMedoroEcomService ecomService)
        {
            var orderId = Guid.NewGuid().ToString();


            var paymentResponse = await ecomService.PaymentMode5(
                true,
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

            var threeDsDataCollection = new NameValueCollection
            {
                {"KEY", paymentResponse.Key},
                {"KEY_INDEX", paymentResponse.KeyIndex},
                {"DATA", paymentResponse.Data},
                {"INTERFACE", paymentResponse.Interface},
                {"SIGNATURE", paymentResponse.Signature},
                {"CALLBACK", $"{Request.Scheme}://{Request.Host}{Url.Action("FormCallback")}"},
                {"ERROR_CALLBACK", $"{Request.Scheme}://{Request.Host}{Url.Action("ErrorFormCallback")}"}
            };


            await Response.RedirectWithData(threeDsDataCollection, "https://demo.ipsp.lv/form/v2/");
        }

        [HttpPost("callback")]
        public IActionResult FormCallback(
            [FromServices] IMedoroEcomService ecomService,
            [FromForm] MedoroFormCallbackData obj)
        {
            return Ok(new
            {
                Result = "Success!",
                Data = ecomService.AuthorizeFormPayment(obj.Data, obj.Key)
            });
        }

        [HttpPost("errorCallback")]
        public IActionResult ErrorFormCallback([FromForm] MedoroFormCallbackData obj)
        {
            return Ok(new {Result = "Payment failed", Data = obj});
        }
    }
}