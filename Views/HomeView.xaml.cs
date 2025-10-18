using labcalcgit.ViewModels;

namespace labcalcgit.Views;

public partial class HomePage : ContentPage
{
    public HomePage(CalculatorViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm; 
    }
}
