﻿namespace Northwind.Demo.Entity.Models
{
    public partial class CustomerCustomerDemo
    {
        public string CustomerId { get; set; } = null!;
        public string CustomerTypeId { get; set; } = null!;
        public virtual Customer Customers { get; set; } = null!;
        public virtual CustomerDemographic CustomerTypes { get; set; } = null!;

    }
}
