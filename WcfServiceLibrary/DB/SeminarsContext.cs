namespace WcfServiceLibrary.DB
{
    using System;
    using System.Data.Entity;
    using System.Linq;


    public class SeminarsContext : DbContext
    {

        static SeminarsContext()
        {
           Database.SetInitializer<SeminarsContext>(new SeminarsContextInitializer());
            
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //    //modelBuilder.Entity<User>()
        //    //    .HasMany<Seminar>(s => s.Seminars)
        //    //    .WithMany(c => c.Users)
        //    //    .Map(cs =>
        //    //    {
        //    //        cs.MapLeftKey("StudentRefId");
        //    //        cs.MapRightKey("CourseRefId");
        //    //        cs.ToTable("StudentCourse");
        //    //    });

        //}
        public SeminarsContext()
            : base("name=SeminarsModel1")
        {
         //   Database.SetInitializer<SeminarsContext>(new SeminarsContextInitializer());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Seminar> Seminars { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}