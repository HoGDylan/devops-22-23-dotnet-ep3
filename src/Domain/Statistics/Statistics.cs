using Domain.Common;
using Domain.Statistics.Datapoints;
using Domain.VirtualMachines.Statistics;

namespace Domain.Statistics;

public class Statistic
{


    private List<DataPoint> _dataPoints; 
    private DataPointsFaker _faker;


    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Hardware Hardware { get; set; }


    public Statistic(DateTime start, DateTime end, Hardware hardware)
    {
        StartTime = start;
        EndTime = end;
        Hardware = hardware;

        _faker = new DataPointsFaker(hardware);

    }


    public Dictionary<DateTime, DataPoint> GetFakeStatistics(StatisticsPeriod period)
    {
        List<DataPoint> _dataPoints = _faker.Generate(GetAmountOfTicks(period));
        List<DateTime> _datePoints = GetFakeDataPoints(period);

        Dictionary<DateTime, DataPoint> output = new();

        for(int i = 0; i < _dataPoints.Count; i++)
        {
            output.Add(_datePoints[i], _dataPoints[i]);
        }
        return output; 
    
        }

    private List<DateTime> GetFakeDataPoints(StatisticsPeriod period)
    {
        List<DateTime> output = new();

        int max = GetAmountOfTicks(period);
        DateTime start = FormatStartTime(period);
        

        for(int i = 0; i < max; i++)
        {
            switch (period)
            {
                case StatisticsPeriod.HOURLY:
                    output.Add(start.AddHours(i));
                    break;

                case StatisticsPeriod.DAILY:
                    output.Add(start.AddDays(i));
                    break;

                case StatisticsPeriod.WEEKLY:
                    output.Add(start.AddDays(i * 7));
                    break;

                case StatisticsPeriod.MONTHLY:
                    output.Add(start.AddMonths(i));
                    break;
            }

        }

        return output;

    }

    private DateTime FormatStartTime(StatisticsPeriod period)
    {

        int dayOfWeek = ((int)StartTime.DayOfWeek);

        switch (period)
        {
            case StatisticsPeriod.HOURLY:
                {
                    DateTime dt = StartTime.AddHours(1);
                    return DateTime.Parse($"{dt.Day}/{dt.Month}/{dt.Year} {dt.Hour}:00");
                }

            case StatisticsPeriod.DAILY:
                {
                    DateTime dt = StartTime.AddDays(1);
                    
                    return DateTime.Parse($"{dt.Day}/{dt.Month}/{dt.Year} 00:00");

                }
            case StatisticsPeriod.WEEKLY:
                {
                    int check = 8;   // https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek?view=net-6.0
                    int addToCount = check - dayOfWeek; //begint vanaf week erna de maandag

                    DateTime dt = StartTime.AddDays(addToCount);
                    return DateTime.Parse($"{dt.Day}/{dt.Month}/{dt.Year} 00:00");
                }

            case StatisticsPeriod.MONTHLY:
                {
                    int check = DateTime.DaysInMonth(StartTime.Year, StartTime.Month);
                    int addToCount = check - StartTime.Day;

                    DateTime dt = StartTime.AddDays(addToCount);
                    return DateTime.Parse($"{dt.Day}/{dt.Month}/{dt.Year} 00:00");

                }

            default: throw new ArgumentException("No valid period provided");
        }
    }

      

    private int GetAmountOfTicks(StatisticsPeriod period)
    {
        switch (period)
        {
            case StatisticsPeriod.HOURLY: return DateTime.Now.Hour - StartTime.Hour;
            case StatisticsPeriod.DAILY: return DateTime.Now.Day - StartTime.Day;
            case StatisticsPeriod.WEEKLY: return (DateTime.Now.Day - StartTime.Day) % 7;
            case StatisticsPeriod.MONTHLY: return (DateTime.Now.Day - StartTime.Day) % 30;
        }

        return 0;
    }
    
}
