﻿using System;
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
using taskmgr.DataFolder;

namespace taskmgr.PageFolder
{
    /// <summary>
    /// Логика взаимодействия для TaskListPage.xaml
    /// </summary>
    public partial class TaskListPage : Page
    {
        public TaskListPage()
        {
            InitializeComponent();
            StaffListB.ItemsSource = DBEntities.GetContext()
                .Staff.ToList().OrderBy(a => a.NameStaff);
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
