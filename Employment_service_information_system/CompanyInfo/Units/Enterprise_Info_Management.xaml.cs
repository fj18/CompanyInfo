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
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Enterprise_Info_Management : Page
    {
        JobManageEntities db = new JobManageEntities();
        public Enterprise_Info_Management()
		{
			InitializeComponent();
            updateTextBoxs();

        }

        private void updateTextBoxs()
        {
            using (var context = new JobManageEntities())
            {

                var q = from t in context.Company
                        where t.ID == MainPage.CompanyID
                        select t;

                foreach (var v in q)
                {
                    enterprise_Name.Text = v.Name;
                    enterprise_Nature.Text = v.Nature;
                    enterprise_Scale.Text = v.Scale;
                    enterprise_Trade.Text = v.Trade;
                    enterprise_Reamrk.Text = v.Reamrk;


                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
		{
            using (var context = new JobManageEntities())
            {
                var q = from t in context.Company
                        where t.ID == MainPage.CompanyID
                        select t;
                foreach (var v in q)
                {
                    v.Name = enterprise_Name.Text;
                    v.Nature = enterprise_Nature.Text;
                    v.Scale = enterprise_Scale.Text;
                    v.Trade = enterprise_Trade.Text;
                    v.Reamrk = enterprise_Reamrk.Text;

                }
                context.SaveChanges();
            }
        }

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
            updateTextBoxs();

        }
	}
}
