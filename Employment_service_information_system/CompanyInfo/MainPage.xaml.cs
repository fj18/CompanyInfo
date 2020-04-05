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
		private DispatcherTimer ShowTimer;
		public MainPage()
        {
			InitializeComponent();

			ShowTime();    //在这里窗体加载的时候不执行文本框赋值，窗体上不会及时的把时间显示出来，而是等待了片刻才显示了出来

			ShowTimer = new System.Windows.Threading.DispatcherTimer();

			ShowTimer.Tick += new EventHandler(ShowCurTimer);//起个Timer一直获取当前时间

			ShowTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);

			ShowTimer.Start();

           
        }

		public void ShowCurTimer(object sender, EventArgs e)

		{

			ShowTime();

		}

		//ShowTime方法

		private void ShowTime()
		{
			//获得年月日
			this.tb1.Text = DateTime.Now.ToString("yyyy/MM/dd");   //yyyy/MM/dd
																		  
			this.tb2.Text = DateTime.Now.ToString("HH:mm:ss");//获得时分秒
		}



		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Button btn = e.Source as Button;
			string s1 = btn.Tag.ToString();
			frm.Source = new Uri(s1, UriKind.Relative);  //button按钮  显示界面

		}

        private void LnkPre_Click(object sender, RoutedEventArgs e)
        {
            //修改密码导航
            
            frm.Source = new Uri("Units/PasswdMod.xaml", UriKind.Relative);

        }
    }
}
