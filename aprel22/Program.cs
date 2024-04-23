using aprel22.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Channels;

namespace aprel22
{
    internal class Program
    {
        private static List<string> names = new List<string>();

        static void Main(string[] args)
        {
            Category category = new Category { Name = "mobile" };
            Product product = new Product { Id = 1, Name = "ıphone 15", Price = 2000m, Category = category };
            Product product2 = new Product { Id = 2, Name = "samsung s23", Price = 2400m, Category = category };
            Product product3 = new Product { Id = 3, Name = "xiaomi poco 5x", Price = 1000m, Category = category };
            List<Product> products = new List<Product> { product, product2, product3 };



            Add("iPhone 15");
            Add("Samsung S23");
            Add("Xiaomi Poco 5x");

            Console.WriteLine(Search("iPhone")); 
            Delete("Samsung S23");

            List<string> allNames = Deserialize();
            foreach (string name in allNames)
            {
                Console.WriteLine(name);
            }



            //string json = JsonConvert.SerializeObject(products);

            //using (StreamWriter sw = new StreamWriter(@"C:\Users\Hp\Desktop\aprel22\aprel22\names.json"))
            //{
            //    sw.Write(json);
            //}

            // string result;
            // using(StreamReader sr=new StreamReader(@"C:\Users\Hp\Desktop\aprel22\aprel22\names.json"))
            // {
            //    result= sr.ReadToEnd();
            // }
            // Console.WriteLine(result);


            //List<Product> objects= JsonConvert.DeserializeObject<List<Product>>(result);
            // foreach (Product product in objects)
            // {
            //     Console.WriteLine(product.Name);
            // }





        }

        public static void Add(string name)
        {
            List<string> names = Deserialize();
            names.Add(name);
            Serialize(names);
            Console.WriteLine(@"{name} add edildi");
        }
        public static bool Search(string search)
        {
            List<string> names = Deserialize();
            return names.Any(s=> search.Contains(s));
        }
        public static void Delete(string name)
        {
            List<string> names = Deserialize();
            if (names.Contains(name))
            {
                names.Remove(name);
                Console.WriteLine(@"{name} silindi");
                Serialize(names);
            }
            
        }
        public static void Serialize(List<string> names)
        {
            string result=JsonConvert.SerializeObject(names);
            using(StreamWriter sw = new StreamWriter(@"C:\Users\Hp\Desktop\aprel22\aprel22\names.json"))
            {
                Console.WriteLine(result);
            }
        }
        public static List<string> Deserialize()
        {
            string result;
            using (StreamReader sr = new StreamReader(@"C:\Users\Hp\Desktop\aprel22\aprel22\names.json"))
            {
                result = sr.ReadToEnd();    
            }
            return JsonConvert.DeserializeObject<List<string>>(result);
        }
        public static void ShowAllNames()
        {
            Console.WriteLine("names:");
            List<string> names = Deserialize();
            names.ForEach (a => Console.WriteLine(a)) ;
            
        }




    }
}
