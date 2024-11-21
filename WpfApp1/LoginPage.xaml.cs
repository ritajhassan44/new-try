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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            if (string.IsNullOrWhiteSpace(Email.Text) || string.IsNullOrWhiteSpace(Pasword.Text))
            {
                MessageBox.Show("Required");
                return;
            }
            int count = 0;
            tryBEntities tryBEntities= new tryBEntities();
            var emp = tryBEntities.newuserrs.FirstOrDefault(x => x.EmailEmp == Email.Text && x.PasswordEmp == Pasword.Text);
            if (emp == null)
            {
                MessageBox.Show("inavlid email or password");
                //count++;
                //do (MessageBox.Show("you should create new password"))
                //{

                //} while (count==2) ;
              
                //
                if(count==2)
                {
                    MessageBox.Show("you should create new password");
                }

            }
              
                
               
            
     
            if (emp.RoleEmp == "Manger")
            {
                MessageBox.Show("Login succsessfully");
            taskmangment taskmangment=new taskmangment();
                this.NavigationService.Navigate(taskmangment);
            }
            else if (emp.RoleEmp == "Employee")
            {
                MessageBox.Show("Login successfully");
                viewtask viewtask = new viewtask();
                this.NavigationService.Navigate(viewtask);
            }
          
         
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tryBEntities tryBEntities = new tryBEntities();

            var emp = tryBEntities.newuserrs.FirstOrDefault(x => x.EmailEmp == Email.Text);

            ForgetPassword forgetPassword = new ForgetPassword(Email.Text);
            this.NavigationService.Navigate(forgetPassword,emp);
        }
    }
}
