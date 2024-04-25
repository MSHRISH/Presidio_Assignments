using ModelLibrary;
using ModelLibrary.Execeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartRepository : AbstractRepository<int, Cart>
    {
        public override Cart Delete(int key)
        {
            Cart cart= GetByKey(key);
            if (cart != null)
            {
                items.Remove(cart);
            }
            return cart;
        }

        public override Cart GetByKey(int key)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == key)
                    return items[i];
            }
            throw new NoCartWithGivenIdExecption();
        }

        public override Cart Update(Cart item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == item.Id)
                {
                    items[i] = item;
                    return items[i];
                }
            }
            throw new NoCartWithGivenIdExecption();
        }
    }
}
