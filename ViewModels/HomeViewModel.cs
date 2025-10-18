using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using labcalcgit.Models;

namespace labcalcgit.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    [ObservableProperty] private string title = "Strona główna";
    [ObservableProperty] private VesselOption? selectedVessel;
    [ObservableProperty] private SolutionOption? selectedSolution;
    [ObservableProperty] private ObservableCollection<VesselOption> vessels = new();
    [ObservableProperty] private ObservableCollection<SolutionOption> solutions = new();

    public HomeViewModel()
    {
        Vessels = new ObservableCollection<VesselOption>
        {
            new() { Name = "Kieliszek 50 ml", Capacity = 50 },
            new() { Name = "Szklanka 250 ml", Capacity = 250 },
            new() { Name = "Butelka 500 ml", Capacity = 500 },
        };

        Solutions = new ObservableCollection<SolutionOption>
        {
            new() { Name = "Sok 12%", Percent = 12 },
            new() { Name = "Roztwór 40%", Percent = 40 },
            new() { Name = "Koncentrat 70%", Percent = 70 },
        };
    }

    [RelayCommand]
    void Ping()
    {
    }
}