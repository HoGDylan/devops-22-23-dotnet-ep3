namespace Shared.Authentication
{
    public static class AuthenticationResponse
    {
        public static class Login
        {
            public class Any { }
            public class Failed : Any
            {

            }

            public class Success : Any
            {

            }
        }

        public static class Register
        {
            public class Any { }
            public class Failed : Any
            {

            }
            public class Success : Any
            {

            }
        }

    }
}
