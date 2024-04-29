using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary;
using ModelLibrary.Execeptions;

namespace ShoppingDALLibrary
{
    public class CustomerRepository : AbstractRepository<int, Customer>
    {
        public override async Task<Customer> Delete(int key)
        {
            Customer customer = await GetByKey(key);
            if (customer != null)
            {
                items.Remove(customer);
            }
            return customer;
        }

        public override async Task<Customer> GetByKey(int key)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == key)
                    return items[i];
            }
            throw new NoCustomerWithGiveIdException();
        }

        public override async Task<Customer> Update(Customer item)
        {
           for(int i = 0;i < items.Count;i++) 
           {
                if (items[i].Id == item.Id)
                {
                    items[i] = item;
                    return items[i];
                }
           }
            throw new NoCustomerWithGiveIdException();
        }

    }
}
