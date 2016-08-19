using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackgroundPrimeCalc
{

    public partial class Form1 : Form
    {

        private delegate void TheDelegate(int firstArgument, int secondArgument);
        private Thread _demoThread = null;
        private float _highestPercentageReached = 0;
        private int _prime = 0;
        private BackgroundWorker _worker;

        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _worker = sender as BackgroundWorker;

            //for (int i = 1; i <= 10; i++)
            //{
                if (_worker.CancellationPending == true)
                {
                    e.Cancel = true;
                }
                else
                {
                    CalcPrimes(1, 8000);
                }
            //}
        }

        private void CalcBtn_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void CanBtn_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label1.Text = ($"{e.ProgressPercentage.ToString()}%");
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                label1.Text = @"Canceled!";
                progressBar1.Value = 0;
            }
            else if (e.Error != null)
            {
                label1.Text = $"Error: {e.Error.Message} " ;
            }
            else
            {
                label1.Text = @"Done!";
                progressBar1.Value = 100;
            }
        }
   
        private void CalcPrimes(int first, int second)
        {
            int percentComplete = (int)((float)first / (float)second);
            if (this.ourListBox.InvokeRequired)
            {
                TheDelegate d = new TheDelegate(CalcPrimes);
                this.Invoke(d, new object[] {first, second});
            }
            else
            {
                for (int i = first; i < second; i++)
                {
                    percentComplete = i / second;
                    if (IsPrime(i))
                    {
                        ourListBox.Items.Add(i);                        
                        if (percentComplete > _highestPercentageReached)
                        {
                            _highestPercentageReached = percentComplete;
                            _worker.ReportProgress(percentComplete);
                        }
                    }
                }
            }
        }

        private bool IsPrime(int num)
        {
            bool result = true;
            Parallel.For(2, (int)Math.Sqrt(num) + 1, (i, loop) =>
            {
                if (num % i == 0)
                {
                    result = false;
                    loop.Stop();
                }
            });
            return result;
        }

    }
}
