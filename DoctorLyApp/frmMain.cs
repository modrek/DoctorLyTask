using DoctorLy.Adapters;
using DoctorLy.Base;
using DoctorLy.Context;
using DoctorLy.Log;
using DoctorLy.Piplines;
using DoctorLyMigrat.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoctorLyApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void BtnStartMigrate_Click(object sender, EventArgs e)
        {


            // Source  Adapter
            //ISourceAdapter sourceAdapter = new SourceAdapterFactory().CreateAdapter(drpSourceType.SelectedValue.ToString());
            XMLSourceAdapter sourceAdapter =(XMLSourceAdapter) new SourceAdapterFactory().CreateAdapter("xml");
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

            eTLConfig.UploadData(new WinAppContext()
            {
                loger = new FileLoger()
            });



        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            // Source  Adapter

            XMLSourceAdapter sourceAdapter =(XMLSourceAdapter) new SourceAdapterFactory().CreateAdapter("xml");
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
                        .SetColumnAssignments(columnAssignments);

            DataTable dt =eTLConfig.PreviewData(new WinAppContext()
                        {
                            loger = new FileLoger()
                        });
            grdPreview.DataSource = dt;
 
        }

      
        private void frmMain_Load(object sender, EventArgs e)
        {

            PopulateSourceAdapter();


        }

        private void PopulateSourceAdapter()
        {
            ComboboxItem item = new ComboboxItem();
            item.Text = "XML File";
            item.Value = "xml";
            drpSourceType.Items.Add(item);

            item.Text = "Json File";
            item.Value = "json";
            drpSourceType.Items.Add(item);

            item.Text = "Excel File";
            item.Value = "excel";
            drpSourceType.Items.Add(item);

            item.Text = "SQL";
            item.Value = "sql";
            drpSourceType.Items.Add(item);

            item.Text = "API";
            item.Value = "api";
            drpSourceType.Items.Add(item);

            drpSourceType.SelectedIndex = 0;
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
