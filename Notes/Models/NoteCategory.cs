namespace Notes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NoteCategory")]
    public partial class NoteCategory
    {
        [Key]
        public int NoteCategory_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }
    }
}
