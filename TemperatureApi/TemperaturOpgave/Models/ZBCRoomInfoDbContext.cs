using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TemperaturOpgave.Models
{
    public partial class ZBCRoomInfoDbContext : DbContext
    {
        public ZBCRoomInfoDbContext()
        {
        }

        public ZBCRoomInfoDbContext(DbContextOptions<ZBCRoomInfoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomTemperature> RoomTemperatures { get; set; }
        public virtual DbSet<Temperature> Temperatures { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=ZBCRoomInfoDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Danish_Norwegian_CI_AS");

            modelBuilder.Entity<RoomTemperature>(entity =>
            {
                entity.HasIndex(e => e.RoomId, "IX_RoomTemperatures_RoomId");

                entity.HasIndex(e => e.TemperatureId, "IX_RoomTemperatures_TemperatureId");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomTemperatures)
                    .HasForeignKey(d => d.RoomId);

                entity.HasOne(d => d.Temperature)
                    .WithMany(p => p.RoomTemperatures)
                    .HasForeignKey(d => d.TemperatureId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Salt)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRoles__RoleI__619B8048");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRoles__UserI__628FA481");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
