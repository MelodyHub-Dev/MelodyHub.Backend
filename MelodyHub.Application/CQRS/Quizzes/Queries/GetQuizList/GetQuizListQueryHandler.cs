using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MelodyHub.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.Quizzes.Queries.GetQuizList;

public class GetQuizListQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetQuizListQuery, QuizListVm>
{
    public async Task<QuizListVm> Handle(GetQuizListQuery request, CancellationToken cancellationToken)
    {
        var quizzes = await context.Quizzes
            .ProjectTo<QuizListLookupDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new QuizListVm { Quizzes = quizzes };
    }
}
