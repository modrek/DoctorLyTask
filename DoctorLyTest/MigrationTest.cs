using System;
using System.Collections.Generic;
using DoctorLy.Adapters;
using DoctorLy.Base;
using DoctorLy.Context;
using DoctorLy.Log;
using DoctorLy.Piplines;
using DoctorLyMigrat.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoctorLyTest
{
    [TestClass]
    public class MigrationTest
    {
        [TestMethod]
        public void TestUploadMethod()
        {
            // Source  Adapter
            XMLSourceAdapter sourceAdapter = new XMLSourceAdapter();
            sourceAdapter.ID = new Guid();
            sourceAdapter.AdapterName = "XMLCustomersAdapter";
            sourceAdapter.FilePath = @"D:\sample.xml";
            sourceAdapter.Fileds = new List<IColumn>() {
                            new XmlColumn(){InternalName="FirstName",ColumnType=ColumnTypes.String,ReadOnly=false },
                            new XmlColumn(){InternalName="LastName",ColumnType=ColumnTypes.String,ReadOnly=false },
                        };
       


            // Destination Adapter
            SQLDestinationAdapter destinationAdapter = new SQLDestinationAdapter();
            destinationAdapter.ID = new Guid();
            destinationAdapter.AdapterName = "SQLCustomersAdapter";
            destinationAdapter.ConnectionString = "Server=192.168.85.198;Database=DoctorlyDB;User Id=sa;Password=sa@123;";
            destinationAdapter.Fileds = new List<IColumn>(){
                            new SQLColumn(){InternalName="Col_FirstName",ColumnType=ColumnTypes.String,ReadOnly=false },
                            new SQLColumn(){InternalName="Col_LastName",ColumnType=ColumnTypes.String,ReadOnly=false },
                        };
            destinationAdapter.TableName = "Customers";


            // Pipeline
            PipelineAddOprator1 p1 = new PipelineAddOprator1();
            PipelineAddOprator2 p2 = new PipelineAddOprator2();
            p1.Successor = p2;
            destinationAdapter.Fileds[0].WriteDataPipeline = p1;


            //Maping
            //Mapping mapping = new Mapping(jsonSourceAdapter, sQLDestinationAdapter);

            List<ColumnAssignment> columnAssignments = ColumnAssignment.CreateMapingWithPrefix(sourceAdapter, "Col_");



            //ETL Config
            ETLConfig eTLConfig = new ETLConfig()
                        .SetSourceAdapter(sourceAdapter)
                        .SetDestinationAdapter(destinationAdapter)
                        .SetColumnAssignments(columnAssignments)
                        .SetConflictStrategyType(ConflictStrategyType.Ignore);

            bool result =eTLConfig.UploadData(new WinAppContext()
            {
                loger = new FileLoger()
            });

            Assert.AreEqual(true, result);

        }
    }
}
