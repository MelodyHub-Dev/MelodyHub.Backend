using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MelodyHub.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.QuizQuestions.Queries.GetQuizQuestionList;

public class QuizQuestionListQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetQuizQuestionListQuery, QuizQuestionListVm>
{
    public async Task<QuizQuestionListVm> Handle(GetQuizQuestionListQuery request, CancellationToken cancellationToken)
    {
        var quizQuestions = await context.QuizQuestions
            .Where(x => x.QuizId == request.QuizId)
            .ProjectTo<QuizQuestionListLookupDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new QuizQuestionListVm { QuizQuestions = quizQuestions };
    }
}
