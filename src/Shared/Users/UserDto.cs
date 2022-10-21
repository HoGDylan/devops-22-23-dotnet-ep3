namespace Users.Shared
{
    public static class UserDto
    {
        public class Index
        {
            public string name { get; set; }
            public string phoneNumber { get; set; }
            public string email { get; set; }
            public bool password { get; set; }

            //public AdminRole role { get; set; }
        }

        public class Create
        {
            public string name { get; set; }
            public string phoneNumber { get; set; }
            public string email { get; set; }
            public bool password { get; set; }

            //public AdminRole role { get; set; }
        }

    }
}