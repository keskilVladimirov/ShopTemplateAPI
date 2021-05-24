﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShopTemplateAPI.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Reports = new HashSet<Report>();
        }

        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int? Discount { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int InStorage { get; set; }

        [JsonIgnore]
        public DateTime CreatedDate { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [JsonIgnore]
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<ProductProperty> ProductProperties { get; set; }
        [JsonIgnore]
        public virtual ICollection<ProductPropertyValue> ProductPropertyValues { get; set; }

        [NotMapped]
        public string CategoryName { get => Category?.CategoryName; }
    }
}
