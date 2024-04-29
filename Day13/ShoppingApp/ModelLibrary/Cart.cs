using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class Cart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
       // public Customer Customer { get; set; }//Navigation property

        public List<CartItem> CartItems { get; set; }//Navigation property. } }

        public double CartTotal {  get; set; }
        public double DiscountPercentage {  get; set; }

        public double AmountToBePaid {  get; set; }
        public double ShippingCharge {  get; set; }

        public Cart(int id,int customerid) 
        { 
            CustomerId = customerid;
            Id = id;
            CartItems = new List<CartItem>();
            ShippingCharge = 0;
        }
    }
}
