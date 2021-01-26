using System.Collections.Generic;

namespace Core.Model.Geographic
{
    public class CheckPoint : Point
    {
        public int CheckPointId { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<CheckPointToRouteMapping> RoutesMapping { get; set; }
    }
}
