using effectively.InterfaceIndirection;
using System.Net;
using System.Web;

namespace effectively.InterfaceIndirection
{
    public class InvoiceService
    {
        IHttpCurrentResponse HttpCurrentResponse;

        // NOTE: Tackled using "Adapt Parameter" method as described at 28:30 in https://web.microsoftstream.com/video/69ee4fc7-b3b8-4e41-ab59-9fe90841a4cf
        public InvoiceService(IHttpCurrentResponse httpCurrentResponse = null)
        {
            if (httpCurrentResponse == null)
                HttpCurrentResponse = new HttpContextCurrentResponse();

            HttpCurrentResponse = httpCurrentResponse;
        }

        public void SetPrefix(int prefix)
        {
            HttpCurrentResponse.SetPrefixCookie(prefix);
        }

        public InvoiceDto GetInvoice(int id)
        {
            // arg! how can I test that this happened?
            HttpCurrentResponse.SetStatusCode((int)HttpStatusCode.OK);

            return new InvoiceDto { Id = id + HttpCurrentResponse.GetPrefixCookie() };
        }

    }

    public interface IHttpCurrentResponse
    {
        void SetStatusCode(int statusCode);
        int GetPrefixCookie();
        void SetPrefixCookie(int prefix);
    }

    public class HttpContextCurrentResponse : IHttpCurrentResponse
    {
        public void SetStatusCode(int statusCode)
        {
            HttpContext.Current.Response.StatusCode = statusCode;
        }

        public int GetPrefixCookie()
        {
            int prefix = 0;
            var cookie = HttpContext.Current.Request.Cookies.Get("prefixCookie");

            if (cookie != null)
            {
                int.TryParse(cookie.Value, out prefix);
            }
            return prefix;
        }

        public void SetPrefixCookie(int prefix)
        {
            HttpCookie cookie = new HttpCookie("prefixCookie", prefix.ToString());

            HttpContext.Current.Request.Cookies.Set(cookie);
        }
    }
}
