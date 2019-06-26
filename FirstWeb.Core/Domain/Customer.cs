using FirstWeb.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace FirstWeb.Core
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(30)]
        public string Name { get; set; }
        public CustomerState State { get; set; }
    }
}