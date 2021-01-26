namespace Core.Model.Geographic
{
    public class Point
    {
        public LatitudeType LatitudeType { get; set; }

        public decimal Latitude { get; set; }

        public LongitudeType LongitudeType { get; set; }

        public decimal Longitude { get; set; }

        public decimal Altitude { get; set; }

        public virtual bool IsCheckPoint => false;
    }
}
