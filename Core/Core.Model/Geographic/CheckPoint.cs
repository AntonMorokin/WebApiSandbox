using System.Collections.Generic;

namespace Core.Model.Geographic
{
    public class CheckPoint : Point
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Route> Routes { get; set; }

        public List<CheckPointToRouteMapping> RoutesMapping { get; set; }
    }
}
