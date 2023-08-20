using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Shared.Models
{
    public class LoginModelX
    {
        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required, MinLength(8)]
        public string password { get; set; }
    }
}
