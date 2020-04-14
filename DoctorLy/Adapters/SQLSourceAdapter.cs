using DoctorLy.Base;
using DoctorLy.Importation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DoctorLy.Adapters
{
    public class SQLSourceAdapter : ISourceAdapter
    {
        public Guid ID { get; set; }
        public string AdapterName { get; set; }

        public string ConnectionString { get;  set; }
        public List<IColumn> Fileds { get; set; } = new List<IColumn>();
        public string TableName { get; set; }

        public List<string> PKs { get; set; }
        public IImportation transformator { get; set; }

        public DataTable GetDate()
        {
            
            string ReadQuery = $@"select {string.Join(",", Fileds.Select(x => x.InternalName))} from {TableName}";

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(ReadQuery, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable Result = new DataTable();
            da.Fill(Result);
            conn.Close();
            da.Dispose();


            return Result;
        }
    }
}