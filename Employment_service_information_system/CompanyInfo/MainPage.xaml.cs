using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CompanyInfo
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class MainPage : Page
    {
		private DispatcherTimer timer;
		public MainPage()
        {
			InitializeComponent();

			timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += new EventHandler(timer_Tick);
			timer.Start();
			//test
		}

		void timer_Tick(object sender, EventArgs e)
		{

			//TextProperty1 = DateTime.Now.ToString();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Button btn = e.Source as Button;
			string s1 = btn.Tag.ToString();
			frm.Source = new Uri(s1, UriKind.Relative);

		}
	}
}
