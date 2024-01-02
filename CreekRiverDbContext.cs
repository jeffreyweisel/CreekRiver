using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

public class CreekRiverDbContext : DbContext
{
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }

    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
        {
            new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
            new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
            new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
            new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7}
        });

        // seed data with campsites 
        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
{
        new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
        new Campsite {Id = 2, CampsiteTypeId = 2, Nickname = "Elm Hill RV Resort", ImageUrl="https://lh3.googleusercontent.com/p/AF1QipOc5jWvSu-c5HivEEko92dSYNGrgt6h530st5PR=s680-w680-h510"},
        new Campsite {Id = 3, CampsiteTypeId = 3, Nickname = "Howlin' Hill", ImageUrl="https://lh3.googleusercontent.com/p/AF1QipNZIU7CRgM0dPCGDIyuER2MhGVIItZSia1_JMSm=s680-w680-h510"},
        new Campsite {Id = 4, CampsiteTypeId = 4, Nickname = "Seven Points Campground", ImageUrl="https://lh3.googleusercontent.com/p/AF1QipPD7s8DPh_eDhLVFdUyU-jNLOyt4kMjdgw_VDyn=s680-w680-h510"},
        new Campsite {Id = 5, CampsiteTypeId = 1, Nickname = "Poole Knobs Campground", ImageUrl="https://lh3.googleusercontent.com/p/AF1QipN8QNJu1DsK_QvquRMhySRc3M3kF22gqW9-u24D=s680-w680-h510"},
        });

       // seed data with reservations
        modelBuilder.Entity<Reservation>().HasData(new Reservation[]
{
    new Reservation
    {
        Id = 1, 
        CampsiteId = 1,
        UserProfileId = 1, // Foreign key value linking to the UserProfile
        CheckinDate = DateTime.Now.AddDays(2),
        CheckoutDate = DateTime.Now.AddDays(9),
    }
});

        // seed data with user profiles
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
{
    new UserProfile
    {
        Id = 1, 
        FirstName = "John",
        LastName = "Lennon",
        Email = "john@example.com",
    }
});

    }
}
