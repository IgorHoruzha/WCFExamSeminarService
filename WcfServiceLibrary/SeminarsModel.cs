using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary.DB;

namespace WcfServiceLibrary
{
    static class SeminarsModel
    {
        public static SeminarsContext SeminarsContext { get; set; }
        static SeminarsModel()
        {
             SeminarsContext = new SeminarsContext();
             SeminarsContext.Database.Initialize(true);
        }
    }
}
