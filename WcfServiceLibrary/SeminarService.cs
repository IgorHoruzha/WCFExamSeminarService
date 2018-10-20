using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary.DB;


namespace WcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class SeminarService : ISeminarService
    {
      
        public SeminarService()
        {
          
        }
        public List<Seminar> GetSeminars(User user)
        {
            Console.WriteLine("1232");
                if (_isAdmin(user))
                {
                    var a = SeminarsModel.SeminarsContext.Seminars.ToList();
                    return a;
                }
            return SeminarsModel.SeminarsContext.Seminars.Where((s) => s.DateTime > DateTime.Now).ToList<Seminar>();
        }
        public List<Seminar> GetUserSeminars(User user)
        {
            User curentUser = SeminarsModel.SeminarsContext.Users.FirstOrDefault<User>((u) => u.Login == user.Login && u.Password == user.Password && u.UserType == user.UserType);
            if (curentUser!=null)
            {
                return curentUser.Seminars;
            }
            return null;          
        }
        public List<User> GetRegisteredUsers(Seminar seminar)
        {
            var currSeminar = SeminarsModel.SeminarsContext.Seminars.First((s) => s.Id == seminar.Id && s.DateTime == seminar.DateTime && s.MaxUsers == seminar.MaxUsers && s.Theme == seminar.Theme);
            if (currSeminar!=null)
            {
                return currSeminar.Users;
            }

            return null;
        }


        public RegestrationStatusEnum RegisterForSeminar(User user, Seminar seminar)
        {

            User curentUser = SeminarsModel.SeminarsContext.Users.FirstOrDefault<User>((u) => u.Login == user.Login && u.Password == user.Password && u.UserType == user.UserType);

            if (curentUser!=null)
            {
                var currSeminar = SeminarsModel.SeminarsContext.Seminars.FirstOrDefault((s) => s.Id == seminar.Id && s.DateTime == seminar.DateTime && s.MaxUsers == seminar.MaxUsers && s.Theme == seminar.Theme);
                if (currSeminar!=null)
                {
                    SeminarsModel.SeminarsContext.Seminars.Load();
               
                    if (currSeminar.DateTime>DateTime.Now)
                    {
                      
                        if (currSeminar.MaxUsers> currSeminar.Users.Count)
                        {
                            if (!currSeminar.Users.Any((u)=>u.Name==user.Name&&u.Password==user.Password))
                            {                             
                                currSeminar.Users.Add(curentUser);
                                SeminarsModel.SeminarsContext.SaveChanges();
                                return RegestrationStatusEnum.Success;
                            }

                            return RegestrationStatusEnum.ReRegistration;
                        }

                        return RegestrationStatusEnum.NoFreePlaces;
                    }
                    return RegestrationStatusEnum.RegistrationTimeOut;
                }
                return RegestrationStatusEnum.SeminarNotFound;
            }
            return RegestrationStatusEnum.UserNotFound;
        }

        private bool _isSeminarExists(Seminar seminar)
        {
            if (SeminarsModel.SeminarsContext.Seminars.Any((s)=>s.Id==seminar.Id&&s.DateTime==seminar.DateTime&&s.MaxUsers==seminar.MaxUsers&&s.Theme==seminar.Theme))
            {
                return true;  
            }
            return false;
        }

        private bool _isRegisteredUser(User user)
        {
            if (SeminarsModel.SeminarsContext.Users.Any((u) =>
                u.Login == user.Login && u.Password == user.Password && u.UserType == user.UserType))
            {
                return true;
            }
            return false;
        }

        private bool _isAdmin(User user)
        {
            if (SeminarsModel.SeminarsContext.Users.Any((u) =>
                u.Login == user.Login && u.Password == user.Password && u.UserType == UserTypesEnum.Admin))
            {
                return true;
            }
            return false;
        }
        public string GetData(int value)
        {

            Console.WriteLine(1);
            return string.Format("You entered: {0}", value);
        }


      

       
    }
}
