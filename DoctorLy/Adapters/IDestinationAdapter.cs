using DoctorLy.Base;
using DoctorLy.Trafsformation;
using System.Collections.Generic;
using System.Data;
using DoctorLy.Sanitisation;

namespace DoctorLy.Adapters
{
    public interface IDestinationAdapter : IAdapter
    {
        ITransformation transformator { get; set; }

        ISanitisation sanitisation { get; set; }
        int Insert(DataTable dt, List<ColumnAssignment> ColumnAssignments);
        DataTable GetExistingDataWithPKs(DataTable dt, List<string> pKs);
    }
}