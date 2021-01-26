namespace Core.Model.Geographic
{
    public class RoutePoint : Point
    {
        public int PositionInRoute { get; set; }

        public Route Route { get; set; }
    }
}
