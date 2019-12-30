namespace effectively.tests.iInterfaceIndirection
{
    using effectively.InterfaceIndirection;
    using NUnit.Framework;

    [TestFixture]
    public class The_invoice_service
    {

        [TestFixture]
        public class when_getting_an_invoice
        {

            //the invoice number is the invoice Id as an int
            [Test]
            public void the_invoice_number_is_the_invoice_id_as_an_int()
            {
                InvoiceService service = new InvoiceService(new MockHttpCurrentResponse());
                Assert.AreEqual(5, service.GetInvoice(5).Id);
            }

            //Given an invoice prefix (cookie)
            //the invoice number is the prefix + invoice Id
            [Test]
            public void the_invoice_number_is_the_prefix_plus_invoice_id()
            {
                InvoiceService service = new InvoiceService(new MockHttpCurrentResponse());
                service.SetPrefix(3);
                Assert.AreEqual(8, service.GetInvoice(5).Id);
            }

        }
    }

    internal class MockHttpCurrentResponse : IHttpCurrentResponse
    {
        int prefixCookie = 0;

        public int GetPrefixCookie()
        {
            return prefixCookie;
        }

        public void SetPrefixCookie(int prefix)
        {
            prefixCookie = prefix;
        }

        public void SetStatusCode(int statusCode)
        {
        // NOTE: Do nothing with the status code for now
        }
    }
}
