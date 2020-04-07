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
        DataSet ds = new DataSet();
        public Records_Management()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection("server=101.200.41.96; database=JobManageEntities; uid=sa; pwd=Qq123456");
            string str = "select Company.id,Company.[Nmae],Position.id,Position.[Name],Position.CompanyId,Resume.id,Resume.[Name] from Company,Position,Resume join Record on Resume.id=Record.id,Position.id=Record.id,Company.id=Position.CompanyId";
            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            da.Fill(ds);

            dataGrid.DataContext = ds;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            var q = from t in ds.Tables
                    where t.ResumeName.Contains(Name.Text.ToString())
                    select t;

            dataGrid.ItemsSource = q.ToList();

           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void detail_Click(object sender, RoutedEventArgs e)
        {
            var mySelectedElement = (Record)dataGrid.SelectedItem;

            var selectedID = mySelectedElement.ResumeID;


            using (var context = new JobManageEntities())
            {
                var q = from t in context.Record
                        where t.ResumeID == selectedID
                        select t;
                foreach (var v in q)
                {
                    Records_Student_info records_Student_Info = new Records_Student_info();
                    NavigationService.GetNavigationService(this).Navigate(records_Student_Info);
                }

            }
        }


    }
}
