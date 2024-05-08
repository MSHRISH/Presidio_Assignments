using SampleEFApp2.Model;

namespace SampleEFApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            pubsContext context= new pubsContext();
            var titles= context.Titles.ToList();
            foreach ( var title in titles )
            {
                Console.WriteLine(title.Title1);
            }
        }
    }
}
