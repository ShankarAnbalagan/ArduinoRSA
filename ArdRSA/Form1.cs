using System;
using System.Numerics;
using System.Windows.Forms;

namespace ArdRSA
{
    public partial class Form1 : Form
    {
        String[] indata = new String[7];
        BigInteger cipher = new BigInteger();
        BigInteger message = new BigInteger();
        int n, e, d, data;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String port=comm.Text;
            serialPort1.PortName = port;
            try
            {
                serialPort1.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("COM not available");
            }
        }


        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            String data = serialPort1.ReadLine();
            indata= data.Split(',');
            if (indata.Length == 7)
                convertData();
        }

        private void convertData()
        {
            
            n = Convert.ToInt32(indata[2]);
            e = Convert.ToInt32(indata[4]);
            d = Convert.ToInt32(indata[5]);
            data = Convert.ToInt32(indata[6]);
            //MessageBox.Show("n ="+n+"\ne="+e+"\nd="+d+"\ndata="+data);
            solve();
        }

        private void solve()
        {
            cipher = BigInteger.ModPow(data, e, n);
            message = BigInteger.ModPow(cipher, d, n);
            MessageBox.Show("n =" + n + "\ne=" + e + "\nd=" + d + "\ndata=" + data+"\nCipher= " +cipher+
                "\nDecipher="+message);
        }

        ~Form1()
        {
            serialPort1.Close();
        }
    }    
}
