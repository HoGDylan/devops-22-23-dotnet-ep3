﻿namespace Shared.Authentication
{
    public static class AuthenticationRequest
    {
        public class Login
        {
            public string UserName { get; set; }
            public string Password { get; set; }

        }
        public class Register
        {

        }

    }
}
