using DoctorLy.Importation;
using System.Collections.Generic;
using System.Data;

namespace DoctorLy.Adapters
{
    public interface ISourceAdapter :IAdapter
    {
        /// <summary>
        /// 
        /// </summary>
        IImportation transformator { get; set; }
        /// <summary>
        /// 
        /// </summary>
        List<string> PKs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DataTable GetDate();
        
    }
}