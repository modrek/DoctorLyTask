namespace DoctorLy.Piplines
{
    public interface IPipelineOpratorBase
    {
        object ApplayOperator(object inputvalue);
        IPipelineOpratorBase Successor { get; set; } 

    }
}