using DoctorLy.Piplines;

namespace DoctorLy.Base
{
    public abstract class IColumn
    {
        public string InternalName { get; set; }
        public bool ReadOnly{ get; set; }
        public ColumnTypes ColumnType { get;  set; }

        public IPipelineOpratorBase ReadDataPipeline { get;  set; }
        public IPipelineOpratorBase WriteDataPipeline { get;  set; }
    }
}