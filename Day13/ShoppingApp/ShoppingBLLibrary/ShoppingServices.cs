using ModelLibrary;
using ModelLibrary.Execeptions;
using ShoppingDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class ShoppingServices
    {
        AbstractRepository<int,Cart> cartRepository;
        AbstractRepository<int,Product> productRepository;
        //CartItemsRepository cartItemsRepository;

        public ShoppingServices()
        {
            cartRepository = new CartRepository();
            productRepository = new ProductRepository();
            //cartItemsRepository = new CartItemsRepository();
        }
        public ShoppingServices(AbstractRepository<int,Cart> cartrepo,AbstractRepository<int,Product> productrepo)
        {
            cartRepository = cartrepo;
            productRepository = productrepo;
        }
        public async Task<int> GenerateCartIdAsync()
        {
            var carts=await cartRepository.GetAll();
            if(carts.Count == 0)
            {
                return 1;
            }
            return carts.Last().Id+1;
        }

        public async Task<bool> CheckCartAlreadyExistAsync(int customerid)
        {
            List<Cart> carts = await cartRepository.GetAll();
            int CartCount=carts.Count;
            for (int i = 0; i < CartCount; i++)
            {
                Cart? item = carts[i];
                if (item.CustomerId == customerid)
                {
                    return true;
                } 
            }
            return false;
        }
        public async Task<Cart> CreateCart(int CustomerId)
        {
            bool CartChecking = await CheckCartAlreadyExistAsync(CustomerId);
            if (CartChecking)
            {
                throw new CartAlreadyExistExecption();
            }

            Cart cart = new Cart(await GenerateCartIdAsync(), CustomerId);
            await cartRepository.Add(cart);
            return cart;
        }
        public bool AlreadyInCart(CartItem cartItem,Cart cart)
        {
            foreach( var item in cart.CartItems )
            {
                if( item.ProductId== cartItem.ProductId)
                {
                    return true;
                }
            }
            return false;
        }
        public async Task<bool> CheckStockOfCartItemAsync(int productid,int quantity)
        {
            Product ProductDetails=await productRepository.GetByKey(productid);
            if (ProductDetails.QuantityInHand < quantity)
            {
                return false;
            }
            return true;
        }
        public async Task<Cart> AddToCart(int cartId,int productid,int quantity)
        {
            Cart cart = await cartRepository.GetByKey(cartId);
            if(cart == null )
            {
                throw new NoCartWithGivenIdExecption();
            }
            if (CartLimit(cart))
            {
                throw new CartLimitReachedExecption();
            }
            if (!await CheckStockOfCartItemAsync(productid, quantity))
            {
                throw new NoStockExecption();
            }
            CartItem cartitem=new CartItem(cartId, productid, quantity);
            if (!AlreadyInCart(cartitem, cart))
            {
                cart.CartItems.Add(cartitem);
                var UpdatedCart=cartRepository.Update(cart);
                return cart;
            }

            throw new ItemAlreadyInCart();
        }
        public bool CartLimit(Cart cart)
        {
            if (cart.CartItems.Count == 5)
            {
                return true;
            }
            return false;
        }
        public async Task<Cart> GetCartAsync(int cartId)
        {
            return await cartRepository.GetByKey(cartId); 
        }

        public async Task<double> CartTotalAsync(Cart cart)
        {
            double Total = 0;
            foreach( var item in cart.CartItems)
            {
                Product ProductDetails=await productRepository.GetByKey(item.ProductId);
                double ItemPrice =ProductDetails.Price*item.Quantity;
                Total += ItemPrice;
            }
            return Total;
        }
        public async Task<bool> CheckStockAsync(Cart cart)
        {
            foreach( var item in cart.CartItems)
            {
                Product product=await productRepository.GetByKey(item.ProductId);
                if (product.QuantityInHand < item.Quantity)
                {
                    return false;
                }
            }
            return true;
        }
        public async Task<Cart> GetCartCheckoutDetailsAsync(int CartId)
        {
            Cart cart = await cartRepository.GetByKey(CartId);
            if (cart == null)
            {
                throw new NoCartWithGivenIdExecption();
            }
            if (!await CheckStockAsync(cart))
            {
                throw new NoStockExecption();
            }
            cart.CartTotal = await CartTotalAsync(cart);
            cart.AmountToBePaid = cart.CartTotal;

            if(cart.CartItems.Count ==3 && cart.CartTotal >= 1500)
            {
                cart.DiscountPercentage = 5;
                cart.AmountToBePaid = cart.CartTotal-(cart.CartTotal*0.05);
            }

            if (cart.CartTotal < 100)
            {
                cart.ShippingCharge = 100;
                cart.AmountToBePaid += 100;
            }
            return cart;
        }

        public async Task<Product> AddProductDraftAsync(int id,double price,string name,int quantityinhand)
        {
            Product product = new Product(id,price,name,quantityinhand);
            await productRepository.Add(product);
            return product;
        }


    }
}
