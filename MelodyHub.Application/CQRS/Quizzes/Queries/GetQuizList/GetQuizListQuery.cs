using MediatR;

namespace MelodyHub.Application.CQRS.Quizzes.Queries.GetQuizList;

public class GetQuizListQuery : IRequest<QuizListVm>
{}
