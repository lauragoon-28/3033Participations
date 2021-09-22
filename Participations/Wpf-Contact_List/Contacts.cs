using System;
using System.Collections.Generic;
using System.Text;

namespace Wpf_Contact_List
{
    public class Contacts
    {
        public int id {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
        public string URL { get; set; }

        public Contacts()
        {
            id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            URL = string.Empty;
        }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}";
        }
    }
}
