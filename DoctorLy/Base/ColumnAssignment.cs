using DoctorLy.Adapters;
using System.Collections.Generic;

namespace DoctorLy.Base
{
    public class ColumnAssignment
    {
        public IColumn FromColumn { get; set; }
        public IColumn ToColumn { get; set; }

        /// <summary>
        /// Impeletemt Mirror mapping when source and destination have similar columns
        /// </summary>
        /// <param name="SourceAdapter"></param>
        /// <returns></returns>
        public static List<ColumnAssignment> CreateMirroMaping(ISourceAdapter SourceAdapter )
        {
            List<ColumnAssignment> result = new List<ColumnAssignment>();

            foreach (var col in SourceAdapter.Fileds)
            {
                var columnAssignment = new ColumnAssignment()
                {
                    FromColumn = new SimpleMapColumn()
                    {
                        InternalName = col.InternalName,
                        ReadOnly = false
                    },
                    ToColumn = new SimpleMapColumn()
                    {
                        InternalName = col.InternalName,
                        ReadOnly = false
                    }
                };

                result.Add(columnAssignment);
            }

            return result;
        }
        /// <summary>
        /// Impeletemt Mirror mapping when destination columns similar ro source columns + prefix (for example)
        /// </summary>
        /// <param name="SourceAdapter"></param>
        /// <param name="Prefix"></param>
        /// <returns></returns>
        public static List<ColumnAssignment> CreateMapingWithPrefix(ISourceAdapter SourceAdapter, string Prefix )
        {
            List<ColumnAssignment> result = new List<ColumnAssignment>();

            foreach (var col in SourceAdapter.Fileds)
            {
                var columnAssignment = new ColumnAssignment()
                {
                    FromColumn = new SimpleMapColumn()
                    {
                        InternalName = col.InternalName,
                        ReadOnly = false
                    },
                    ToColumn = new SimpleMapColumn()
                    {
                        InternalName = Prefix + col.InternalName,
                        ReadOnly = false
                    }
                };

                result.Add(columnAssignment);
            }

            return result;
        }

        /// implement multiple columns Mapping  methods


    }
}