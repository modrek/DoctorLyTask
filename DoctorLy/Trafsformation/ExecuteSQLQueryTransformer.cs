using DoctorLy.Trafsformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorLyMigrat.Trafsformation
{
    class ExecuteSQLQueryTransformer : ITransformation
    {        
        public int BachSize;
        public bool RunInTransaction;

        public void Apply()
        {
            throw new NotImplementedException();
        }
    }
}
