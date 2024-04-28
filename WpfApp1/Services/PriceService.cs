using WpfApp1.Exceptions;

namespace WpfApp1.Services;

internal class PriceService : IPriceService
{
  public double GetPrice(string itemName)
  {
    return itemName.ToLower() switch
    {
      "apple" => 0.49,
      "shirt" => 19.99,
      "phone" => 499.99,
      "burrito" => 9.99,
      "shoes" => 119.99,
      _ => throw new ItemPriceNotFoundException(itemName)
    };
  }
}