using ModelLibrary;
using ModelLibrary.Execeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartItemsRepository : AbstractRepository<int, CartItem>
    {
        public override CartItem Delete(int key)
        {
            throw new NotImplementedException();
        }

        public override CartItem GetByKey(int key)
        {
           
            throw new NoCartItemWithGivenIdExeception(); 
        }

        public override CartItem Update(CartItem item)
        {
            throw new NotImplementedException();
        }
    }
}
