using System;

namespace KTGiuaKi.Controllers
{
    internal class MydataDataContext
    {
        internal object SinhViens;

        public MydataDataContext()
        {
        }

        public object Sinhvien { get; internal set; }
        public object SinhVien { get; internal set; }

        internal void SubmitChanges()
        {
            throw new NotImplementedException();
        }

        internal object SinhVien(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}