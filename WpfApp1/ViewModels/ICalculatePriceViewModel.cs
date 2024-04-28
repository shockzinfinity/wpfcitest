using System.ComponentModel;

namespace WpfApp1.ViewModels;

public interface ICalculatePriceViewModel : INotifyPropertyChanged
{
  string ItemName { get; }
  int Quantity { get; }
  bool CanCalculatePrice { get; }
  string StatusMessage { set; }
  string ErrorMessage { set; }
}