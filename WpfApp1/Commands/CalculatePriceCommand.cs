using System.Windows.Input;
using WpfApp1.Exceptions;
using WpfApp1.Services;
using WpfApp1.ViewModels;

namespace WpfApp1.Commands;

public class CalculatePriceCommand : BaseCommand
{
  private readonly ICalculatePriceViewModel _viewModel;
  private readonly IPriceService _priceService;

  public CalculatePriceCommand(ICalculatePriceViewModel viewModel, IPriceService priceService)
  {
    _viewModel = viewModel;
    _priceService = priceService;

    _viewModel.PropertyChanged += ViewModel_PropertyChanged;
  }

  public override bool CanExecute(object? parameter)
  {
    return _viewModel.CanCalculatePrice;
  }

  private void ViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
  {
    OnCanExecuteChanged();
  }

  public override void Execute(object? parameter)
  {
    _viewModel.StatusMessage = string.Empty;
    _viewModel.ErrorMessage = string.Empty;

    try
    {
      double itemPrice = _priceService.GetPrice(_viewModel.ItemName);
      double totalPrice = itemPrice * _viewModel.Quantity;

      _viewModel.StatusMessage = $"The total price of {_viewModel.Quantity} {_viewModel.ItemName} is {totalPrice:C}.";
    }
    catch (ItemPriceNotFoundException)
    {
      _viewModel.ErrorMessage = $"Unable to find price of {_viewModel.ItemName}.";
    }
  }
}