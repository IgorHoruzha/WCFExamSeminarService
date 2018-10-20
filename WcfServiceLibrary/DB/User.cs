using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary.DB
{
   public class User
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Mail { get; set; }
        [DataMember]
        public UserTypesEnum UserType { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public List<Seminar> Seminars { get; set; }
        public User()
        {
            this.Seminars = new List<Seminar>();
        }

    }
}
