using System.ComponentModel.DataAnnotations;

namespace Suppliers.App.Models
{
    public class ProductVM
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
