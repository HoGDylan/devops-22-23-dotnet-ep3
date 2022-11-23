using Bogus;
using Domain.Common;

namespace Domain.Statistics.Datapoints
{
    public class DataPointsFaker : Faker<DataPoint>
    {

        public DataPointsFaker(Hardware hardware)
        {
            int tick = 1;
            CustomInstantiator(e => new DataPoint(tick++, GenerateRandomHardWareUsage(hardware)));
        }






        public Hardware GenerateRandomHardWareUsage(Hardware hardware)
        {

            return new Hardware((int)Math.Floor(hardware.Memory * new Random().NextDouble()), (int)Math.Floor(hardware.Storage * new Random().NextDouble()), (int)Math.Floor(hardware.Amount_vCPU * new Random().NextDouble()));


        }


    }
}
