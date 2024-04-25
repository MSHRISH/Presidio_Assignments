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
        public int GenerateCartId()
        {
            var carts=cartRepository.GetAll();
            if(carts.Count == 0)
            {
                return 1;
            }
            return carts.Last().Id+1;
        }

        public bool CheckCartAlreadyExist(int customerid)
        {
            foreach(var item in cartRepository.GetAll())
            {
                if (item.CustomerId == customerid)
                {
                    return true;
                } 
            }
            return false;
        }
        public Cart CreateCart(int CustomerId)
        {
            if (CheckCartAlreadyExist(CustomerId))
            {
                throw new CartAlreadyExistExecption();
            }
            Cart cart = new Cart(GenerateCartId(), CustomerId);
            cartRepository.Add(cart);
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
        public bool CheckStockOfCartItem(int productid,int quantity)
        {
            Product ProductDetails=productRepository.GetByKey(productid);
            if (ProductDetails.QuantityInHand < quantity)
            {
                return false;
            }
            return true;
        }
        public Cart AddToCart(int cartId,int productid,int quantity)
        {
            Cart cart = cartRepository.GetByKey(cartId);
            if(cart == null )
            {
                throw new NoCartWithGivenIdExecption();
            }
            if (CartLimit(cart))
            {
                throw new CartLimitReachedExecption();
            }
            if (!CheckStockOfCartItem(productid, quantity))
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
        public Cart GetCart(int cartId)
        {
            return cartRepository.GetByKey(cartId); 
        }

        public double CartTotal(Cart cart)
        {
            double Total = 0;
            foreach( var item in cart.CartItems)
            {
                Product ProductDetails=productRepository.GetByKey(item.ProductId);
                double ItemPrice =ProductDetails.Price*item.Quantity;
                Total += ItemPrice;
            }
            return Total;
        }
        public bool CheckStock(Cart cart)
        {
            foreach( var item in cart.CartItems)
            {
                Product product=productRepository.GetByKey(item.ProductId);
                if (product.QuantityInHand < item.Quantity)
                {
                    return false;
                }
            }
            return true;
        }
        public Cart GetCartCheckoutDetails(int CartId)
        {
            Cart cart = cartRepository.GetByKey(CartId);
            if (cart == null)
            {
                throw new NoCartWithGivenIdExecption();
            }
            if (!CheckStock(cart))
            {
                throw new NoStockExecption();
            }
            cart.CartTotal = CartTotal(cart);
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

        public Product AddProductDraft(int id,double price,string name,int quantityinhand)
        {
            Product product = new Product(id,price,name,quantityinhand);
            productRepository.Add(product);
            return product;
        }


    }
}
