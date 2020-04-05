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
    /// PasswdMod.xaml 的交互逻辑
    /// </summary>
    public partial class PasswdMod : Page
    {
        JobManageEntities db = new JobManageEntities();
        public PasswdMod()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new JobManageEntities())
            {
                bool isModified = false;
                var q = from t in context.Company
                        where t.ID == MainPage.CompanyID
                        select t;


                foreach (var v in q)
                {
                    
                    if (v.Password == oldPasswd.Password && newPasswd1.Password == newPasswd2.Password)
                    {
                        v.Password = newPasswd1.Password;
                        isModified = true;
                    }
                    else if (newPasswd1.Password != newPasswd2.Password)
                    {
                        MessageBox.Show("密码输入不一致");
                    }
                    else
                    {
                        MessageBox.Show("原密码输入错误");
                    }

                }
                context.SaveChanges();
                if(isModified == true)
                MessageBox.Show("密码修改成功");
            }
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            oldPasswd.Password = null;
            newPasswd1.Password = null;
            newPasswd2.Password = null;
        }
    }
}
