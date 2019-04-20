using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KonveirEntities1 ent;
        public MainWindow()
        {
            
            // Изменение для коммита 
            InitializeComponent();
            ent = new KonveirEntities1();
            ent.Manager1.Load();
            managersGrid.ItemsSource = ent.Manager1.Local.ToBindingList();//о круто ща сек

            this.Closing += MainWindow_Closing;
           


        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ent.Dispose();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            ent.SaveChanges();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (managersGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < managersGrid.SelectedItems.Count; i++)
                {
                    Manager1 manager = managersGrid.SelectedItems[i] as Manager1;
                    if (manager != null)
                    {
                        ent.Manager1.Remove(manager);
                    }
                }
            }
            ent.SaveChanges();
        }

  
        private void button1_Click(object sender, RoutedEventArgs e)
        {


            //if (textBox.Text != "" && passwordBox. != "")  
            //{  
            //    DBconnection objconn = new DBconnection();  
            //    objconn.connection(); //calling connection   

            //    SqlCommand com = new SqlCommand("user_Sp_Login", objconn.con);  
            //    com.CommandType = CommandType.StoredProcedure;  
            //    com.Parameters.AddWithValue("@UserId", textBox.Text);  
            //    com.Parameters.AddWithValue("@Password", passwordBox.Password);  
        }

    }
}
