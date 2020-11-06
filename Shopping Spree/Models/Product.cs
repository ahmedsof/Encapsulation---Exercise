using ShoppingSpree.Common;

using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree.Models
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException (GlobalConstans.EmptyNameConsMsg);
                }
                this.name = value;

            }
        }

        public decimal Cost
        {
            get
            {
                return this.cost;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstans.NegativeMoneMsg);
                }
                this.cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name;

        }
    }
}
