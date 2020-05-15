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
using Database;
namespace CompanyInfo.Units
{
    /// <summary>
    /// Records_Student_info.xaml 的交互逻辑
    /// </summary>
    public partial class Records_Student_info : Page
    {
        private int ID { get; set; }
        public Records_Student_info(Resume resume)
        {
            ID = resume.ID;
            InitializeComponent();
            name.Text = resume.Name;
            sex.Text = resume.Sex;
            birdathy.Text = resume.BirthDay.ToString();
            degree.Text = resume.Degree;
            major.Text = resume.Major;
            adress.Text = resume.Address;
            intersion.Text = resume.Intertion;
            remark.Text = resume.Remark;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Records_Management records_Management = new Records_Management();
            NavigationService.GetNavigationService(this).Navigate(records_Management);
        }
    }
}
