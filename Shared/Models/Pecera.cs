using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MurkyShop.Shared.Models
{
    public class Pecera
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Dimensiones { get; set; }
        public float Precio { get; set; }
        public string ImageURL { get; set; }
        public int Qty { get; set; }
        public int CategoryId { get; set; }
    }
}
