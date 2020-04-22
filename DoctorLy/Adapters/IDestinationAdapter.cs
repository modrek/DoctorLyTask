using DoctorLy.Base;
using DoctorLy.Trafsformation;
using System.Collections.Generic;
using System.Data;
using DoctorLy.Sanitisation;

namespace DoctorLy.Adapters
{
    public interface IDestinationAdapter : IAdapter
    {
        /// <summary>
        /// 
        /// </summary>
        ITransformation transformator { get; set; }
        /// <summary>
        /// 
        /// </summary>
        ISanitisation sanitisation { get; set; }
        int Insert(DataTable dt, List<ColumnAssignment> ColumnAssignments);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="pKs"></param>
        /// <returns></returns>
        DataTable GetExistingDataWithPKs(DataTable dt, List<string> pKs);
    }
}