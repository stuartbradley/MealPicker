using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MealPicker.Domain;
using Microsoft.EntityFrameworkCore;

namespace MealPicker.Application.Interfaces
{
    public interface IContext
    {
        public int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<Meal> Meals { get; }

    }
}
