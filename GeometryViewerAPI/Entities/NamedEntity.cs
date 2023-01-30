using System.ComponentModel.DataAnnotations;

namespace GeometryViewerAPI.Entities
{
    public class NamedEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public NamedEntity(string name)
        {
            this.Name = name;
        }
    }
}
