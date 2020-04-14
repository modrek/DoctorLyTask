using DoctorLy.Log;

namespace DoctorLy.Context
{
    public abstract class  IDoctorlyContext
    {
        public ILoger loger;
        public abstract void Log(string Message);
    }
}