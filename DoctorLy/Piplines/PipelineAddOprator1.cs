namespace DoctorLy.Piplines
{
    public class PipelineAddOprator1 : IPipelineOpratorBase
    {
        public IPipelineOpratorBase Successor { get; set; }

        public object ApplayOperator(object inputvalue)
        {

            if (Successor == null)
            {
                return inputvalue + " 1 ";
            }
            else
            {
                return Successor.ApplayOperator(inputvalue + " 1 ");
            }
        }
    }
}