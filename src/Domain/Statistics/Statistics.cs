using Domain.Common;
using Domain.Statistics.Datapoints;

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


    public List<DataPoint> GetFakeStatisticsPerHour()
    {
        if(_dataPoints == null)
        {
            _dataPoints = _faker.Generate(GetDataPointsPerHour());
        }

        return _dataPoints;
    
        }



    private int GetDataPointsPerHour()
    {
       return DateTime.Now.Hour - StartTime.Hour;
    }
    
}
