using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfakimAPI.Models
{
    public class UserEntity
    {
        public int? Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }

    }

    public enum Gender
    {
        Male = 0,
        Female = 1
    }
}