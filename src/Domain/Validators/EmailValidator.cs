using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators
{
    public class EmailValidator
    {

        public static bool ValidEmail(string mail)
        {
            if (mail == null) throw new ArgumentException("Email can't be null");
            if (!mail.Contains("@")) throw new ArgumentException("Invalid Email");
            if (mail.Split("@")[0].Length == 0) throw new ArgumentException("Email has no prefix");
            if (mail.Split("@")[1].Length == 0) throw new ArgumentException("Email has nu suffix");
            if (!mail.Split("@")[1].Contains(".")) throw new ArgumentException("Email has no suffix");
            if (mail.Split("@")[1].Split(".")[1].Length < 2) throw new ArgumentException("Email suffix length must be 2 or larger");

            return true;
        }



    }

}

/*
       //School email
       if (mail_to_lower.Split("@")[1].Equals("student.hogent.be") || mail_to_lower.Split("@")[1].Equals("hogent.be") && (mail_to_lower.Split("@")[0].Contains("."))) {
           EmailAdress = mail;
       }*/