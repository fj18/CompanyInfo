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
    /// Recruitmen_Init.xaml 的交互逻辑
    /// </summary>
    public partial class Recruitmen_Init : Page
    {
        private int CompanyID { get; set; }
        private int PositionID { get; set; }
        public Recruitmen_Init(Position position)
        {

            InitializeComponent();

            PositionID = position.ID;
            BindDate(PositionID);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new JobManageEntities())
            {
                var q = from t in context.Position
                        where t.CompanyID == MainPage.CompanyID && t.ID == PositionID
                        select t;
                foreach (var v in q)
                {
                    v.Name = PositionName.Text;
                    v.Address = Adress.Text;
                    v.Count = int.Parse(Count.Text);
                    v.ContractPhone = ContratPhone.Text;
                    v.Remark = Remark.Text;
                }
                context.SaveChanges();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BindDate(PositionID);
        }

        private void BindDate(int PositionID)
        {
            using (var context = new JobManageEntities())
            {
                var q = from t in context.Position
                        where t.ID == PositionID
                        select t;
                foreach (var v in q)
                {
                    PositionName.Text = v.Name;
                    Adress.Text = v.Address;
                    Count.Text = v.Count.ToString();
                    ContratPhone.Text = v.ContractPhone;
                    Remark.Text = v.Remark;
                }
                context.SaveChanges();
            }
        }


    }
}