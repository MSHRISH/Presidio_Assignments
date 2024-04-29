using ModelLibrary;
using ShoppingDALLibrary;

namespace ShoppingRepositoryTests
{
    public class Tests
    {
        CustomerRepository customerRepository;
        [SetUp]
        public void Setup()
        {
            customerRepository = new CustomerRepository();
        }

        [Test]
        public void AddCustomerTest()
        {
            //Arrange
            Customer customer = new Customer(100,"123456780",24);
            
            //Action
            var result=customerRepository.Add(customer);

            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public async Task GetAllCustomerTest()
        {
            //Arrange
            Customer customer = new Customer(100, "123456780", 24);
            var result = await customerRepository.Add(customer);
            customer = new Customer(101, "123456780", 24);
            result = await customerRepository.Add(customer);

            //Action
            var res=await customerRepository.GetAll();

            //Assert
            Assert.AreEqual(2,res.Count());
        }

        [Test]
        public async Task GetCustomerTest()
        {
            //Arrange
            Customer customer = new Customer(100, "123456780", 24);
            var result = customerRepository.Add(customer);
            customer = new Customer(101, "123456780", 24);
            result = customerRepository.Add(customer);

            //Action
            var res = await customerRepository.GetByKey(100);

            //Assert
            Assert.AreEqual(100, res.Id);
        }

        [Test]
        public async Task DeleteCustomerTest()
        {
            //Arrange
            Customer customer = new Customer(100, "123456780", 24);
            var result = customerRepository.Add(customer);
            customer = new Customer(101, "123456780", 24);
            result = customerRepository.Add(customer);

            //Action
            result = customerRepository.Delete(100);
            var res= await customerRepository.GetAll();

            //Assert
            Assert.AreEqual(res.Count(), 1);
        }

        [Test]
        public async Task UpdateCustomerTest()
        {
            //Arrange
            Customer customer = new Customer(100, "123456780", 24);
            var result = customerRepository.Add(customer);
            customer = new Customer(101, "123456780", 24);
            result = customerRepository.Add(customer);
            customer = new Customer(101, "123231231231", 30);
            //Action
            result=customerRepository.Update(customer);
            var res = await customerRepository.GetByKey(101);

            //Assert
            Assert.AreEqual(res.Age,30);
        }

        
    }
}