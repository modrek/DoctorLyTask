using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DoctorLy.Base;
using DoctorLy.Importation;
using Newtonsoft.Json;

namespace DoctorLy.Adapters
{
    public class APISourceApdapter : ISourceAdapter
    {
        public string URL { get; set; }
        public List<IColumn> Fileds { get; set; }
        public string MothodType { get; set; }
        public Guid ID { get; set; }
        public string AdapterName { get; set; }
        public List<string> PKs { get; set; }
        public IImportation transformator { get; set; }

        public string PayloadData;


        public DataTable GetDate()
        {
            string result = CallAPI(URL, PayloadData);
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(result, (typeof(DataTable)));            
            return dt;
        }

        private static string CallAPI(string APIUrl, string Request)
        {

            HttpWebRequest request = (HttpWebRequest)
            WebRequest.Create(APIUrl); request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";

            byte[] postBytes = Encoding.UTF8.GetBytes(Request);

            request.ContentType = "application/json; charset=UTF-8";
            request.Accept = "application/json";
            request.ContentLength = postBytes.Length;
            Stream requestStream = request.GetRequestStream();

            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
            {
                return rdr.ReadToEnd();
            }
        }
    }
}
