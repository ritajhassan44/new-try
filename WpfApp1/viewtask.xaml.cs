using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for viewtask.xaml
    /// </summary>
    public partial class viewtask : Page
    {
        public viewtask()
        {
            InitializeComponent();
            refreshorshow();
            refreshorshoww();
        }
        public void refreshorshow()
        {
            tryBEntities tryBEntities = new tryBEntities();
            var emp = tryBEntities.EmpTaskkks.Where(x=> x.Statusemp=="Pending" && x.Statusemp=="In prograss").Select(x=> new
            {
                x.TaskId,
                x.Descrription,
                x.Title,
                x.Statusemp

               
            }).ToList();
            pendingorprogressdatagrid.ItemsSource = emp;
            refreshorshoww();
        }
        public void refreshorshoww()
        {
            tryBEntities tryBEntities = new tryBEntities();
            var emp = tryBEntities.EmpTaskkks.Where(x => x.Statusemp !="Completed").Select(x => new
            {
                x.TaskId,
                x.Descrription,
                x.Title,
                x.Statusemp

            }).ToList();
            completedtask.ItemsSource = emp;
         
        }

        private void Savee_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(taskid.Text)|| string.IsNullOrWhiteSpace(combobox.Text))
            {
                MessageBox.Show("required");
                return;
            }
            tryBEntities tryBEntities = new tryBEntities();
            int id = int.Parse(taskid.Text);
            var edite = tryBEntities.EmpTaskkks.FirstOrDefault(x => x.TaskId==id);
            if (edite== null)
            {
                MessageBox.Show("wrong id");
                return;
            }
            if (edite != null)
            {
                edite.Statusemp=combobox.Text;
                edite.TaskId=id;
                tryBEntities.EmpTaskkks.AddOrUpdate(edite);
                tryBEntities.SaveChanges();
                refreshorshow();
                MessageBox.Show("Save succsessfully");
            }
    }
    }
}
