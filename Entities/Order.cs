using System.Text;
using csharp_order_composition.Entities.Enums;

namespace csharp_order_composition.Entities;

public class Order
{
    public DateTime Moment { get; set; }
    public OrderStatus Status { get; set; }
    public Client Client { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public Order () {}
    public Order (DateTime moment, OrderStatus status, Client client)
    {
        Moment = moment;
        Status = status;
        Client = client;
    }

    public void AddItem(OrderItem item)
    {
        OrderItems.Add(item); 
    }
    public void RemoveItem(OrderItem item)
    {
        OrderItems.Remove(item);
    }

    public double Total()
    {
        double sum = 0.0; 
        foreach (OrderItem orderItems in OrderItems)
        {
            sum += orderItems.SubTotal();
        }
        return sum;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(); 
        sb.AppendLine($"Order moment: {Moment.ToString("dd/MM/yyyy HH:mm:ss")}");
        sb.AppendLine($"Order status: {Status}");
        sb.AppendLine($"Client: {Client}");
        sb.AppendLine("Order items");
        foreach (OrderItem item in OrderItems)
        {
            sb.AppendLine(item.ToString());
        }
        sb.AppendLine($"Total Price: {Total().ToString("C")}");
        return sb.ToString();

    }
}
