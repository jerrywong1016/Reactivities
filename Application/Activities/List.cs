using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using System.Threading.Tasks;
using MediatR;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>>{

        }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            private readonly ILogger<List> _logger;
            public Handler(DataContext context, ILogger<List> logger){
                _context = context;
                _logger = logger;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                try{
                    for(int i = 0; i < 10; i++){
                        cancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(1000, cancellationToken);
                        _logger.LogInformation($"Task {i} has completed");
                    }
                }catch(Exception ex) when (ex is TaskCanceledException){ //ex: when user cancel the request or close the brower, log the error
                    _logger.LogInformation("Task was incompleted");
                }

                return await _context.Activities.ToListAsync(cancellationToken);

            }
        }
    }
}