using System.Windows;
using System.Windows.Controls;

namespace TicTacToeWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int count;
        int[,] array = new int[3, 3];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            int column = Grid.GetColumn(button);
            int row = Grid.GetRow(button);

            array[row, column] = count % 2 == 0 ? 1 : 0;

            button.Content = count % 2 == 0 ? "x" : "0";
            button.IsEnabled = false;

            if (IsWon())
            {
                MessageBox.Show($"{(count % 2 == 0 ? "x" : "0")} won");

                foreach (var item in MainGrid.Children)
                {
                    Button btn = (Button)item;

                    btn.IsEnabled = false;
                }
            }
            else if (count == 8)
                MessageBox.Show("Tie");

            count++;
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {

            count = 0;
            foreach (var item in MainGrid.Children)
            {
                Button button = (Button)item;

                button.IsEnabled = true;
                button.Content = "";
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    array[i, j] = -1;
                }
            }
        }

        public bool IsWon()
        {
            // x x x
            // - - -
            // - - - 
            if (array[0, 0] != -1 && array[0, 0] == array[0, 1] && array[0, 1] == array[0, 2])
            {
                return true;
            }

            // - - -
            // X X X
            // - - - 
            if (array[1, 0] != -1 && array[1, 0] == array[1, 1] && array[1, 1] == array[1, 2])
            {
                return true;
            }

            // - - -
            // - - -
            // X X X 
            if (array[2, 0] != -1 && array[2, 0] == array[2, 1] && array[2, 1] == array[2, 2])
            {
                return true;
            }

            // X - -
            // X - -
            // X - - 
            if (array[0, 0] != -1 && array[0, 0] == array[1, 0] && array[1, 0] == array[1, 0])
            {
                return true;
            }



            // - x -
            // - x -
            // - x - 
            if (array[0, 1] != -1 && array[0, 1] == array[1, 1] && array[1, 1] == array[2, 1])
            {
                return true;
            }


            // - - X
            // - - X
            // - - X 
            if (array[0, 2] != -1 && array[0, 2] == array[1, 2] && array[1, 2] == array[2, 2])
            {
                return true;
            }


            // X - -
            // - X -
            // - - X 
            if (array[0, 0] != -1 && array[0, 0] == array[1, 1] && array[1, 1] == array[2, 2])
            {
                return true;
            }

            // - - X
            // - X -
            // X - -
            if (array[0, 2] != -1 && array[0, 2] == array[1, 1] && array[1, 1] == array[2, 0])
            {
                return true;
            }

            return false;
        }
    }
}
