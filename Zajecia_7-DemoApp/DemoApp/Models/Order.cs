using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.SqlServer.Server;

namespace DemoApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ICollection<Food> OrderItems { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}