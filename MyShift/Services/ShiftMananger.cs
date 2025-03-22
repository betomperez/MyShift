using MyShift.Models;
using MyShift.Resources.Languages;

namespace MyShift.Services;

class ShiftMananger
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

    public string? MorningShift { get; set; }
    public string? AfternoonShift { get; set; }
    public string? NightShift { get; set; }
    public string? DayOffA { get; set; }
    public string? DayOffB { get; set; }

    public void RefreshShifts(DateOnly date, int offset)
    {
        int index = (date.DayNumber + offset) % 10;

        MorningShift = _shifts[ShiftNames.Morning][index];
        AfternoonShift = _shifts[ShiftNames.Afternoon][index];
        NightShift = _shifts[ShiftNames.Night][index];
        DayOffA = _shifts[ShiftNames.DayOff][index];
        DayOffB = _shifts[ShiftNames.DayOffOT][index];
    }
}
