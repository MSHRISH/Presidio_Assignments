using System.ComponentModel.DataAnnotations;

namespace PizzaApi.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public int StockAvailable { get; set; }
    }
}
