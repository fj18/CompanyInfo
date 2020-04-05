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
        private Company company = new Company();
		public Enterprise_Info_Management()
		{
			InitializeComponent();
            enterprise_Name.Text = MainPage.CompanyID;

        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			enterprise_Name.IsEnabled = true;
		}
	}
}
