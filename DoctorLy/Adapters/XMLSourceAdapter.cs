using DoctorLy.Base;
using DoctorLy.Importation;
using System;
using System.Collections.Generic;
using System.Data;

using System.Threading.Tasks;


namespace DoctorLy.Adapters
{
    public class XMLSourceAdapter : ISourceAdapter
    {
        public Guid ID { get; set; }
        public string AdapterName { get; set; }
        public string FilePath { get; set; }
        public List<IColumn> Fileds { get; set; }
         public List<string> PKs { get; set; }
        public IImportation transformator { get; set; }

        public DataTable GetDate()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(FilePath);
            DataTable dt = ds.Tables[0];

            

            return dt;

           
        }
    }
}
