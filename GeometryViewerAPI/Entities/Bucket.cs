using System.ComponentModel.DataAnnotations;

namespace GeometryViewerAPI.Entities
{
    public class Bucket: NamedEntity
    {
        [Required]
        public byte[] Bin { get; set; }

        public Bucket(string name, byte[] bin): base(name)
        {
            this.Name = name;
            this.Bin = bin;
        }
    }
}
