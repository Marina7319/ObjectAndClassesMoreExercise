using System;
using System.Collections.Generic;
using System.Linq;
namespace _1.CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allPeople = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<Person> personsList = new List<Person>();
            for (int i = 0; i < allPeople.Length; i++)
            {
                string[] person = allPeople[i].Split("=");
                var persons = new Person(person[0], int.Parse(person[1]));
                persons.Items = new List<string>();
                personsList.Add(persons);
            }
            string[] allProducts = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<Product> productsList = new List<Product>();
            for (int i = 0; i < allProducts.Length; i++)
            {
                string[] product = allProducts[i].Split("=");
                var products = new Product(product[0], int.Parse(product[1]));
                productsList.Add(products);
            }
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] order = input.Split(" ");
                string tokens = order[0];
                var itemName = order[1];
                foreach (Person personList in personsList)
                {
                    if (tokens == personList.Name)
                    {
                        foreach (Product productList in productsList)
                        {
                            if (order[1] == productList.Item)
                            {
                                if (productList.Cost <= personList.Money)
                                {
                                    personList.Money = personList.Money - productList.Cost;
                                    Console.WriteLine($"{personList.Name} bought {productList.Item}");
                                    var currItem = personsList.Find(match: personList => personList.Name == tokens);
                                    currItem.Items.Add(itemName);
                                }
                                else
                                {
                                    Console.WriteLine($"{personList.Name} can't afford {productList.Item}");
                                }
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }
            int itemCount = 0;
            foreach (Person personList in personsList)
            {
                Console.Write(personList.Name + " - ");
                foreach (var item in personList.Items)
                {
                    itemCount++;
                }
                if (itemCount < 1)
                {
                    Console.Write("Nothing bought");
                }
                itemCount = 0;
                Console.Write(string.Join(", ", personList.Items));
                Console.WriteLine();
            }
        }
    }
    class Person
    {
        public Person(string name, int money)
        {
            Name = name;
            Money = money;
        }
        public string Name { get; set; }
        public int Money { get; set; }
        public List<string> Items { get; set; }
    }
    class Product
    {
        public Product(string item, int cost)
        {
            Item = item;
            Cost = cost;
        }
        public string Item { get; set; }
        public int Cost { get; set; }
    }
}
