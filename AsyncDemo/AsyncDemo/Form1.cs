using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AsyncDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();                      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TheDelegate dDelegate = new TheDelegate(Delegates.CalcPrimes);

            var firstNum = int.Parse(firstTextBox.Text);
            var secondNum = int.Parse(secondTextBox.Text);

            IAsyncResult result = dDelegate.BeginInvoke(firstNum, secondNum, null, null);

            IEnumerable<int> returnResult = dDelegate.EndInvoke( result);


            
            foreach (var num in returnResult)
            {
                listBox.Items.Add(num);
            }
        }
    }
}
