using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary.DB;

namespace WcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ISeminarService
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        List<Seminar> GetSeminars(User user);
        [OperationContract]
        List<User> GetRegisteredUsers(Seminar seminar);
        [OperationContract]
        List<Seminar> GetUserSeminars(User user);
        [OperationContract]
        RegestrationStatusEnum RegisterForSeminar(User user, Seminar seminar);

   

        // TODO: Add your service operations here
    }

    
}
