using Shopping_Cart_Activity_Sunglao;

class Program
{
    static void Main()
    {
        Product[] products = new Product[]
        {
            new Product(1, "Keyboard", 1500, 10),
            new Product(2, "Mouse", 500, 15),
            new Product(3, "Headset", 1200, 8),
            new Product(4, "Monitor", 7000, 5),
            new Product(5, "USB Cable", 200, 20)
        };

        CartItem[] cart = new CartItem[5];
        int cartCount = 0;

        bool continueShopping = true;

        while (continueShopping)
        {
            Console.WriteLine("\n=== PRODUCT MENU ===");
            foreach (var p in products)
            {
                p.DisplayProduct();
            }

            Console.Write("\nEnter product number: ");
            string inputProduct = Console.ReadLine();

            if (!int.TryParse(inputProduct, out int productChoice) ||
                productChoice < 1 || productChoice > products.Length)
            {
                Console.WriteLine("Invalid product number.");
                continue;
            }

            Product selectedProduct = products[productChoice - 1];

            if (selectedProduct.RemainingStock == 0)
            {
                Console.WriteLine("This product is out of stock.");
                continue;
            }

            Console.Write("Enter quantity: ");
            string inputQty = Console.ReadLine();

            if (!int.TryParse(inputQty, out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                continue;
            }

            if (!selectedProduct.HasEnoughStock(quantity))
            {
                Console.WriteLine("Not enough stock available.");
                continue;
            }

            // Check for duplicate in cart
            bool found = false;
            for (int i = 0; i < cartCount; i++)
            {
                if (cart[i].Product.Id == selectedProduct.Id)
                {
                    cart[i].Update(quantity);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                if (cartCount >= cart.Length)
                {
                    Console.WriteLine("Cart is full.");
                    continue;
                }

                cart[cartCount] = new CartItem(selectedProduct, quantity);
                cartCount++;
            }

            selectedProduct.DeductStock(quantity);
            Console.WriteLine("Item added to cart!");

            Console.Write("Add more items? (Y/N): ");
            string choice = Console.ReadLine().ToUpper();

            if (choice == "N")
                continueShopping = false;
        }

        // Display Receipt
        Console.WriteLine("\n=== RECEIPT ===");
        double grandTotal = 0;

        for (int i = 0; i < cartCount; i++)
        {
            Console.WriteLine($"{cart[i].Product.Name} x{cart[i].Quantity} = ₱{cart[i].Subtotal}");
            grandTotal += cart[i].Subtotal;
        }

        Console.WriteLine($"Grand Total: ₱{grandTotal}");

        double discount = 0;
        if (grandTotal >= 5000)
        {
            discount = grandTotal * 0.10;
            Console.WriteLine($"Discount (10%): ₱{discount}");
        }

        double finalTotal = grandTotal - discount;
        Console.WriteLine($"Final Total: ₱{finalTotal}");

        // Show updated stock
        Console.WriteLine("\n=== UPDATED STOCK ===");
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Name} - Remaining: {p.RemainingStock}");
        }

        Console.WriteLine("\nThank you for shopping!");
    }
}