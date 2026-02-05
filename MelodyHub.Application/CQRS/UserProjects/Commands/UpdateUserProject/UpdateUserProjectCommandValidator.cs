using FluentValidation;
using MelodyHub.Domain.Enums;

namespace MelodyHub.Application.CQRS.UserProjects.Commands.UpdateUserProject;

public class UpdateUserProjectCommandValidator
    : AbstractValidator<UpdateUserProjectCommand>
{
    public UpdateUserProjectCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Project ID is required")
            .NotEqual(Guid.Empty).WithMessage("Invalid project ID");

        RuleFor(x => x.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Project name is required")
            .MaximumLength(200).WithMessage("Project name must not exceed 200 characters")
            .MinimumLength(2).WithMessage("Project name must be at least 2 characters long")
            .Matches(@"^[a-zA-Zа-яА-Я0-9\s\-_&.,'()/]+$")
            .WithMessage("Project name contains invalid characters");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(2000).WithMessage("Description must not exceed 2000 characters")
            .MinimumLength(10).WithMessage("Description must be at least 10 characters long");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid project status")
            .Must(status => status != ProjectStatus.Planned)
            .WithMessage("Existing project cannot have Planned status")
            .When(x => x.Status == ProjectStatus.Planned);

        RuleFor(x => x.Progress)
            .InclusiveBetween((byte)0, (byte)100).WithMessage("Progress must be between 0 and 100 percent");

        RuleFor(x => x.StartDate)
            .NotNull().WithMessage("Start date is required")
            .Must(date => date >= DateOnly.FromDateTime(DateTime.Today.AddYears(-5)))
            .WithMessage("Start date cannot be older than 5 years")
            .Must(date => date <= DateOnly.FromDateTime(DateTime.Today.AddYears(1)))
            .WithMessage("Start date cannot be more than 1 year in the future");

        RuleFor(x => x.FinishDate)
            .NotNull().WithMessage("Finish date is required")
            .When(x => x.Status == ProjectStatus.Completed)
            .WithMessage("Finish date is required for completed projects")
            .GreaterThan(x => x.StartDate!.Value)
            .WithMessage("Finish date must be after start date")
            .When(x => x.StartDate.HasValue);

        RuleFor(x => x.ActualCost)
            .NotNull().WithMessage("Actual cost is required")
            .GreaterThan(0).WithMessage("Actual cost must be positive")
            .LessThanOrEqualTo(1000000).WithMessage("Actual cost must not exceed 1,000,000")
            .Must(cost => decimal.Round(cost!.Value, 2) == cost.Value)
            .WithMessage("Actual cost must have at most 2 decimal places");

        RuleFor(x => x.Notes)
            .NotEmpty().WithMessage("Notes are required")
            .MaximumLength(1000).WithMessage("Notes must not exceed 1000 characters");
    }
}