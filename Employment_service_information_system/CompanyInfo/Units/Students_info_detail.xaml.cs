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
    /// Students_info_detail.xaml 的交互逻辑
    /// </summary>
    public partial class Students_info_detail : Page
    {
        private int ID { get; set; }
        public Students_info_detail(WantedJob wantedJob)
        {
            ID = wantedJob.ID;
            InitializeComponent();
            tbCity.Text = wantedJob.City;
            tbDetail.Text = wantedJob.Remark;
            tbIndustry.Text = wantedJob.Industry;
            tbPosition.Text = wantedJob.PositionType;
            tbSalary.Text = wantedJob.Salary;
            tbTitle.Text = wantedJob.Title;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Students_Info_View students_Info_View = new Students_Info_View();
            NavigationService.GetNavigationService(this).Navigate(students_Info_View);
        } 

        private void Admission_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new JobManageEntities())
            {
                bool isGetJob = false;
                var q = from t in context.Resume
                        where t.ID == ID
                        select t;
                foreach (var v in q)
                {
                    v.qstation = "已就业";
                    isGetJob = true;
                }
                context.SaveChanges();
                if (isGetJob == true)
                    MessageBox.Show("录取成功");
            }
        }
    }
}
