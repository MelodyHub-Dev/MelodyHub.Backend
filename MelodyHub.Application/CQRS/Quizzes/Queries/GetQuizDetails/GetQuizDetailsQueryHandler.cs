using AutoMapper;
using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.Quizzes.Queries.GetQuizDetails;

public class GetQuizDetailsQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetQuizDetailsQuery, QuizDetailsVm>
{
    public async Task<QuizDetailsVm> Handle(GetQuizDetailsQuery request, CancellationToken cancellationToken)
    {
        var quiz = await context.Quizzes
            .Include(q => q.Questions)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Quiz), request.Id);

        return mapper.Map<QuizDetailsVm>(quiz);
    }
}
