using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public bool IsAdmin { get; set; }
        public int DefaultTiffinTypeId { get; set; }
        public bool IsRegularBM { get; set; }
        public bool IsActive { get; set; }
    }

}
