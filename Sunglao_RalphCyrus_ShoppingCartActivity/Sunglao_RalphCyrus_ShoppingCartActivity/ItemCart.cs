using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Cart_Activity_Sunglao
{
    internal class ItemCart
    {
        public Product Product;
        public int Quantity;
        public double Subtotal;

        public ItemCart(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Subtotal = product.GetItemTotal(quantity);
        }

        public void Update(int quantity)
        {
            Quantity += quantity;
            Subtotal = Product.GetItemTotal(Quantity);
        }
    }
}
