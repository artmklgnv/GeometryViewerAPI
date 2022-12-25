using System.ComponentModel.DataAnnotations;

namespace GeometryViewerAPI.Entities
{
    public class Bucket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public byte[] Bin { get; set; }

        public Bucket(string name, byte[] bin)
        {
            this.Name = name;
            this.Bin = bin;
        }
    }
}
