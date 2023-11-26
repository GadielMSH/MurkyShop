using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MurkyShop.Shared.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartID {  get; set; }
        public int ProductID {  get; set; }
        public int Qty { get; set; }
    }
}
