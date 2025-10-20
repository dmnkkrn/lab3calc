using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using labcalcgit.Models;
using CommunityToolkit.Mvvm.Input;


namespace labcalcgit.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly ConcentrationCalculator _calculator;

        public HomeViewModel()
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

        #region Frontend zmienne

        /// <summary>
        /// Typowe naczynia
        /// </summary>
        [ObservableProperty] private ObservableCollection<VesselOption> vessels = new();

        /// <summary>
        /// Typowe roztwory
        /// </summary>
        [ObservableProperty] private ObservableCollection<SolutionOption> solutions = new();

        [ObservableProperty] private VesselOption? selectedVessel;

        partial void OnSelectedVesselChanged(VesselOption? value)
        {
            if (value == null)
            {
                return;
            }

            Capacity = value.Capacity;
        }

        [ObservableProperty] private SolutionOption? selectedSolution;

        partial void OnSelectedSolutionChanged(SolutionOption? value)
        {
            if (value == null)
            {
                return;
            }

            ConcentrationPercent = value.Percent;
        }

        /// <summary>
        /// Pojemność naczynia [ml]
        /// </summary>
        [ObservableProperty] private int? capacity;

        /// <summary>
        /// Zawartość [%]
        /// </summary>
        [ObservableProperty] private int? concentrationPercent;

        /// <summary>
        /// Liczba sztuk
        /// </summary>
        [ObservableProperty] private int? count;

        /// <summary>
        /// Łączna objętość [ml]
        /// </summary>
        [ObservableProperty] private double totalVolume;

        /// <summary>
        /// Objętość czystej substancji [ml]
        /// </summary>
        [ObservableProperty] private double pureSubstanceVolume;

        [RelayCommand]
        void DecrementCount()
        {
            if (!Count.HasValue) Count = 1;
            if (Count <= 1) return;
            Count -= 1;
        }

        [RelayCommand]
        void IncrementCount()
        {
            if (!Count.HasValue) Count = 0;
            Count += 1;
        }

        [RelayCommand]
        void Calculate()
        {
            if (!Capacity.HasValue || !ConcentrationPercent.HasValue || !Count.HasValue)
            {
                return;
            }

            TotalVolume = _calculator.CalculateSum((double)ConcentrationPercent, (double)Count);
            PureSubstanceVolume = _calculator.CalculatePercentage((double)ConcentrationPercent, (double)Capacity) /
                100 * TotalVolume;
        }

        [RelayCommand]
        void Reset()
        {
            SelectedVessel = null;
            SelectedSolution = null;
            Capacity = null;
            ConcentrationPercent = null;
            Count = null;
            TotalVolume = 0;
            PureSubstanceVolume = 0;
        }

        #endregion

        /// <summary>
        /// It's the same thing as volume before
        /// </summary>
        [ObservableProperty] double solute;

        [ObservableProperty] double solution;

        [ObservableProperty] double units;

        [ObservableProperty] double result;

        [RelayCommand]
        void CalculateConcentration() => Result = _calculator.CalculatePercentage(Solute, Solution);

        [RelayCommand]
        void CalculateVolume() => Result = _calculator.CalculateSum(Solute, Units);

        [RelayCommand]
        void CalculateConcentrationWithVolume() =>
            Result = _calculator.CalculatePercentageWithSum(Solute, Solution, Units);
    }
}