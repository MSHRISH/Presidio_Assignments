using System.Runtime.Serialization;

namespace PizzaApi.Execptions
{
    [Serializable]
    internal class PizzaDoesNotExist : Exception
    {
        public PizzaDoesNotExist()
        {
        }

        public PizzaDoesNotExist(string? message) : base(message)
        {
        }

        public PizzaDoesNotExist(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PizzaDoesNotExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}