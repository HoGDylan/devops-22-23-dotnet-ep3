using Domain.Common;
using Domain.Users;
using Domain.Utility;
using Domain.Utility;
using FluentValidation;
using Shared.Projects;
using System.ComponentModel.DataAnnotations;

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
      //  [Required(ErrorMessage = "Je moet een voornaam ingeven.")]
      //  [StringLength(20, ErrorMessage = "Naam is te lang")]
        public string FirstName { get; set; }
       // [Required(ErrorMessage = "Je moet een naam ingeven.")]
        public string Name { get; set; }
       // [Required(ErrorMessage = "Je moet een gsm-nummer ingeven.")]
        public string PhoneNumber { get; set; }
        //[Required(ErrorMessage = "Je moet een email ingeven.")]
        public string Email { get; set; }
        public Course? Opleiding { get; set; }
        public string? Bedrijf { get; set; }
        public ContactDetails? contactPersoon { get; set; }
        public ContactDetails? ReserveContactPersoon { get; set; }

        public class Validator : AbstractValidator<Mutate>
        {
            public Validator()
            {
                RuleFor(x => x.FirstName).NotNull().NotEmpty().Length(1, 250);
                RuleFor(x => x.Name).NotNull().NotEmpty().Length(1, 250);
                RuleFor(x => PropertyValidator.IsValidEmail(x.Email));
                RuleFor(x => PropertyValidator.IsPhoneNumberValid(x.PhoneNumber));
                RuleFor(x => x.Opleiding).NotEmpty();
                RuleFor(x => x.Bedrijf).NotEmpty();
            }
        }
    }
}