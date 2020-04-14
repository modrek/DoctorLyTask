using DoctorLy.Adapters;
using DoctorLy.Context;
using DoctorLyMigrat.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorLy.Base
{
    public class ETLConfig 
    {
        private ISourceAdapter _sourceAdapter;
        private IDestinationAdapter _destinationAdapter;
        private List<ColumnAssignment> _columnAssignments;
        private ConflictStrategyType _conflictStrategyType;

        public ETLConfig()
        {
            
        }

        public ETLConfig SetSourceAdapter(ISourceAdapter SourceAdapter)
        {
            _sourceAdapter = SourceAdapter;
            return this;
        }

        public ETLConfig SetDestinationAdapter(IDestinationAdapter DestinationAdapter)
        {
            _destinationAdapter = DestinationAdapter;
            return this;
        }

        public ETLConfig SetColumnAssignments(List<ColumnAssignment> columnAssignments)
        {
            _columnAssignments = columnAssignments;
            return this;
        }

        public ETLConfig SetConflictStrategyType(ConflictStrategyType conflictStrategyType)
        {
            _conflictStrategyType = conflictStrategyType;
            return this;
        }

        private void Rollback()
        {

        }

        private void ResolveConfilict(ConflictStrategyType conflictStrategyType)
        {
            switch (conflictStrategyType)
            {
                case ConflictStrategyType.CommitAndError:
                    {
                        break;
                    }
                case ConflictStrategyType.Ignore:
                    {
                        break;
                    }
                case ConflictStrategyType.Replace:
                    {
                        break;
                    }

                case ConflictStrategyType.RolbackAndError:
                    {
                        break;
                    }


            }

        }

        public bool UploadData(IDoctorlyContext context)
        {
            
            int result = 0;
            context.loger?.Log($@"Start migration from {_sourceAdapter.AdapterName} Adapter into {_destinationAdapter.AdapterName} at {DateTime.Now}" );

            try
            {
                DataTable dt = _sourceAdapter.GetDate();
                if (_sourceAdapter.PKs!=null &&_sourceAdapter.PKs.Count > 0)
                {
                    DataTable duplicatePKsDataTable = _destinationAdapter.GetExistingDataWithPKs(dt, _sourceAdapter.PKs);
                    if (duplicatePKsDataTable.Rows.Count>0)
                    {
                        ResolveConfilict(_conflictStrategyType);
                    }
                }


                result = _destinationAdapter.Insert(dt, _columnAssignments);
            }
            catch (Exception ex)
            {

                context.loger?.Log($@"Error on migrate from {_sourceAdapter.AdapterName} Adapter into {_destinationAdapter.AdapterName} at {DateTime.Now}
                                Error : {ex.Message}");
                Rollback();
                return false;

            }

            context.loger?.Log($@"Finish migration from {_sourceAdapter.AdapterName} Adapter into {_destinationAdapter.AdapterName} at {DateTime.Now}");

            return Convert.ToBoolean( result);
        }

        public DataTable PreviewData(IDoctorlyContext context)
        {
            int result = 0;
            context.loger?.Log($@"Start migration from {_sourceAdapter.AdapterName} Adapter into {_destinationAdapter.AdapterName} at {DateTime.Now}");

            try
            {
                return _sourceAdapter.GetDate();
                
            }
            catch (Exception ex)
            {

                context.loger?.Log($@"Error on migrate from {_sourceAdapter.AdapterName} Adapter  into {_destinationAdapter.AdapterName} at {DateTime.Now}
                                Error : {ex.Message}");
                Rollback();
                return null;

            }

  
        }
    }
}
