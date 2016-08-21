using System;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();                      
        }

        private async void  button1_Click(object sender, EventArgs e)
        {        
            var dDelegate = new PrimesCalculator(Delegates.CalcPrimes);
            var returnResult = new AsyncCallback(ProcessInformation);
            try
            {
                // Use Try Parse next time
                var firstNum = int.Parse(firstTextBox.Text);
                var secondNum = int.Parse(secondTextBox.Text);
                await Task.Run(() => dDelegate.BeginInvoke(firstNum, secondNum, returnResult, null));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }                                
        }

        private void ProcessInformation(IAsyncResult resultInv)
        {
            // delete dirst 2 lines and hold your dekegate as member class
            var res = (AsyncResult) resultInv;
            var asyncDelegate = (PrimesCalculator)res.AsyncDelegate;
            var ourResult = asyncDelegate.EndInvoke(resultInv);
            foreach (var num in ourResult)
            {
                // Invoke - synchronic, BeginInvoke - Asynchronic
                Invoke((Action)(()=>listBox.Items.Add(num)));
            }
        }
    }
}
