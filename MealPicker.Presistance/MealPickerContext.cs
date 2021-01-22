using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealPicker.Application.Interfaces;
using MealPicker.Domain;
using Microsoft.EntityFrameworkCore;

namespace MealPicker.Presistance
{
    public class MealPickerContext : DbContext, IContext
    {
        public MealPickerContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>(x =>
            {
                x.ToTable("Meals");
                x.HasKey(x => x.Id);
                x.Property(x => x.Name)
                    .HasColumnName("Name")
                    .IsRequired();
                x.HasMany(x => x.Ingredients);
            });
            modelBuilder.Entity<Ingredient>(x =>
            {
                x.ToTable("Ingredients");
                x.HasKey(x => x.Id);
                x.Property(x => x.Name)
                    .HasColumnName("Name");
            });
        }


        public DbSet<Meal> Meals { get; set; }

    }
}
