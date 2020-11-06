using ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree.Core
{
    public class Engine
    {
        private readonly ICollection<Person> people;
        private readonly ICollection<Product> products;

        public Engine()
        {
            this.people = new List<Person>();
            this.products = new List<Product>();
        }

        public void Run()
        {

            try
            {
                this.ParsePeopleInput();
                this.ParseProductInput();

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] cmdArg = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string personName = cmdArg[0];
                    string productName = cmdArg[1];
                    Person person = this.people.FirstOrDefault(p => p.Name == personName);
                    Product product = this.products.FirstOrDefault(p => p.Name == productName);

                    if (person != null && product != null)
                    {
                        string result = person.BuyProduct(product);
                        Console.WriteLine(result);
                    }
                }

                foreach (Person person in this.people)
                {
                    Console.WriteLine(person);
                }

            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }
        }


        private void ParsePeopleInput()
        {
            string[] peopleArg = Console.ReadLine().Split(';',StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (string personStr in peopleArg)
            {
                string[] personArg = personStr.Split('=').ToArray();


                string personName = personArg[0];
                decimal personMoney = decimal.Parse(personArg[1]);

                Person person = new Person(personName, personMoney);

                this.people.Add(person);
            }

        }

        private void ParseProductInput()
        {
            string[] productsArg = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (string productStr in productsArg)
            {
                string[] productArg = productStr.Split('=').ToArray();


                string productName = productArg[0];
                decimal productCost = decimal.Parse(productArg[1]);

                Product product = new Product(productName, productCost);

                this.products.Add(product);
            }
        }
    }
}

