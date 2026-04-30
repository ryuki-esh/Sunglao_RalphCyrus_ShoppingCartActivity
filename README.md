# Sunglao_RalphCyrus_ShoppingCartActivity

Sunglao, Ralph Cyrus I. BSIT 1-1 Shopping Cart Activity

Hello, everyone! This is my work for the Shopping Cart Activity to be recorded as Quiz 2 & 3.

This is the Shopping Cart System that I made for this activity. It basically does its work as a normal shopping cart system. It consists of three main classes: Product, CartItem, and Program. The Product class represents items available in the store, including their ID, name, price, and remaining stock, along with methods to display product details and manage stock. The CartItem class represents items added to the cart, storing the selected product, quantity, and subtotal while allowing updates for duplicate entries. The Program class contains the main logic, where a list of products is displayed, user input is collected and validated, and selected items are added to the cart.

This system ensures proper validation by checking for invalid inputs, insufficient stock, and duplicate items. It continuously allows the user to add products until they choose to stop. Once finished, the program generates a formatted receipt showing all purchased items, calculates the grand total, applies a 10% discount for totals of 5000 or more, and displays the final amount. It also updates and shows the remaining stock after checkout, simulating a simple real-world shopping experience.

Changes and features added in Part 2:

1. Cart Management
- View cart items
- Remove specific item
- Clear entire cart
- Stock is restored when items are removed

2. Product Search
- Search products by name 
- Displays matching results only

3. Category Filtering
Filter products by:
- Food
- Electronics
- Clothing
- Add items directly from filtered list

4. Checkout System
- Generates receipt with:
- Receipt number
- Date & time
- Item breakdown
- Quantity
- Subtotal
Calculates:
- Grand total
- 10% discount (if ₱5000 and above)
- Final total
- Handles payment and computes change

5. Stock Management
- Automatically deducts stock when buying
- Restores stock when removing items from cart
- Shows updated stock after checkout

6. Low Stock Alert
- Displays warning when stock is ≤ 5
- Helps identify items needing restock

7. Order History System
- Stores completed transactions
Displays:
- Receipt number
- Final total

Shows message if no transactions exist:

“No transactions yet”

8. Continuous Menu System
- After every action, user returns to main menu
- Program only ends when explicitly exited

Summary of changes

From the cart management section up to the continuous menu system, several improvements were made to enhance the functionality of the shopping cart program. The cart management system was developed to allow users to view items in their cart, remove specific items, and clear the entire cart when needed. It was also improved to properly handle stock updates by restoring product quantities when items are removed from the cart, ensuring accurate inventory tracking. In addition, a product search feature was added, allowing users to find items by name using partial and case-insensitive matching. A category filtering system was also implemented, enabling users to browse products based on categories such as Food, Electronics, and 
Clothing, and directly add items from filtered results.

The checkout system was enhanced to generate a complete receipt that includes a receipt number, date and time, item details, subtotals, and a final total. It also calculates discounts for purchases reaching a certain amount and processes payment with change computation. Alongside this, a stock management system was introduced that automatically deducts stock during purchases and updates product availability after checkout, with a low stock alert feature that warns when items reach a critical level. An order history system was also added to store completed transactions and display them when requested, showing a message when no transactions exist. Finally, the program was structured into a continuous menu system using a loop, allowing users to perform multiple actions repeatedly without restarting the program, making the system more interactive and user-friendly.

  
AI Usage in This Project:

- I used the AI to help me recall how to use class and methods and how can I utilize it in this activity to make my code more organized.
- I used the AI to help me link my .cs files to my repository so that my progress and commits can be tracked real time in GitHUB.
- I used the AI to help me organize my UI and my codes as well.
- I used the AI to help me guide through how to use GitHub and maximize my use of this platform.
- I used the AI to help me recall some functions that I can use for this project, such as how to use loops and arrays.
- I asked the AI how can I incorporate real time date and time into my code when it comes to the receipt section
- I used the AI how to utilize looping since it is used often althroughout the code
- Acted as a reference tool for improving logic and understanding how different parts of the system connect
- Assisted in debugging logical problems that affected program flow and menu navigation
- Provided suggestions for organizing code into proper methods (e.g., checkout, cart management, order history)
- Helped improve overall program structure for better readability and maintainability
- Supported the implementation of features like order history, stock management, and category filtering

