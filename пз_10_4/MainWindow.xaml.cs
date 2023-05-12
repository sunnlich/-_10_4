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

namespace пз_10_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<zadacha> ActiveNotes;
        List<zadacha> CompleteNotes;

       // private List<string> SelectedItems { get; set; } = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            ActiveNotes = new List<zadacha>() { new zadacha("Добавить еще задачи")};  //создание листа и добавление записи
            CompleteNotes = new List<zadacha>() { new zadacha("Добавить еще задачи") };  //создание листа и добавление записи
            Update();
        }
        public void Update()
        {
            Current_tasks.ItemsSource = ActiveNotes.ToList();
            Complete_tasks.ItemsSource = CompleteNotes.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Zadacha.Text == null) return;
            ActiveNotes.Add(new zadacha(TextBox_Zadacha.Text));
            Update();
        }

        

        private void Current_tasks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var a = ActiveNotes.FindIndex(u => u == Current_tasks.SelectedItem);
            CompleteNotes.Add(ActiveNotes[a]);
            ActiveNotes.RemoveAt(a);
            Update();
        }

        private void Complete_tasks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var b = CompleteNotes.FindIndex(u => u == Complete_tasks.SelectedItem);
            CompleteNotes.RemoveAt(b);
            Update();
        }
    }
}
