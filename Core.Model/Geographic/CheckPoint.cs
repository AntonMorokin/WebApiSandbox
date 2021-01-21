namespace Core.Model.Geographic
{
    public class CheckPoint : Point
    {
        public int CheckPointId { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public override bool IsCheckPoint => true;
    }
}
