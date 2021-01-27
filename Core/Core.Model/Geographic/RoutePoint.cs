namespace Core.Model.Geographic
{
    public class RoutePoint : Point
    {
        public int RouteId { get; set; }

        public Route Route { get; set; }

        public int PositionInRoute { get; set; }
    }
}
