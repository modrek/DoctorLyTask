using DoctorLy.Base;
using DoctorLy.Sanitisation;
using DoctorLy.Trafsformation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DoctorLy.Adapters
{
    public class SQLDestinationAdapter : IDestinationAdapter
    {
        public Guid ID { get; set; }
        public string AdapterName { get; set; }
       
        public string ConnectionString { get; set; }
        public List<IColumn> Fileds { get; set; }
        public string TableName { get; set; }
        public ITransformation transformator { get; set; }
        public ISanitisation sanitisation { get; set; }

        public DataTable GetExistingDataWithPKs(DataTable dt, List<string> pKs)
        {
            throw new NotImplementedException();
        }

        public int Insert(DataTable _dt , List<ColumnAssignment> ColumnAssignments)
        {
           
            
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand($@"insert into {TableName} ({string.Join(",", ColumnAssignments.Select(x => x.ToColumn.InternalName))}) values 
                                            (@{string.Join(",@", ColumnAssignments.Select(x => x.ToColumn.InternalName))})", conn);
            conn.Open();
            int Result = 0;
            foreach (DataRow r in _dt.Rows)
            {
                foreach (var ColumnAssignment in ColumnAssignments)
                {
                    object value = r[ColumnAssignment.FromColumn.InternalName];
                    IColumn column = Fileds.Where(x => x.InternalName == ColumnAssignment.ToColumn.InternalName).FirstOrDefault();

                    if (column.WriteDataPipeline != null)
                        value = column.WriteDataPipeline.ApplayOperator(value);

                    if(!cmd.Parameters.Contains("@" + ColumnAssignment.ToColumn.InternalName))
                        cmd.Parameters.Add("@"+ ColumnAssignment.ToColumn.InternalName, SqlDbType.Text);
                    cmd.Parameters["@" + ColumnAssignment.ToColumn.InternalName].Value = value;

                }

                Result += cmd.ExecuteNonQuery();
            }

            conn.Close();

            sanitisation?.Apply();

            return Result;
        }
    }
}