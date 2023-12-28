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
using System.Windows.Shapes;
using taskmgr.ClassFolder;
using taskmgr.DataFolder;
using taskmgr.WindowFolder.AdminFolder;
using taskmgr.WindowFolder.StaffFolder;

namespace taskmgr.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(LoginTB.Text) &&
                    !string.IsNullOrWhiteSpace(PasswordPB.Password))
                {
                    LoginBtn_Click(sender, e);
                }
                else
                {
                    if (LoginTB.IsFocused)
                        PasswordPB.Focus();
                    else
                        LoginTB.Focus();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoginTB.Focus();
        }
        private void Close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTB.Text))
            {
                MBClass.ErrorMB("Введите логин");
                LoginTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordPB.Password))
            {
                MBClass.ErrorMB("Введите пароль");
                PasswordPB.Focus();
            }
            else
            {
                try
                {
                    var user = DBEntities.GetContext()
                        .User
                        .FirstOrDefault(u => u.LoginUser == LoginTB.Text);

                    if (user == null)
                    {
                        MBClass.ErrorMB("Не правельный логин");
                        LoginTB.Focus();
                        return;
                    }

                    if (user.PasswordUser != PasswordPB.Password)
                    {
                        MBClass.ErrorMB("Не правельный пароль");
                        PasswordPB.Focus();
                        return;
                    }

                    else
                    {
                        switch (user.IdUser)
                        {
                            case 1:
                                new AdminWindow().Show();
                                break;
                            case 2:
                                new StaffWindow().Show();
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }
    }
}
