using Core.Entities;

namespace API.Dtos
{
    public class PlaceDTO
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public List<Image> Images{ get; set; }
    }
}