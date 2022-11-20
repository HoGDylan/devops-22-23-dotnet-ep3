using Domain;
using Domain.Common;
using Domain.Users;
using Shared.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}