using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary.DB
{
   public class Seminar
    {
        [DataMember]
        public int Id { get; set; } 
        [DataMember]
        public string Theme { get; set; }
        [DataMember]
        public DateTime DateTime { get; set; }
        [DataMember]
        public int MaxUsers { get; set; }

        public bool IsUsersNotified { get; set; }

        public List<User> Users { get; set; }
        public Seminar()
        {
            IsUsersNotified = false;
            this.Users = new List<User>();
        }

    }
}
