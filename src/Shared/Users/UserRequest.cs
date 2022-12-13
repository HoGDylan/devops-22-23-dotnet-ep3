namespace Shared.Users
{
    public static class UserRequest
    {
        public class GetIndex
        {
            // Filter stuff here if you want to.
        }

        public class Create
        {
            public KlantDto.Create Klant;

            public UserDto.Create User { get; set; }
        }

            public class AllKlantenIndex
    {

    }
    public class AllAdminUsers
    {
        public List<AdminUserDto.Index> AdminUsers  {get; set;}
        public int Total { get; set;}
    }
    public class DetailKlant
    {
        public int KlantId { get; set; }
    }

    /*public class Create
    {
        public KlantDto.Create Klant { get; set; }
    }*/

    public class Edit
    {
        public int KlantId { get; set; }
        public KlantDto.Mutate Klant { get; set; }
    }
    }
}

