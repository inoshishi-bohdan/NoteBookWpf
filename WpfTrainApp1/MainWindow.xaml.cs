using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WpfTrainApp1.Models;
using WpfTrainApp1.Services;

namespace WpfTrainApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BindingList<ToDoModel> ToDoDataList;
        private FileIOServices fileIOServices;
        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDataList.json";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fileIOServices = new FileIOServices(PATH);
            try
            {
                ToDoDataList = fileIOServices.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
                Close();
            }
            dgToDo.ItemsSource=ToDoDataList;
            ToDoDataList.ListChanged += ToDoDataList_ListChanged;
        }

        private void ToDoDataList_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    fileIOServices.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }
    }
}
