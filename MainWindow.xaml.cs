using System;
using System.Collections.Generic;
using System.Data;
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

namespace Collector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        List<Hoper> listok = new List<Hoper>();
        List<int> listbad = new List<int>();
        int capacity = 0;
            int i = 0;

        private void CreateNumAndViewNum_Click(object sender, RoutedEventArgs e)
        {
            

            int y = 0;

            int.TryParse(WWUser.Text, out capacity);
            if (capacity != 0 && capacity > 0)
            {



                


                if (capacity < 0)
                {
                    WWUser = null;
                    MessageBox.Show("Введите целое не отрицательное число");
                    return;
                }

                while (i < capacity)
                {
                    listok.Add(new Hoper() { Num = (new Random()).Next(-1000, 100), Count = i + 1 });


                    i++;
                }
                i = 0;
                DGeshka.ItemsSource = listok;

            }
            else
            {
                MessageBox.Show("Введите  число");
            }



        }

        private void Answer_Click(object sender, RoutedEventArgs e)
        {
            if (DGeshka.ItemsSource != null)

            {


                int[] array = listok.Select(x => x.Num).ToArray(); //копиирую данные из содержащего класса в массив 


                listbad.AddRange(array);//добавляю массив в коллекцию
                int min = array[0];
                for (int s = 0; s < array.Length; s++)
                {
                    if (min > array[s])
                    {
                        min = array[s];
                        capacity = s;
                    }


                }
                listbad.Sort();
                MessageBox.Show(Convert.ToString("Номер элемента " + (capacity + 1) + " Элемент" + listbad[0]));
            }
            else
            {
                MessageBox.Show("Сначала заполните таблицу");
            }




        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            DGeshka.ItemsSource = null;
            WWUser.Clear();
        }



        private void Task(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Составьте программу вычисления в массиве максимального среди отрицательных  элементов и его номера");
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
