namespace pde_poc_sim.Engine
{
    public class Aggregation
    {
        public int Gainers { get; set; }
        public int Losers { get; set; }
        public int Neutral { get; set; }

        public int Total {
            get {
                return Gainers + Losers + Neutral;
            }
        }
        public double PercentGainers {
            get {
                return Gainers * 100 / Total;
            }
        }

        public double PercentLosers {
            get {
                return Losers * 100 / Total;
            }
        }

        public double PercentNeutral {
            get {
                return Neutral * 100 / Total;
            }
        }
    }
}