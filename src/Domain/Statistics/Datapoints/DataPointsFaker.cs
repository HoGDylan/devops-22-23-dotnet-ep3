using Bogus;
using Domain.Common;

namespace Domain.Statistics.Datapoints
{

    public class DataPointsFaker : Faker<DataPoint>
    {

        //singleton zodat hij niet steeds een nieuwe faker object moet creëren per virtual machine (memory heap)
        private static DataPointsFaker _instance;
        public static DataPointsFaker Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new DataPointsFaker();
                }
                return _instance;
            }
        }

        public Hardware Hardware { get; set; }
            

        public DataPointsFaker()
        {
            int tick = 1;
            CustomInstantiator(e => new DataPoint(tick++, GenerateRandomHardWareUsage()));
        }




        public Hardware GenerateRandomHardWareUsage()
        {

            return new Hardware((int)Math.Floor(Hardware.Memory * new Random().NextDouble()), (int)Math.Floor(Hardware.Storage * new Random().NextDouble()), (int)Math.Floor(Hardware.Amount_vCPU * new Random().NextDouble()));
        }


    }
}
