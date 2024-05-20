using System.Runtime.Serialization;

namespace PizzaApi.Execptions
{
    [Serializable]
    internal class UnableToRegister : Exception
    {
        string message;
        public UnableToRegister()
        {
            message = "Unable to Register at this moement.Try again Later.";

        }
        public override string Message => message;


    }
}