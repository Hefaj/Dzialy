using System;
using System.Windows.Input;

public class RelayCommand : ICommand
{
    private readonly Action<object> execute;
    private readonly Func<object, bool> canExecute;
    
    /// <summary>
    /// Create command for binding. 
    /// </summary>
    /// <param name="execute">Execute method</param>
    /// <param name="canExecute">Condition to execute operation</param>
    /// <exception cref="ArgumentNullException"></exception>
    public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
    {
        this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
        this.canExecute = canExecute;
    }
    
    public bool CanExecute(object parameter)
    {
        return canExecute is null || canExecute(parameter);
    }

    public void Execute(object parameter)
    {
        execute(parameter);
    }

    public event EventHandler CanExecuteChanged;
}
