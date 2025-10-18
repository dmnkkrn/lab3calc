using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace labcalcgit.ViewModels
{
    public partial class CalculatorViewModel : ObservableObject
    {
        private readonly ConcentrationCalculator _calculator;
        public CalculatorViewModel()
        {
            _calculator = new ConcentrationCalculator();

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

        [ObservableProperty]
        private VesselOption? selectedVessel;

        [ObservableProperty]
        private SolutionOption? selectedSolution;

        [ObservableProperty]
        private ObservableCollection<VesselOption> vessels = new();

        [ObservableProperty]
        private ObservableCollection<SolutionOption> solutions = new();

        [ObservableProperty]
        double solute; //It's the same thing as volume before

        [ObservableProperty]
        double solution;

        [ObservableProperty]
        double units;

        [ObservableProperty]
        double result;

        [RelayCommand]
        void CalculateConcentration() => Result = _calculator.CalculatePercentage(Solute, Solution);

        [RelayCommand]
        void CalculateVolume() => Result = _calculator.CalculateSum(Solute, Units);

        [RelayCommand]
        void CalculateConcentrationWithVolume() => Result = _calculator.CalculatePercentageWithSum(Solute, Solution, Units);
    }
