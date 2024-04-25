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
        CartRepository cartRepository;
        CartItemsRepository cartItemsRepository;

        public ShoppingServices()
        {
            cartRepository = new CartRepository();
            cartItemsRepository = new CartItemsRepository();
        }

        public bool AlreadyInCart(CartItem cartItem,Cart cart)
        {
            foreach( var cartitem in cart.CartItems )
            {
                if( cartitem.Id == cartItem.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool AddToCart(int cartId,CartItem cartitem,int productid)
        {
            Cart cart=cartRepository.GetByKey(cartId);

            if (!AlreadyInCart(cartitem, cart))
            {

            }

            throw new ItemAlreadyInCart();
        }


    }
}
