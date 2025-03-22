using MyShift.Models;
using MyShift.Resources.Languages;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyShift.Services;

public class ShiftMananger : INotifyPropertyChanged
{
    private Dictionary<ShiftNames, List<string>> _shifts = new Dictionary<ShiftNames, List<string>>
    {
        {
            ShiftNames.Morning, new List<string>
            {
                $"A - {AppStrings.FirstMorning}", 
                $"A - {AppStrings.SecondMorning}",
                $"A - {AppStrings.ThirdMorning}",
                $"A - {AppStrings.FourthMorning}",
                $"B - {AppStrings.FirstMorning}",
                $"B - {AppStrings.SecondMorning}",
                $"B - {AppStrings.ThirdMorning}",
                $"B - {AppStrings.FourthMorning}",
                $"C - {AppStrings.FirstMorning}",
                $"C - {AppStrings.SecondMorning}" 
            } 
        },
        {
            ShiftNames.Afternoon, new List<string>  
            {
                $"C - {AppStrings.FirstAfternoon}",
                $"C - {AppStrings.SecondAfternoon}",
                $"D - {AppStrings.FirstAfternoon}",
                $"D - {AppStrings.SecondAfternoon}",
                $"D - {AppStrings.ThirdAfternoon}",
                $"D - {AppStrings.FourthAfternoon}",
                $"E - {AppStrings.FirstAfternoon}",
                $"E - {AppStrings.SecondAfternoon}",
                $"E - {AppStrings.ThirdAfternoon}",
                $"E - {AppStrings.FourthAfternoon}"
            } 
        },
        {
            ShiftNames.Night, new List<string>
            {
                $"E - {AppStrings.FirstNight}",
                $"E - {AppStrings.SecondNight}",
                $"C - {AppStrings.FirstNight}",
                $"C - {AppStrings.SecondNight}",
                $"A - {AppStrings.FirstNight}",
                $"A - {AppStrings.SecondNight}",
                $"D - {AppStrings.FirstNight}",
                $"D - {AppStrings.SecondNight}",
                $"B - {AppStrings.FirstNight}",
                $"B - {AppStrings.SecondNight}"
            } 
        },
        {
            ShiftNames.DayOff, new List<string>
            { 
                $"B - {AppStrings.FirstDayOff}",
                $"D - {AppStrings.FourthDayOff}",
                $"E - {AppStrings.FirstDayOff}",
                $"B - {AppStrings.FourthDayOff}",
                $"C - {AppStrings.FirstDayOff}",
                $"E - {AppStrings.FourthDayOff}",
                $"A - {AppStrings.FirstDayOff}",
                $"C - {AppStrings.FourthDayOff}",
                $"D - {AppStrings.FirstDayOff}",
                $"A - {AppStrings.FourthDayOff}"
            }
        },
        {
            ShiftNames.DayOffOT, new List<string> 
            { 
                $"D - {AppStrings.ThirdDayOff}", 
                $"B - {AppStrings.SecondDayOff}", 
                $"B - {AppStrings.ThirdDayOff}", 
                $"E - {AppStrings.SecondDayOff}", 
                $"E - {AppStrings.ThirdDayOff}", 
                $"C - {AppStrings.SecondDayOff}", 
                $"C - {AppStrings.ThirdDayOff}", 
                $"A - {AppStrings.SecondDayOff}", 
                $"A - {AppStrings.ThirdDayOff}", 
                $"D - {AppStrings.SecondDayOff}"
            }
        },
    };

    private string? _morningShift;
    public string? MorningShift
    {
        get => _morningShift; 
        set 
        { 
            _morningShift = value; 
            OnPropertyChanged();
        }
    }

    private string? _afternoonShift;
    public string? AfternoonShift
    {
        get => _afternoonShift; 
        set 
        { 
            _afternoonShift = value;
            OnPropertyChanged();
        }
    }

    private string? _nightShift;

    public string? NightShift
    {
        get => _nightShift;
        set 
        { 
            _nightShift = value;
            OnPropertyChanged();
        }
    }

    private string? _dayOff;
    public string? DayOff
    {
        get => _dayOff;
        set 
        { 
            _dayOff = value;
            OnPropertyChanged();
        }
    }

    private string? _dayOffOT;
    public string? DayOffOT
    {
        get => _dayOffOT;
        set
        {
            _dayOffOT = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void RefreshShifts(DateOnly date, int offset)
    {
        int index = (date.DayNumber + offset) % 10;

        MorningShift = _shifts[ShiftNames.Morning][index];
        AfternoonShift = _shifts[ShiftNames.Afternoon][index];
        NightShift = _shifts[ShiftNames.Night][index];
        DayOff = _shifts[ShiftNames.DayOff][index];
        DayOffOT = _shifts[ShiftNames.DayOffOT][index];
    }
}
