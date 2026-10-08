using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public partial class Destination
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? City { get; set; }

        //// New property for storing image binary
        //public byte[]? ImageData { get; set; }

        // Replace ImageData with ImageUrl
        public string? ImageUrl { get; set; }

        //public virtual ICollection<Tourss> Tours { get; set; } = new List<Tourss>();
    }
}
