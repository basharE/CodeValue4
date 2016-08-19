using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimesCalculator
{
    public partial class Form1 : Form
    {
        private delegate void PrimeCalculator(int firstArgument, int secondArgument);
        static readonly AutoResetEvent AutoEvent = new AutoResetEvent(false);
        private Thread _demoThread;
        public Form1()
        {
            InitializeComponent();
        }

        private  void  CalculateBtn_Click(object sender, EventArgs e)
        {
            _demoThread = new Thread(ThreadProcSafe);
            _demoThread.Start();
        }


        private void ThreadProcSafe()
        {

            try
            {
                CalcPrimes(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }      
        }


        private void CalcPrimes(int first, int second)
        {
            var returnResult = new List<int>();
            for (var i = first; i < second; i++)
            {
                if (IsPrime(i))
                {
                    returnResult.Add(i);
                }
                if (AutoEvent.WaitOne(0))
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    MessageBox.Show(@"Operation was Canceled");
                    break;
                }
            }
            if ( listBox1.InvokeRequired)
            {
                var d = new PrimeCalculator(CalcPrimes);
                Invoke(d, new object[] { first, second });
            }
            else
            {              
                foreach (var num in returnResult)
                {
                    listBox1.Items.Add(num);
                }
            }
        }

        private bool IsPrime(int num)
        {
            var result = true;
            Parallel.For(2, (int) Math.Sqrt(num) + 1, (i, loop) =>
            {
                if (num%i == 0)
                {
                    result = false;
                    loop.Stop();
                }
            });
            return result;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            AutoEvent.Set();
        }
    }
}
