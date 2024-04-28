using WpfApp1.Services;
using WpfApp1.Stores;

namespace WpfApp1.ViewModels;

public class MainViewModel : ViewModelBase
{
  public BuyViewModel BuyViewModel { get; set; }
  public SellViewModel SellViewModel { get; }

  public MainViewModel()
  {
    OwnedItemsStore ownedItemsStore = new();
    PriceService priceService = new();

    BuyViewModel = new(ownedItemsStore, priceService);
    SellViewModel = new(ownedItemsStore, priceService);
  }
}