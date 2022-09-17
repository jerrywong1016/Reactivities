using System;
using System.Collections.Generic;
using Domain;
using MediatR;
using Persistence;
using static Application.Activities.Details;

namespace Application.Activities
{
    public class Details
    {
        //Query is used to fetch data
        public class Query : IRequest<Activity>{
            public Guid Id {get; set;}
        }
    }

    public class Handler : IRequestHandler<Query, Activity>
    {  
        private readonly DataContext _context;

        public Handler(DataContext context){
            _context = context;
        }
        public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.Activities.FindAsync(request.Id);
            //error here need to be fixed
        }

    }
}