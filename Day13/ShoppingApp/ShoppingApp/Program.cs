using ModelLibrary;
using ShoppingBLLibrary;

namespace ShoppingApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            /*IRepository<int, Customer> customerRepo = new CustomerRepository();
            customerRepo.Add(new Customer(1, "Ramu", 33));
            customerRepo.Add(new Customer(1, "Ramu", 36));
            customerRepo.Add(new Customer(2, "Somu", 31));
            customerRepo.Add(new Customer(3, "Komu", 27));
            var customers = customerRepo.GetAll().ToList();
            customers=customers.OrderBy(cust=>cust.Name).ThenBy(cust=>cust.Age).ToList();
            foreach (var item in customers)
            {
                Console.WriteLine(item.Id+" "+item.Name+" "+item.Age);
            }

            string a = "hello shrish";
            Console.WriteLine(StringMethods.Reverse(a));
            */

            //Generate a New Cart for Customer id=1
            int CustomerId = 1;

            ShoppingServices _shoppingServices = new ShoppingServices();
            Cart CustomerCart = await _shoppingServices.CreateCart(CustomerId);
            int CartId=CustomerCart.Id;
            Console.WriteLine("CartID: "+CartId);

            //Add CartItem to Cart of Customer 1
            //Product Not created yet
            /*CustomerCart=_shoppingServices.AddToCart(CartId, 1, 3);
            CustomerCart = _shoppingServices.AddToCart(CartId, 2, 4);
            foreach(var item in CustomerCart.CartItems)
            {
                Console.WriteLine(item.ProductId);
            }*/

            //Add Products
            var product=_shoppingServices.AddProductDraftAsync(1, 200, "Prod A", 5);
            product=_shoppingServices.AddProductDraftAsync(2, 500, "Prod B", 3);
            product=_shoppingServices.AddProductDraftAsync(3, 50, "Prod C", 5);
            product = _shoppingServices.AddProductDraftAsync(4, 100, "Prod D", 6);

            //Creating Cart And Testing
            await _shoppingServices.AddToCart(CartId, 3, 1);
                
            var CheckoutCart=await _shoppingServices.GetCartCheckoutDetailsAsync(CartId);

            Console.WriteLine("CartTotal: "+CheckoutCart.CartTotal);
            Console.WriteLine("Shipping Charges: " + CheckoutCart.ShippingCharge);
            Console.WriteLine("Total Amount: "+CheckoutCart.AmountToBePaid);





            

            
            
        }
    }
    public static class StringMethods
    {
        public static string Reverse(string msg)
        {
            char[] chars = msg.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}
