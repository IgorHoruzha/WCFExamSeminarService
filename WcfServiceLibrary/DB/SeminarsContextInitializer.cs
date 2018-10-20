using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WcfServiceLibrary.DB
{
   
    class SeminarsContextInitializer : DropCreateDatabaseAlways<SeminarsContext>
    {
        protected override void Seed(SeminarsContext db)
        {
            Seminar[] seminars = new Seminar[]{
                new Seminar() { DateTime = new DateTime(2018, 10, 17),Theme="Theme1", MaxUsers=10 },
                new Seminar() { DateTime = new DateTime(2018, 10, 21),Theme="2", MaxUsers=2 },
                new Seminar() { DateTime = new DateTime(2018, 10, 19),Theme="Theme3", MaxUsers=30 },
                new Seminar() { DateTime = new DateTime(2018, 10, 20),Theme="Theme4", MaxUsers=40 },
                new Seminar() { DateTime = new DateTime(2018, 10, 21),Theme="Theme5", MaxUsers=50},
                new Seminar() { DateTime = new DateTime(2018, 10, 22),Theme="Theme6", MaxUsers=60},
                new Seminar() { DateTime = new DateTime(2018, 10, 22),Theme="Theme6", MaxUsers=70}
            };
         
            db.Seminars.AddRange(seminars);

            User[] users = new User[]
            {
                new User{Login="1", Password="1",Mail="1", Name="1",UserType= UserTypesEnum.Admin},
                new User{Login="2", Password="1",Mail="123@mail.com", Name="User2L",UserType= UserTypesEnum.Listener},
                new User{Login="3", Password="1",Mail="123@mail.com", Name="User3L",UserType= UserTypesEnum.Listener},
                new User{Login="4", Password="1",Mail="123@mail.com", Name="User4L",UserType= UserTypesEnum.Listener},
                new User{Login="5", Password="1",Mail="123@mail.com", Name="User5L",UserType= UserTypesEnum.Listener},
                new User{Login="5", Password="1",Mail="123@mail.com", Name="User5L",UserType= UserTypesEnum.Listener}
            };
            db.Users.AddRange(users);

            db.SaveChanges();
        }
    }
}
