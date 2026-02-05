using FluentValidation;

namespace MelodyHub.Application.CQRS.Quizzes.Queries.GetQuizList;

public class QuizListQueryValidator
    : AbstractValidator<GetQuizListQuery>
{
    public QuizListQueryValidator()
    {
        
    }
}