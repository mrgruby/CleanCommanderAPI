using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Queries.FindCommand
{
    public class FindCommandQuery : IRequest<List<FindCommandReturnModel>>
    {
        public string SearchTerm { get; set; }
    }
}
