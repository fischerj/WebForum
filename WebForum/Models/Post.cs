using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace WebForum.Models
{
    public class Post
    {
        
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Title")]
        public string Name { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public int Version { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime LastUpdated { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public bool Deleted { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
        
        
        public string Body { get; set; }


        //[ForeignKey("Topic")]
        //[BindNever]
        //[ScaffoldColumn(false)]
        //public Guid TopicId { get; set; }

        //[ForeignKey("TopicId")]
        [InverseProperty("Id")]
        public virtual Guid TopicId { get; set; }
    
        public string Description { get; set; }

        public Post()
        {
            Id = Guid.NewGuid();

            Version += 1;

            LastUpdated = DateTime.UtcNow;

            Date = DateTime.Now;

            Deleted = false;
        }

    }
}