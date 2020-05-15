
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CompanyInfo.Units
{
    /// <summary>
    /// Page3.xaml 的交互逻辑
    /// </summary>
    public partial class Records_Management : Page
    {


        JobManageEntities db = new JobManageEntities();

        public Records_Management()
        {
            InitializeComponent();
            this.dataGrid.ItemsSource = db.Dataview_1.ToList();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //  BindData();
            using (var context = new JobManageEntities())
            {
                var q = from t in context.Dataview_1
                        where t.ResumeName.Contains(this.txt.Text.ToString())
                        select t;
                dataGrid.ItemsSource = q.ToList();
            }
        }


        //使几个不同表中的数据整合完后，查找Resume_name
        //public void BindData()
        //{
        //    //DataSet ds = new DataSet();
        //    //StringBuilder strWhere = new StringBuilder();
        //    //strWhere.AppendFormat(" re.Name like '%{0}%'", this.txt.Text.Trim());
        //    //ds = dao.GetRecordList(strWhere.ToString());

        //    //dataGrid.ItemsSource = ds.Tables.ToString();
        //}


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.Items.Count; i++)
            {
                if (this.DeleteThis.ToString() == "true")
                {
                    var mySelectedElement = (Dataview_1)dataGrid.SelectedItem;

                    int selectedID = mySelectedElement.ID;


                    using (var context = new JobManageEntities())
                    {
                        var q = from t in context.Record
                                where t.ID == selectedID
                                select t;
                        foreach (var v in q)
                        {
                            context.Record.Remove(v);
                        }
                        context.SaveChanges();
                    }
                    dataGrid.ItemsSource = db.Dataview_1.ToList();
                }
            }

        }


        private void detail_Click(object sender, RoutedEventArgs e)
        {
            var mySelectedElement = (Dataview_1)dataGrid.SelectedItem;

            var selectedID = mySelectedElement.ResumeID;


            using (var context = new JobManageEntities())
            {
                var q = from t in context.Resume
                        where t.ID == selectedID
                        select t;
                foreach (var v in q)
                {
                    Records_Student_info records_Student_Info = new Records_Student_info(v);
                    NavigationService.GetNavigationService(this).Navigate(records_Student_Info);
                }

            }
        }


    }
}
