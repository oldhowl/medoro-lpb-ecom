using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Medoro.Example.Extensions
{
    /// <summary>
    /// https://gist.github.com/priore/7163408
    /// </summary>
    public static class WebExtensions
    {
        public static async Task RedirectWithData(this HttpResponse response, NameValueCollection data, string url)
        {
            response.Clear();

            var s = new StringBuilder();
            s.Append("<html>");
            s.AppendFormat("<body onload='document.forms[\"form\"].submit()'>");
            s.AppendFormat("<form name='form' action='{0}' method='post'>", url);
            foreach (string key in data)
            {
                s.AppendFormat("<input type='hidden' name='{0}' value='{1}' />", key, data[key]);
            }

            s.Append("</form></body></html>");
            await response.WriteAsync(s.ToString());
        }
    }
}