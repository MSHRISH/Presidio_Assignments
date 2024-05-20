using System.Runtime.Serialization;

namespace PizzaApi.Execptions
{
    [Serializable]
    internal class NoStockAvailable : Exception
    {
        string message;
        public NoStockAvailable()
        {
            message = "No Stock Available Right Now Check Again After Sometime.Thank You!";
        }

        public override string Message => message;


    }
}