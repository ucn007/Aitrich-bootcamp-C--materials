using OnlineShop.Exception;

namespace OnlineShop.Validation;

public class Validation
{
    
     
    
    public void PriceCheck(decimal value)
    {
        if (value <= 0)
            throw new InvalidValueException("Price must be greater than zero.");
    }

    public void QuantityCheck(int value)
    {
        if (value <= 0)
            throw new InvalidValueException("Quantity must be greater than zero.");
    }

    public void ValidateOrderDate(DateTime orderDate)
    {
        if (orderDate > DateTime.Now)
            throw new InvalidDateException("Order date cannot be in the future.");
    }
}