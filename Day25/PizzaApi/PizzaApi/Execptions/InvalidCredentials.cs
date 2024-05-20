using System.Runtime.Serialization;

namespace PizzaApi.Execptions
{
    [Serializable]
    internal class InvalidCredentials : Exception
    {
        string message;
        public InvalidCredentials()
        {
            message = "Invalid Password or Username";
        }

        public override string Message => message;

    }
}