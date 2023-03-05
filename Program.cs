using csharp_order_composition.Entities;
using csharp_order_composition.Entities.Enums;

namespace csharp_order_composition;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter client data: ");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Birth date (dd/mm/yyyy): ");
        DateTime birthDate = DateTime.Parse(Console.ReadLine());

        //instanciando cliente com valores fornecidos pelo usuário
        Client client = new Client(name, email, birthDate); 
        
        //Informando o status do pedido utilizando enumeração 
        Console.WriteLine("Enter order data: ");
        Console.Write("Status: ");
        OrderStatus os = Enum.Parse<OrderStatus>(Console.ReadLine());
        Order order = new Order(DateTime.Now, os, client); 

        Console.Write("How many items to this order? ");
        int numItems = int.Parse(Console.ReadLine()); 

        for (int i = 1; i <= numItems; i++)
        {
            Console.WriteLine($"Enter #{i} item data: ");
            Console.Write("Product name: ");
            string productName = Console.ReadLine();
            Console.Write("Product price: ");
            double productPrice = double.Parse(Console.ReadLine());

            //instanciando produto com valores fornecidos pelo usuário
            Product product = new Product(productName, productPrice);

            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            //instanciando um item do pedido 
            OrderItem orderItem = new OrderItem(quantity, productPrice, product);

            //Adicionando item no pedido 
            order.AddItem(orderItem); 

        }

        Console.WriteLine();
        Console.WriteLine("ORDER SUMARY");
        Console.WriteLine(order);
    }
}