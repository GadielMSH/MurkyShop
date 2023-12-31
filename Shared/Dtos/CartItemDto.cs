﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MurkyShop.Shared.Dtos
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public int CartId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImageURL { get; set; }
        public float Price { get; set; }
        public float TotalPrice { get; set; }
        public int Qty { get; set; }
    }
}
