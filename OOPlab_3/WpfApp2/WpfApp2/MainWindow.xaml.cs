using System;
using System.Windows;
using System.Windows.Controls;

namespace ArrayApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateArray_Click(object sender, RoutedEventArgs e)
        {
            int n, m;
            if (int.TryParse(RowsInput.Text, out n) && int.TryParse(ColsInput.Text, out m))
            {
                double[,] array = new double[n, m];
                Random rand = new Random();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        array[i, j] = Math.Round(rand.NextDouble() * (7.03 - (-42.31)) + (-42.31), 2);
                    }
                }

                ArrayDisplayPanel.Children.Clear();
                DisplayArray(array, "Початковий масив:");

                int nonNegativeRowsCount = 0;
                for (int i = 0; i < n; i++)
                {
                    bool hasNegative = false;
                    for (int j = 0; j < m; j++)
                    {
                        if (array[i, j] < 0)
                        {
                            hasNegative = true;
                            break;
                        }
                    }
                    if (!hasNegative)
                    {
                        nonNegativeRowsCount++;
                    }
                }
                ResultText.Text = $"Кількість рядків, які не містять жодного від’ємного елемента: {nonNegativeRowsCount}";

                for (int j = 0; j < m; j++)
                {
                    for (int i = 0; i < n / 2; i++)
                    {
                        double temp = array[i, j];
                        array[i, j] = array[n - 1 - i, j];
                        array[n - 1 - i, j] = temp;
                    }
                }
                DisplayArray(array, "Масив після зміни порядку елементів у стовпцях:");
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть дійсні числа для кількості рядків і стовпців.");
            }
        }

        private void DisplayArray(double[,] array, string title)
        {
            var textBlock = new TextBlock
            {
                Text = title,
                Margin = new Thickness(0, 10, 0, 5),
                FontWeight = FontWeights.Bold
            };
            ArrayDisplayPanel.Children.Add(textBlock);

            for (int i = 0; i < array.GetLength(0); i++)
            {
                string row = "";
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    row += $"{array[i, j]:F2}\t";
                }
                ArrayDisplayPanel.Children.Add(new TextBlock { Text = row });
            }
        }
    }
}
