using System;


namespace Shopping.Models.View_Models
{
    public class OrderProductViewModel
    {

        //public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        //public DateTime InvoiceDate { get; set; }
        public DateTime DeliveredDate { get; set; }

    }
}
