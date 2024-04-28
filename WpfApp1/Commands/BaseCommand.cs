using System.Windows.Input;

namespace WpfApp1.Commands;

public abstract class BaseCommand : ICommand
{
  public event EventHandler? CanExecuteChanged;

  public virtual bool CanExecute(object? parameter)
  {
    return true;
  }

  public abstract void Execute(object? parameter);

  protected void OnCanExecuteChanged()
  {
    CanExecuteChanged?.Invoke(this, new EventArgs());
  }
}