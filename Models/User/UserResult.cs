using System;

namespace Solo.Models
{
    public class UserResult 
    {
        public int Id {get;set;}
        public string UserName {get;set;}
        public DateTime BirthDate {get;set;}
        public byte[] RowVersion {get;set;}
    }
}