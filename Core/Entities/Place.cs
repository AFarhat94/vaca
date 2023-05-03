namespace Core.Entities
{
    public class Place : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
        public List<Image> Images{ get; set; }
    }
}