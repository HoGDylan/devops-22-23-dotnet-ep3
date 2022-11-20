using Domain.Common;
using Domain.Users;
using FluentValidation;
using Shared.Projects;


namespace Shared.Users;

public static class KlantDto
{

    public class Index
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class Detail : Index
    {
        public string? Bedrijf { get; set; }
        public Course? Opleiding { get; set; }
        public List<ProjectDto.Index> Projects { get; set; }
        public ContactDetails? contactPersoon { get; set; }
        public ContactDetails? ReserveContactPersoon { get; set; }
    }

    public class Mutate
    {
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Course? Opleiding { get; set; }
        public string? Bedrijf { get; set; }


        public class Validator : AbstractValidator<Mutate>
        {
            public Validator()
            {
                RuleFor(x => x.FirstName).NotEmpty().Length(1, 250);
                RuleFor(x => x.Name).NotEmpty().Length(1, 250);
                RuleFor(x => x.PhoneNumber).NotEmpty();
                RuleFor(x => x.Email).NotEmpty().Length(1, 250);
            }
        }
    }
}