using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command: IRequest{ //Irequest is part of the mediatR
            public Activity Activity {get; set;}
        }

        public class Handler : IRequestHandler<Command>{
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper){
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Activity.Id);

                _mapper.Map(request.Activity, activity); //mapper, doing the same thing as blow

                // activity.Title = request.Activity.Title ?? activity.Title; //updating the object

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}