using DoctorLy.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorLy.Context
{
    public class WinAppContext : IDoctorlyContext
    {
        public override void Log(string Message)
        {
            loger.Log(Message);
        }
    }
}
