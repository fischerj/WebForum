using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WebForum.Models
{
    public class Topic
    {
        
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Version { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }

        public Topic()
        {
            Id = Guid.NewGuid();
        }
    }
}
