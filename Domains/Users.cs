using System;
using System.ComponentModel.DataAnnotations;
using Solo.Base;

namespace Solo.Domains
{
    public class Users 
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email {get;set;}
        public byte[] RowVersion { get; set; }

    }
}