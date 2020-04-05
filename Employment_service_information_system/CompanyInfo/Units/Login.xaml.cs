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
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Page
    {
        JobManageEntities db = new JobManageEntities();
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string inputAccount = t1.Text.ToString();
            using(var context = new JobManageEntities())
            {
                bool isAccountright = false;
                var q = from t in context.Company
                        where t.Account == inputAccount
                        select t;

                
                foreach(var v in q)
                {
                    
                    isAccountright = true;
                    if (v.Account == inputAccount && v.Password == p1.Password)
                    {
                        MainPage mainPage = new MainPage(inputAccount);
                        NavigationService.GetNavigationService(this).Navigate(mainPage);
                    }
                    else
                    {
                        MessageBox.Show("密码输入错误");
                    }

                }
                if(isAccountright == false)
                MessageBox.Show("用户不存在");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("敬请期待");
        }
    }
}
