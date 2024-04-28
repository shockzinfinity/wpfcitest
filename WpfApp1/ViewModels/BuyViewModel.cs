using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Services;
using WpfApp1.Stores;

namespace WpfApp1.ViewModels;

public class BuyViewModel : ViewModelBase, ICalculatePriceViewModel
{
  public IEnumerable<string> BuyableItems { get; }
  public bool IsValidBuy => !string.IsNullOrEmpty(ItemName) && Quantity > 0;

  private string _itemName;

  public string ItemName
  {
    get => _itemName;
    set
    {
      _itemName = value;
      OnPropertyChanged(nameof(ItemName));
      OnPropertyChanged(nameof(IsValidBuy));
      OnPropertyChanged(nameof(CanCalculatePrice));
    }
  }

  private int _quantity;

  public int Quantity
  {
    get => _quantity;
    set
    {
      _quantity = value;
      OnPropertyChanged(nameof(Quantity));
      OnPropertyChanged(nameof(IsValidBuy));
      OnPropertyChanged(nameof(CanCalculatePrice));
    }
  }

  public bool CanCalculatePrice => IsValidBuy;

  private string _statusMessage;

  public string StatusMessage
  {
    get => _statusMessage;
    set
    {
      _statusMessage = value;
      OnPropertyChanged(nameof(StatusMessage));
    }
  }

  private string _errorMessage;

  public string ErrorMessage
  {
    get => _errorMessage;
    set
    {
      _errorMessage = value;
      OnPropertyChanged(nameof(ErrorMessage));
    }
  }

  public ICommand CalculatePriceCommand { get; }
  public ICommand BuyCommand { get; }

  public BuyViewModel(IOwnedItemsStore ownedItemsStore, IPriceService priceService)
  {
    BuyableItems = new ObservableCollection<string>
        {
          "apple",
          "shirt",
          "phone",
          "burrito",
          "pillow"
        };

    CalculatePriceCommand = new CalculatePriceCommand(this, priceService);
    BuyCommand = new BuyCommand(this, ownedItemsStore);
  }
}