using System;
using System.Collections.Generic;

namespace Shopping_Cart_Activity_Sunglao
{
    internal class Program
    {
        static int receiptCounter = 1;
        static void Main()
        {
            Product[] products = new Product[]
            {
                new Product(1, "Milk", 50.00, 50, "Food"),
                new Product(2, "Eggs", 10.00, 1000, "Food"),
                new Product(3, "Meat (1 kg)", 250.00, 200, "Food"),
                new Product(4, "Bread (1 Loaf)", 75.00, 500, "Food"),
                new Product(5, "Turon", 25.00, 100, "Food"),
                new Product(6, "Siopao", 30.00, 100, "Food"),
                new Product(7, "SM Bonus Water (1L)", 30.00, 500, "Food"),
                new Product(8, "Fish (1 kg)", 150.00, 200, "Food"),
                new Product(9, "Mr. Chips", 30.00, 500, "Food"),
                new Product(10, "Cheetos", 90.00, 100, "Food"),
                new Product(11, "T-Shirt", 499.00, 400, "Clothing"),
                new Product(12, "iPhone 17 Pro Max", 110000.00, 50, "Electronics"),
                new Product(13, "TV", 10000.00, 100, "Electronics"),
            };

            List<ItemCart> cart = new List<ItemCart>();

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n====== MAIN MENU ======");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Manage Cart");
                Console.WriteLine("3. Search Product");
                Console.WriteLine("4. Filter by Category");
                Console.WriteLine("5. Checkout");
                Console.Write("Choose option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddItem(products, cart);
                        break;

                    case "2":
                        ManageCart(cart);
                        break;

                    case "3":
                        SearchProduct(products);
                        break;

                    case "4":
                        FilterByCategory(products, cart);
                        break;

                    case "5":
                        Checkout(cart, products);
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        // ================= ADD ITEM =================
        static void AddItem(Product[] products, List<ItemCart> cart)
        {
            Console.WriteLine("========WELCOME TO RALPH'S GROCERY STORE========");

            Console.WriteLine("\n===========================================");
            Console.WriteLine("               PRODUCT MENU               ");
            Console.WriteLine("===========================================");
            Console.WriteLine($"{"ID",-5} {"Product",-15} {"Price",-10} {"Stock",-5}");
            Console.WriteLine("-------------------------------------------");

            foreach (var p in products)
            {
                p.DisplayProduct();
            }

            Console.WriteLine("===========================================");

            Console.Write("Enter Product ID: ");
            if (!int.TryParse(Console.ReadLine(), out int productChoice) ||
                productChoice < 1 || productChoice > products.Length)
            {
                Console.WriteLine("Invalid product number.");
                return;
            }

            Product selectedProduct = products[productChoice - 1];

            if (selectedProduct.RemainingStock == 0)
            {
                Console.WriteLine("This product is out of stock.");
                return;
            }

            Console.Write("Enter Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            if (quantity > selectedProduct.RemainingStock)
            {
                Console.WriteLine("Not enough stock.");
                return;
            }

            selectedProduct.DeductStock(quantity);
            cart.Add(new ItemCart(selectedProduct, quantity));

            Console.WriteLine("Item added to cart!");
        }

        // ================= CART MENU =================
        static void ManageCart(List<ItemCart> cart)
        {
            bool managing = true;

            while (managing)
            {
                Console.WriteLine("\n====== CART MENU ======");
                Console.WriteLine("1. View Cart");
                Console.WriteLine("2. Remove Item");
                Console.WriteLine("3. Clear Cart");
                Console.WriteLine("4. Back");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewCart(cart);
                        break;

                    case "2":
                        RemoveItem(cart);
                        break;

                    case "3":
                        cart.Clear();
                        Console.WriteLine("Cart cleared.");
                        break;

                    case "4":
                        managing = false;
                        break;
                }
            }
        }

        // ================= VIEW CART =================
        static void ViewCart(List<ItemCart> cart)
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("Cart is empty.");
                return;
            }

            Console.WriteLine("\n--- CART ITEMS ---");
            for (int i = 0; i < cart.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cart[i].Product.Name} - Qty: {cart[i].Quantity}");
            }
        }

        // ================= REMOVE ITEM =================
        static void RemoveItem(List<ItemCart> cart)
        {
            ViewCart(cart);

            Console.Write("Enter item number: ");
            if (int.TryParse(Console.ReadLine(), out int index) &&
                index > 0 && index <= cart.Count)
            {
                cart[index - 1].Product.RemainingStock += cart[index - 1].Quantity;
                cart.RemoveAt(index - 1);

                Console.WriteLine("Item removed.");
            }
        }

        static void SearchProduct(Product[] products)
        {
            Console.Write("\nEnter product name to search: ");
            string search = Console.ReadLine().ToLower();

            bool found = false;

            Console.WriteLine("\nSearch Results:");
            Console.WriteLine("-------------------------------------------");

            foreach (var p in products)
            {
                if (p.Name.ToLower().Contains(search))
                {
                    Console.WriteLine($"\n{"ID",-5} {"Product",-15} {"Price",-10} {"Stock",-5}");
                    Console.WriteLine("-------------------------------------------");
                    p.DisplayProduct(
                    );
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No matching products found.");
            }
        }

        // ================= FILTER BY CATEGORY =================
        static void FilterByCategory(Product[] products, List<ItemCart> cart)
        {
            Console.WriteLine("\nSelect Category:");
            Console.WriteLine("1. Food");
            Console.WriteLine("2. Electronics");
            Console.WriteLine("3. Clothing");
            Console.Write("Choice: ");

            string choice = Console.ReadLine();
            string category = "";

            switch (choice)
            {
                case "1": category = "Food"; break;
                case "2": category = "Electronics"; break;
                case "3": category = "Clothing"; break;
                default:
                    Console.WriteLine("Invalid category.");
                    return;
            }

            Console.WriteLine("\n===========================================");
            Console.WriteLine($"           {category.ToUpper()} PRODUCTS           ");
            Console.WriteLine("===========================================");
            Console.WriteLine($"{"ID",-5} {"Product",-15} {"Price",-10} {"Stock",-5}");
            Console.WriteLine("-------------------------------------------");

            List<Product> filtered = new List<Product>();

            foreach (var p in products)
            {
                if (p.Category == category)
                {
                    p.DisplayProduct();
                    filtered.Add(p);
                }
            }

            if (filtered.Count == 0)
            {
                Console.WriteLine("No products found in this category.");
                return;
            }

            // ===== ADD ITEM AFTER FILTER =====
            Console.Write("\nEnter Product ID to add to cart (0 to cancel): ");

            if (!int.TryParse(Console.ReadLine(), out int id) || id == 0)
                return;

            Product selectedProduct = null;

            foreach (var p in filtered)
            {
                if (p.Id == id)
                {
                    selectedProduct = p;
                    break;
                }
            }

            if (selectedProduct == null)
            {
                Console.WriteLine("Invalid product selection.");
                return;
            }

            if (selectedProduct.RemainingStock == 0)
            {
                Console.WriteLine("This product is out of stock.");
                return;
            }

            Console.Write("Enter Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            if (qty > selectedProduct.RemainingStock)
            {
                Console.WriteLine("Not enough stock.");
                return;
            }

            selectedProduct.DeductStock(qty);
            cart.Add(new ItemCart(selectedProduct, qty));

            Console.WriteLine("Item added to cart!");
        }

        // ================= CHECKOUT =================
        static void Checkout(List<ItemCart> cart, Product[] products)
        {
            string receiptNumber = receiptCounter.ToString("D4"); // 0001, 0002, etc.
            string dateTimeNow = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");


            Console.WriteLine("\n===========================================");
            Console.WriteLine("                 RECEIPT                  ");
            Console.WriteLine("===========================================");
            Console.WriteLine($"Receipt No: {receiptNumber}");
            Console.WriteLine($"Date: {dateTimeNow}");
            Console.WriteLine($"{"Item",-15} {"Qty",-7} {"Price",-10} {"Subtotal",-10}");
            Console.WriteLine("-------------------------------------------");

            double grandTotal = 0;

            foreach (var item in cart)
            {
                Console.WriteLine(
                    $"{item.Product.Name,-15} " +
                    $"{item.Quantity,-7} " +
                    $"PHP {item.Product.Price,-9:F2} " +
                    $"PHP {item.Subtotal,-10:F2}"
                );

                grandTotal += item.Subtotal;
            }

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"{"Grand Total:",-30} PHP {grandTotal:F2}");

            double discount = 0;
            if (grandTotal >= 5000)
            {
                discount = grandTotal * 0.10;
            }

            if (discount > 0)
            {
                Console.WriteLine($"{"Discount (10%):",-30} PHP {discount:F2}");
            }

            double finalTotal = grandTotal - discount;
            Console.WriteLine($"{"Final Total:",-30} PHP {finalTotal:F2}");
            Console.WriteLine("===========================================");

            receiptCounter++;

            // ================= PAYMENT =================
            double payment = 0;

            while (true)
            {
                Console.Write("\nEnter payment: PHP ");

                if (!double.TryParse(Console.ReadLine(), out payment))
                {
                    Console.WriteLine("Invalid input. Please enter a numeric value.");
                    continue;
                }

                if (payment < finalTotal)
                {
                    Console.WriteLine("Insufficient payment. Please enter a higher amount.");
                    continue;
                }

                break; // valid payment
            }

            double change = payment - finalTotal;

            Console.WriteLine($"{"Payment:",-30} PHP {payment:F2}");
            Console.WriteLine($"{"Change:",-30} PHP {change:F2}");
            Console.WriteLine("===========================================");

            Console.WriteLine("\nThank you for shopping at Ralph's Grocery Store!");

            // UPDATED STOCK 
            Console.WriteLine("\n===========================================");
            Console.WriteLine("         UPDATED STOCK AFTER PURCHASE      ");
            Console.WriteLine("===========================================");
            Console.WriteLine($"{"ID",-5} {"Product",-15} {"Price",-10} {"Stock",-5}");
            Console.WriteLine("-------------------------------------------");

            foreach (var p in products)
            {
                p.DisplayProduct();
            }

            StockReorderAlert(products);

            // LOW STOCK ALERT
            static void StockReorderAlert(Product[] products)
            {
                Console.WriteLine("\n===========================================");
                Console.WriteLine("            LOW STOCK ALERT               ");
                Console.WriteLine("===========================================");

                bool hasLowStock = false;

                foreach (var p in products)
                {
                    if (p.RemainingStock <= 5)
                    {
                        Console.WriteLine($"{p.Name} has only {p.RemainingStock} stock(s) left.");
                        hasLowStock = true;
                    }
                }

                if (!hasLowStock)
                {
                    Console.WriteLine("No low stock items at the moment.");
                }

                Console.WriteLine("===========================================");
            }
        }
    }
}