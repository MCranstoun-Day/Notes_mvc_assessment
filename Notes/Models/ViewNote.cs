namespace Notes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class ViewNote
    {
        public IEnumerable<SelectListItem> CategoryList { get; set; }

        [Key]
        public int Notes_ID { get; set; }
        public int NoteCategory_ID { get; set; }

        [StringLength(500)]
        [Display(Name = "Note description")]
        public string NoteDescription { get; set; }

        [StringLength(100)]
        [Display(Name = "Category description")]
        public string CategoryDescription { get; set; }
        [Display(Name = "Saved by")]
        public string SaveBy { get; set; }
    }
}
