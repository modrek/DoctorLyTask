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

            XMLSourceAdapter sourceAdapter =(XMLSourceAdapter) new SourceAdapterFactory().CreateAdapter(drpSourceType.SelectedValue.ToString());
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
           

            var type = typeof(ISourceAdapter);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p))
                .Select(x => new { Name = x.Name }).ToList();


            drpSourceType.DataSource = types;
            drpSourceType.DisplayMember = "Name";
            drpSourceType.ValueMember = "Name";
        }

      

        private void drpSourceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string  usercontrolname = "";
            switch (drpSourceType.SelectedValue)
            {
                case "XMLSourceAdapter":
                    usercontrolname = "XMLUserControl";
                    break;

                case "ExcelSourceAdapter":
                    usercontrolname = "ExcelUserControl";
                    break;

            }

            if (usercontrolname != "")
            {
              
                var control = (Control)Activator.CreateInstance(Type.GetType("DoctorLyApp.UserControls." + usercontrolname));
                for (int i=0;i< panel1.Controls.Count;++i)
                {
                    panel1.Controls.RemoveAt(i);
                }
                panel1.Controls.Add(control);
            }
        }
    }
}
