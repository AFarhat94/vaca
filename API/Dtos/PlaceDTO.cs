using Core.Entities;

namespace API.Dtos
{
    public class PlaceDTO
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CoordinationsId { get; set; }
        public Coordinations Coordinations { get; set; }
        public List<Image> Images{ get; set; }
    }
}