namespace Core.Model.Geographic
{
    public sealed class CheckPointToRouteMapping
    {
        public int RouteId { get; set; }

        public int CheckPointId { get; set; }

        public int PositionInRoute { get; set; }

        public Route Route { get; set; }

        public CheckPoint Point { get; set; }
    }
}
