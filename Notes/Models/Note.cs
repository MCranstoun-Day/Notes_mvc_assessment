namespace Notes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class Note
    {
        public IEnumerable<SelectListItem> CategoryList { get; set; }

        [Key]
        public int Notes_ID { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Note description")]
        public string NoteDescription { get; set; }

        [Required]
        [Display(Name = "Note category")]
        public int NoteCategory_ID { get; set; }

        public string CreateBy { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string SaveBy { get; set; }
        public DateTime SaveDateTime { get; set; }

    }
}
