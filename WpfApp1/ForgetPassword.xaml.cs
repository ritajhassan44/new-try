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
    /// Interaction logic for ForgetPassword.xaml
    /// </summary>
    public partial class ForgetPassword : Page
    {
        public ForgetPassword()
        {
            InitializeComponent();
           void email(string emp)
            {
                            tryBEntities tryBEntities = new tryBEntities();

                var emp = tryBEntities.newuserrs.FirstOrDefault(x => x.EmailEmp == Email.Text);
            }
        }

        private void done_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(newpassword.Text)||string.IsNullOrWhiteSpace(confirmpassword.Text))
            {
                MessageBox.Show("requird");
                return;
            }

            if (newpassword!=confirmpassword)
            {
                MessageBox.Show("wrong password");
                return;
            }



            tryBEntities tryBEntities = new tryBEntities();
            if(newpassword.Text.Length<8)
            {
                MessageBox.Show("more than 8");
                return;
            }
            var check = tryBEntities.newuserrs.FirstOrDefault(x => x.EmailEmp==);

            if (check == null)
            {
                MessageBox.Show("worng password");
            }
            if (check != null)
            {
               
                check.PasswordEmp=newpassword.Text;
                check.EmailEmp=check.PasswordEmp;
                tryBEntities.newuserrs.AddOrUpdate(check);
                tryBEntities.SaveChanges();
                MessageBox.Show(" new password");
                LoginPage lloginPage = new LoginPage();
                this.NavigationService.Navigate(lloginPage);
            }
  }
    }
}
