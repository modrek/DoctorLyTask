using DoctorLy.Base;
using System;
using System.Collections.Generic;

namespace DoctorLy.Adapters
{
    public interface IAdapter
    {
        Guid ID { get; set; }

        string AdapterName { get; set; }
     
        List<IColumn> Fileds { get;  set; }

       
    }
}