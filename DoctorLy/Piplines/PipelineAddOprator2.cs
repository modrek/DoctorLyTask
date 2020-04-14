namespace DoctorLy.Piplines
{
    public class PipelineAddOprator2 : IPipelineOpratorBase
    {
        public IPipelineOpratorBase Successor { get; set; }

        public object ApplayOperator(object inputvalue)
        {
            
            if (Successor==null)
            {
                return inputvalue + " 2 ";
            }
            else
            {
                return Successor.ApplayOperator(inputvalue + " 2 ");
            }
        }
    }
}