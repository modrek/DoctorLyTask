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
            ISourceAdapter sourceAdapter = null;
            switch (type)
            {
                case "xml":
                    {
                        sourceAdapter = new XMLSourceAdapter();
                        break;
                    }
                case "excel":
                    {
                        sourceAdapter = new ExcelSourceAdapter();
                        break;
                    }
                case "json":
                    {
                        sourceAdapter = new JsonSourceAdapter();
                        break;
                    }
                case "sql":
                    {
                        sourceAdapter = new SQLSourceAdapter ();
                        break;
                    }
                case "api":
                    {
                        sourceAdapter = new APISourceApdapter();
                        break;
                    }


            }

            return sourceAdapter;

        }
    }
}
