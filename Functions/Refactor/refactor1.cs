public void ProcessOrder(Order order)
{
    ValidateOrder(order);
    decimal total = CalculateTotal(order);
    total = ApplyPremiumDiscount(order, total);
    SaveOrder(order, total);
    SendConfirmationEmail(order, total);
}

private void ValidateOrder(Order order)
{
    if (order == null) throw new ArgumentNullException(nameof(order));
    if (order.Items.Count == 0) throw new InvalidOperationException("Empty order");
}

private decimal CalculateTotal(Order order)
{
    const decimal taxRate = 0.1m;
    decimal total = 0;
    foreach (var item in order.Items)
    {
        total += item.Price * item.Quantity;
        if (item.IsTaxable)
        {
            total += item.Price * taxRate;
        }
    }
    return total;
}

private decimal ApplyPremiumDiscount(Order order, decimal total)
{
    const decimal premiumDiscountRate = 0.1m;
    if (order.Customer.IsPremium)
    {
        total *= (1 - premiumDiscountRate);
    }
    return total;
}

private void SaveOrder(Order order, decimal total)
{
    using (var db = new AppDbContext())
    {
        order.Total = total;
        db.Orders.Add(order);
        db.SaveChanges();
    }
}

private void SendConfirmationEmail(Order order, decimal total)
{
    var emailService = new EmailService();
    emailService.Send(order.Customer.Email, "Order Confirmed", $"Total: ${total}");
}
