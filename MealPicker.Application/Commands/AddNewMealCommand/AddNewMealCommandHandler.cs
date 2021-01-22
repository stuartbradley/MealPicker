using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MealPicker.Application.Interfaces;
using MealPicker.Domain;
using MediatR;

namespace MealPicker.Application.Commands.AddNewMealCommand
{
    public class AddNewMealCommandHandler:IRequestHandler<AddNewMealCommand, Guid>
    {
        private readonly IContext _context;

        public AddNewMealCommandHandler(IContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(AddNewMealCommand request, CancellationToken cancellationToken)
        {
            Meal meal = new Meal(request.Name, request.Ingredients.ToList());
            await _context.Meals.AddAsync(meal, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return meal.Id;
        }
    }
}
