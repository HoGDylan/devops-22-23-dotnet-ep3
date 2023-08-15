using Domain.Users;
using Shared.Projects;
using System.Runtime.CompilerServices;

namespace Shared.Users;

public static class UserRequest
{
    public class AllKlantenIndex
    {

    }
    public class AllAdminUsers
    {
        public List<AdminUserDto.Index> AdminUsers { get; set; }
        public int Total { get; set; }
    }
    public class DetailKlant
    {
        public int KlantId { get; set; }
    }

    public class Create
    {
        public KlantDto.Mutate Klant { get; set; }
    }

    public class Edit
    {
        public int KlantId { get; set; }
        public KlantDto.Mutate Klant { get; set; }
    }
}