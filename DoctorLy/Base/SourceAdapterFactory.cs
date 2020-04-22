using DoctorLy.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorLyMigrat.Base
{
    public class SourceAdapterFactory
    {
        public ISourceAdapter CreateAdapter(string type)
        {

            
            var ctype = Type.GetType("DoctorLy.Adapters." + type);
            var myObject = (ISourceAdapter)Activator.CreateInstance(ctype);
            return myObject;

            //ISourceAdapter sourceAdapter;
            //switch (type)
            //{
            //    case "XMLSourceAdapter":
            //        {
            //            sourceAdapter = new XMLSourceAdapter();
            //            break;
            //        }
            //    case "ExcelSourceAdapter":
            //        {
            //            sourceAdapter = new ExcelSourceAdapter();
            //            break;
            //        }
            //    case "JsonSourceAdapter":
            //        {
            //            sourceAdapter = new JsonSourceAdapter();
            //            break;
            //        }
            //    case "SQLSourceAdapter":
            //        {
            //            sourceAdapter = new SQLSourceAdapter ();
            //            break;
            //        }
            //    case "APISourceApdapter":
            //        {
            //            sourceAdapter = new APISourceApdapter();
            //            break;
            //        }


            //}

            //return sourceAdapter;

        }
    }
}
