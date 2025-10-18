using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace labcalcgit.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    [ObservableProperty] 
    private string title = "Strona główna";
    [RelayCommand] 
    void Ping() { /* tu ogarnij co ma się stać */ }
}
