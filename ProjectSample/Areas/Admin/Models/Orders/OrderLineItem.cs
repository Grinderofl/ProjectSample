namespace ProjectSample.Areas.Admin.Models.Orders
{
    public class OrderLineItem
    {
        public long Id { get; set; }
        public decimal Total { get; set; }
        public string CurrentStateName { get; set; }
    }
}