namespace CRMCloud.Base
{
    public static class WaitTime
    {
        public static TimeSpan ShortWaitTime { get; set; } = TimeSpan.FromSeconds(5);

        public static TimeSpan MediumWaitTime { get; set; } = TimeSpan.FromSeconds(30);

        public static TimeSpan AverageWaitTime { get; set; } = TimeSpan.FromSeconds(15);

        public static TimeSpan LongWaitTime { get; set; } = TimeSpan.FromSeconds(60);

        public static TimeSpan VeryLongWaitTime { get; set; } = TimeSpan.FromSeconds(90);
    }
}
