using DoctorLy.Importation;
using System.Collections.Generic;
using System.Data;

namespace DoctorLy.Adapters
{
    public interface ISourceAdapter :IAdapter
    {
        IImportation transformator { get; set; }
        List<string> PKs { get; set; }
        DataTable GetDate();
        
    }
}