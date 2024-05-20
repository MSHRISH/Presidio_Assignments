using System.Runtime.Serialization;

namespace PizzaApi.Execptions
{
    [Serializable]
    internal class UserDoesNotExist : Exception
    {
        string message;
        public UserDoesNotExist()
        {
            message = "User Doesn't Exist";
        }

        public override string Message => message;


    }
}