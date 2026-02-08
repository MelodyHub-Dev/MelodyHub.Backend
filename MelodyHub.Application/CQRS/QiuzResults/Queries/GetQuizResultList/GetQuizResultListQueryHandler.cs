using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.QiuzResults.Queries.GetQuizResultList;

public class GetQuizResultListQueryHandler(IMelodyHubDbContext context, IMapper mapper)
    : IRequestHandler<GetQuizResultListQuery, QuizResultListVm>
{
    public async Task<QuizResultListVm> Handle(GetQuizResultListQuery request, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .FindAsync([request.UserId], cancellationToken) 
            ?? throw new NotFoundException(nameof(User), request.UserId);

        var quizResults = await context.QuizResults
            .Where(x => x.UserId == request.UserId)
            .ProjectTo < QuizResultListLookupDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new QuizResultListVm { QuizResults = quizResults };
    }
}
