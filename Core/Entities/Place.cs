using Core.Entities.Identity;

namespace Core.Entities
{
    public class Place : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public int CoordinationsId { get; set; }
        public Coordinations Coordinations { get; set; }
        public string UserId { get; set; }
        public List<Image> Images{ get; set; }
    }
}