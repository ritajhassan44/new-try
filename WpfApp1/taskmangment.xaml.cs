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
using System.Windows.Shell;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for taskmangment.xaml
    /// </summary>
    public partial class taskmangment : Page
    {
        public taskmangment()
        {
            InitializeComponent();
            refreshorshow();
        }
      
        public void refreshorshow()
        {
            tryBEntities tryBEntities = new tryBEntities();
            var emp=tryBEntities.EmpTaskkks.Select(x=> new
            {
                x.TaskId,
                x.Descrription,
                x.Title,
                x.Statusemp
                
            }).ToList();
            datagridtask.ItemsSource = emp;
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {

            tryBEntities tryBEntities = new tryBEntities();
            if (string.IsNullOrWhiteSpace(taskid.Text) || string.IsNullOrWhiteSpace(title.Text) || string.IsNullOrWhiteSpace(Descreiption.Text) || string.IsNullOrWhiteSpace(combobox.Text) || string.IsNullOrWhiteSpace(email.Text))
            {
                MessageBox.Show("Required");
                return;
            }

            var add = tryBEntities.newuserrs.FirstOrDefault(x => x.EmailEmp.Contains( email.Text));
            if (add != null)
            {
                EmpTaskkk empTaskkk = new EmpTaskkk();
                empTaskkk.Title = title.Text;
                empTaskkk.Descrription = Descreiption.Text;
                empTaskkk.Statusemp = combobox.Text;
                empTaskkk.UserId = empTaskkk.TaskId;
                tryBEntities.EmpTaskkks.Add(empTaskkk);
                tryBEntities.SaveChanges();

                refreshorshow();
                MessageBox.Show("Added succsessfully");
            }
            if (add == null)
            {
                MessageBox.Show("wrong Email");
                return;
            }

          
        }

        private void edite_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(taskid.Text) || string.IsNullOrWhiteSpace(title.Text) || string.IsNullOrWhiteSpace(Descreiption.Text) || string.IsNullOrWhiteSpace(combobox.Text) || string.IsNullOrWhiteSpace(email.Text))
            {
                MessageBox.Show("Required");
                return;
            }

            tryBEntities tryBEntities =new tryBEntities();
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
                edite.Descrription=Descreiption.Text;
                edite.Title = title.Text;
                tryBEntities.EmpTaskkks.AddOrUpdate(edite);
                tryBEntities.SaveChanges();
                refreshorshow();
                MessageBox.Show("Edite succsessfully");
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
           
            tryBEntities tryBEntities = new tryBEntities();
            int id = int.Parse(taskid.Text);
            var delete = tryBEntities.EmpTaskkks.FirstOrDefault(x => x.TaskId==id);
            if (delete== null)
            {
                MessageBox.Show("wrong id");
                return;
            }
            if (delete != null)
            {
               
               tryBEntities.EmpTaskkks.Remove(delete);
                tryBEntities.SaveChanges();
                refreshorshow();
                MessageBox.Show("deleted succsessfully");
            }
        }
    }
}

