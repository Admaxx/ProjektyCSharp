using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace _2Zadanie
{
    /// <summary>
    /// Logika interakcji dla klasy FibonacciResultNumbers.xaml
    /// </summary>
    public partial class FibonacciResultNumbers : Window
    {
        List<int> AssistantVars = new List<int>()
        {
            {0 },
            {1 },
            {0 },
            {1 }

        };
        int i = 0;
        AllDatas ad = new AllDatas();
        
        List<string> FibonacciResult = new List<string>();
        public FibonacciResultNumbers()
        {
            InitializeComponent();
            FibonacciResult = ad.FibonacciList;
            

        }
        internal async Task FibonacciNumbers() //Jest to funkcja, która co 0,5 sekundy, wyświetla
        {                                      // wyliczone kolejne liczby ciągu Fibonacciego
            
            while (1 == 1)
            {
                await Task.Run(() =>
                {
                    FibonacciResult.Add(
                        (
                        Convert.ToUInt64(FibonacciResult[i]) +
                        Convert.ToUInt64(FibonacciResult[i + 1])
                        ) 
                        .ToString());
                    Thread.Sleep(500);
                });

                FibonacciText.Text +=
                    FibonacciResult[i + 1].ToString() + Environment.NewLine;
               
                
                if (i == (int)(FibonacciText.Height/16 * AssistantVars[1]))
                {
                    FibonacciText.Text = "";
                    FibonacciText.Text = FibonacciResult[i + 1].ToString() + Environment.NewLine;
                    AssistantVars[1]++; 
                }
                i++;
            }
        }
        internal async Task Timer() //Funkcja, która oblicza czas trwania wyliczenia ciągu.
        {
            DispatcherTimer timer1 = new DispatcherTimer();
            await Task.Run(() => timer1.Tick += FibonacciActionTime); //Przekazuję metodę, do wykonania asynchronicznego.
            timer1.Interval = new TimeSpan(0, 0, 1);
            timer1.Start();                                                     

        }
        internal void FibonacciActionTime(object sender, EventArgs e)
        {
            //MessageBox.Show(j.ToString());
            if(AssistantVars[2] % 3 == 0)
                AppTime.Text += AssistantVars[2] + "s" + Environment.NewLine;

            AssistantVars[2]++;
            if (AssistantVars[2] == (int)(AppTime.Height / 6 * AssistantVars[3]))
            {
                AppTime.Text = "";
                AssistantVars[3]++;
                
            }
        }
    }
}