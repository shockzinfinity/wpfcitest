using WpfApp1.Stores;
using WpfApp1.ViewModels;

namespace WpfApp1.Commands;

public class BuyCommand : BaseCommand
{
  private readonly BuyViewModel _viewModel;
  private readonly IOwnedItemsStore _ownedItemsStore;

  public BuyCommand(BuyViewModel viewModel, IOwnedItemsStore ownedItemsStore)
  {
    _viewModel = viewModel;
    _ownedItemsStore = ownedItemsStore;
    _viewModel.PropertyChanged += ViewModel_PropertyChanged;
  }

  private void ViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
  {
    OnCanExecuteChanged();
  }

  public override bool CanExecute(object? parameter)
  {
    return _viewModel.IsValidBuy;
  }

  public override void Execute(object? parameter)
  {
    _viewModel.StatusMessage = string.Empty;
    _viewModel.ErrorMessage = string.Empty;

    _ownedItemsStore.Buy(_viewModel.ItemName, _viewModel.Quantity);

    _viewModel.StatusMessage = $"Successfully bought {_viewModel.Quantity} {_viewModel.ItemName}";
  }
}