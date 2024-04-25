using ModelLibrary;
using ModelLibrary.Execeptions;
using ShoppingBLLibrary;
using ShoppingDALLibrary;

namespace ShoppingBusinessLogicTesting
{
    public class Tests
    {
        CartRepository cartRepository;
        ProductRepository productRepository;
        ShoppingServices shoppingServices;
        [SetUp]
        public void Setup()
        {
            cartRepository = new CartRepository();
            productRepository = new ProductRepository();
            shoppingServices = new ShoppingServices(cartRepository,productRepository);
            var product = shoppingServices.AddProductDraft(1, 200, "Prod A", 5);
            product = shoppingServices.AddProductDraft(2, 500, "Prod B", 3);
            product = shoppingServices.AddProductDraft(3, 50, "Prod C", 5);
            product = shoppingServices.AddProductDraft(4, 100, "Prod D", 6);
            product = shoppingServices.AddProductDraft(5, 100, "Prod E", 6);
            product = shoppingServices.AddProductDraft(6, 100, "Prod F", 6);
        }

        [Test]
        public void AddingToCart()
        {
            //Arrange
            int CustomerId = 1;
            Cart CustomerCart = shoppingServices.CreateCart(CustomerId);
            int CartId = CustomerCart.Id;
            //Action
            CustomerCart = shoppingServices.AddToCart(CartId, 1, 3);
            //Assert
            Assert.AreEqual(1,CustomerCart.CartItems.Count);
        }

        [Test]
        public void CheckOutTestCase1()
        {
            //Arrange
            int CustomerId = 1;
            Cart CustomerCart = shoppingServices.CreateCart(CustomerId);
            int CartId = CustomerCart.Id;

            //Action
            CustomerCart = shoppingServices.AddToCart(CartId, 3, 1);
            var CheckoutCart = shoppingServices.GetCartCheckoutDetails(CartId);

            //Assert
            Assert.AreEqual(100, CheckoutCart.ShippingCharge);
        }
        [Test]

        public void CheckOutTestCase2()
        {
            //Arrange
            int CustomerId = 1;
            Cart CustomerCart = shoppingServices.CreateCart(CustomerId);
            int CartId = CustomerCart.Id;

            //Action
            CustomerCart=shoppingServices.AddToCart(CartId,2,3);
            CustomerCart= shoppingServices.AddToCart(CartId,1,5);
            CustomerCart= shoppingServices.AddToCart(CartId, 4, 3);
            var CheckoutCart = shoppingServices.GetCartCheckoutDetails(CartId);

            //Assert
            Assert.AreEqual(5, CheckoutCart.DiscountPercentage);

        }

        [Test]
        public void ChecckOutTestCase3()
        {
            //Arrange
            int CustomerId = 1;
            Cart CustomerCart = shoppingServices.CreateCart(CustomerId);
            int CartId = CustomerCart.Id;

            //Action
            CustomerCart = shoppingServices.AddToCart(CartId, 1, 1);
            CustomerCart = shoppingServices.AddToCart(CartId, 2, 1);
            CustomerCart = shoppingServices.AddToCart(CartId, 3, 1);
            CustomerCart = shoppingServices.AddToCart(CartId, 4, 1);
            CustomerCart = shoppingServices.AddToCart(CartId, 5, 1);
            

            //Assert
            Assert.Throws<CartLimitReachedExecption>(() => shoppingServices.AddToCart(CartId, 6, 1));
        }
    }
}