using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
using taskmgr.ClassFolder;
using taskmgr.DataFolder;

namespace taskmgr.PageFolder
{
    /// <summary>
    /// Логика взаимодействия для StaffAddPage.xaml
    /// </summary>
    public partial class StaffAddPage : Page
    {
        public StaffAddPage()
        {
            InitializeComponent();
        }
        Staff staff = new Staff(); 

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var staffAdd = new Staff()
                {
                    NameStaff = NameTB.Text,
                    SurnameStaff = SurNameTB.Text,
                    MiddleNameStaff = MiddleNameTB.Text,
                    TaskStaff = TaskTB.Text,
                    StatusTaskStaff = StatusTB.Text
                };
                DBEntities.GetContext().Staff.Add(staffAdd);
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Успешно добавлено");
                this.NavigationService.Navigate(new Uri("PageFolder/StaffListPage.xaml", UriKind.Relative));
            }
            catch (DbEntityValidationException ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
