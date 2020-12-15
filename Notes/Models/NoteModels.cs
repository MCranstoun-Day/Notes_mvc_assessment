namespace Notes.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NoteModels : DbContext
    {
        public NoteModels()
            : base("name=NoteModels")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<NoteCategory> NoteCategories { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<ViewNote> ViewNotes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<NoteCategory>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Note>()
                .Property(e => e.NoteDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ViewNote>()
                .Property(e => e.NoteDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ViewNote>()
                .Property(e => e.CategoryDescription)
                .IsUnicode(false);
        }
    }
}
