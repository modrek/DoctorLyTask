using DoctorLy.Base;
using DoctorLy.Importation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorLy.Adapters
{
    public class JsonSourceAdapter: ISourceAdapter
    {
        public Guid ID { get; set; }
        public string AdapterName { get; set; }
        public string FilePath { get; set; }
        public List<IColumn> Fileds { get; set; }
       
        public List<string> PKs { get; set; }
        public IImportation transformator { get; set; }

        public DataTable GetDate()
        {
            using (StreamReader r = new StreamReader(FilePath))
            {
                string json = r.ReadToEnd();
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
                return dt;

            }

     


        }
    }
}
