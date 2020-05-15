using System;
using System.Collections.Generic;
using System.Data;
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
    /// Page2.xaml 的交互逻辑
    /// </summary>
    public partial class Recruitmen_Info_Management : Page
    {
        JobManageEntities db = new JobManageEntities();
        public Recruitmen_Info_Management()
        {
            InitializeComponent();
            dataGrid.ItemsSource = db.Dateview_2.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new JobManageEntities())
            {
                var q = from t in context.Dateview_2
                        where t.PositionName.Contains(this.txt.Text.ToString())
                        select t;
                dataGrid.ItemsSource = q.ToList();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Position position = new Position();

            Recruitmen_Init recruitmen_Init = new Recruitmen_Init(position);
            NavigationService.GetNavigationService(this).Navigate(recruitmen_Init);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.Items.Count; i++)
            {
                if (this.DeleteThis.ToString() == "true")
                {
                    var mySelectedElement = (Dateview_2)dataGrid.SelectedItem;

                    int selectedID = mySelectedElement.ID;


                    using (var context = new JobManageEntities())
                    {
                        var q = from t in context.Position
                                where t.ID == selectedID
                                select t;
                        foreach (var v in q)
                        {
                            context.Position.Remove(v);
                        }
                        context.SaveChanges();
                    }
                    dataGrid.ItemsSource = db.Dateview_2.ToList();
                }
            }
        }

        private void detail_Click(object sender, RoutedEventArgs e)
        {
            var mySelectedElement = (Dateview_2)dataGrid.SelectedItem;

            var selectedID = mySelectedElement.ID;


            using (var context = new JobManageEntities())
            {
                var q = from t in context.Position
                        where t.ID == selectedID
                        select t;
                foreach (var v in q)
                {
                    Recruitmen_Init recruitmen_Init = new Recruitmen_Init(v);
                    NavigationService.GetNavigationService(this).Navigate(recruitmen_Init);
                }

            }
        }

    }
}
