using System;
using System.Collections.Generic;
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
    /// Page4.xaml 的交互逻辑
    /// </summary>
    public partial class Students_Info_View : Page
    {
        JobManageEntities db = new JobManageEntities();
        public Students_Info_View()
        {
            InitializeComponent();
            this.dataGrid.ItemsSource = db.WantedJob.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new JobManageEntities())
            {
                var q = from t in context.WantedJob
                        where t.Title.Contains(keyWords.Text.ToString())
                        select t;
                dataGrid.ItemsSource = q.ToList();
            }
        }


        private void Detail_Click(object sender, RoutedEventArgs e)
        {
            var mySelectedElement = (WantedJob)dataGrid.SelectedItem;

            var selectedID = mySelectedElement.ResumeID;


            using (var context = new JobManageEntities())
            {
                var q = from t in context.WantedJob
                        where t.ResumeID == selectedID
                        select t;
                foreach (var v in q)
                {
                    Students_info_detail students_Info_Detail = new Students_info_detail(v);
                    NavigationService.GetNavigationService(this).Navigate(students_Info_Detail);
                }
                
            }
            
        }
    }
}
