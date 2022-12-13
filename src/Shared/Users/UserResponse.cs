using System.Collections.Generic;

namespace Shared.Users
{
    public static class UserResponse
    {
        public class GetIndex
        {
            public List<UserDto.Index> Users { get; set; } = new();
        }

        public class Create
        {
            public string Auth0UserId { get; set; }
        }
            public class AllKlantenIndex
    {
        public List<KlantDto.Index> Klanten { get; set; } = new();
        public int Total { get; set; }
    }

    public class DetailKlant
    {
        public KlantDto.Detail Klant { get; set; }
    }

    public class Edit
    {
        public int Id { get; set; }
    }

    public class Create
    {
        public int Id { get; set; }
    }

    public class AllAdminsIndex
    {
        public List<AdminUserDto.Index> Admins { get; set; } = new();
        public int Total { get; set; }
    }
    }
}

