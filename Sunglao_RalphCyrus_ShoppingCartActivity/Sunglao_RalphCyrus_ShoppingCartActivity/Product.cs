using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Cart_Activity_Sunglao
{
    internal class Product
    {
            public int Id;
            public string Name;
            public double Price;
            public int RemainingStock;

            public Product(int id, string name, double price, int stock)
            {
                Id = id;
                Name = name;
                Price = price;
                RemainingStock = stock;
            }

        public void DisplayProduct()
        {
            Console.WriteLine($"{Id,-5} {Name,-15} PHP {Price,-10} {RemainingStock,-5}");
        }

        public double GetItemTotal(int quantity)
            {
                return Price * quantity;
            }

            public bool HasEnoughStock(int quantity)
            {
                return quantity <= RemainingStock;
            }

            public void DeductStock(int quantity)
            {
                RemainingStock -= quantity;
            }
        }

    }

