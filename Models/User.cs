using MyStore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class User
    {
        private readonly MyStoreContext _context;

        public User()
        {

        }

        public User(string token)
        {
            this.Token = token;
        }

        public User(long id)
        {
            this.Id = id;
        }

        public User(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }


        public long Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        public string Token { get; set; }
    }
}
