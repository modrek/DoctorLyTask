using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorLy.Base;
using DoctorLy.Importation;

namespace DoctorLy.Adapters
{
    public class CollectionFileSourceAdapter : ISourceAdapter
    {
        public IImportation transformator { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<string> PKs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string AdapterName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IColumn> Fileds { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        string FileExtention;
        int QtyGetFilePerRequest;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDate()
        {
            throw new NotImplementedException();
        }
    }
}
