using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suppliers.DataModel
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public string Unit { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
