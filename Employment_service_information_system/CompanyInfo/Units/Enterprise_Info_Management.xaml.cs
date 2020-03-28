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
		public Enterprise_Info_Management()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.GetNavigationService(this).Navigate(new Uri("/Units/Recruitmen_Info_Management.xaml", UriKind.Relative));
		}
	}
}
