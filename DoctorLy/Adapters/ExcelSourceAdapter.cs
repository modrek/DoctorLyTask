using DoctorLy.Base;
using DoctorLy.Importation;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorLy.Adapters
{
    public class ExcelSourceAdapter : ISourceAdapter
    {
        public string Filepath { get; set; }
        public List<IColumn> Fileds { get; set; }
        public string SheetName { get; set; }
        public Guid ID { get; set; }
        public string AdapterName { get; set; }
        public List<string> PKs { get; set; }
        public IImportation transformator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDate()
        {
            string fileExtension = "";
            FileStream stream = File.Open(Filepath, FileMode.Open, FileAccess.Read);
            fileExtension = System.IO.Path.GetExtension(Filepath);            
            IExcelDataReader excelReader;
            if (fileExtension.ToLower() == ".xls")
                excelReader = ExcelReaderFactory.CreateReader(stream);
            else
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            DataSet ds = excelReader.AsDataSet();
            DataTable dt = ds.Tables[SheetName];
            return dt;
        }
    }
}
