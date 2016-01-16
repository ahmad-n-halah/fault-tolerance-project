using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        TcpListener Server = new TcpListener(IPAddress.Any,5252);
        TcpClient Client;
        NetworkStream Stream;
        Int32 Test;
        Byte[] dl = new Byte[4];
        String path;



        public Form1()
        {
            InitializeComponent();
            Server.Start();

            new Thread(() =>
            {

                Client = Server.AcceptTcpClient();
                SerRe();
            }).Start(); ;


        }
        public String Solve(double a,double b,double c)
        {
            double x1, x2,img,x;
           double sqrtpart = b * b - 4 * a * c;
            if (sqrtpart > 0)
            {
                x1 = (-b + Math.Sqrt(sqrtpart)) / (2 * a);
                x2 = (-b - Math.Sqrt(sqrtpart)) / (2 * a);
                return x1 + " " + x2;
            }
            else if (sqrtpart < 0)
            {
                sqrtpart = -sqrtpart;
                x = -b / (2 * a);
                img = Math.Sqrt(sqrtpart) / (2 * a);
                return x + " " + img;
            }
            else //d=0
            {
                x = (-b + Math.Sqrt(sqrtpart)) / (2 * a);
                return "imagine number :" + x;
            }
        }
        private void SerRe()
        {

            Stream = Client.GetStream();
            new Thread(() =>
            {

                while ((Test = Stream.Read(dl, 0, 4)) != 0)
                {
                    byte[] data = new byte[BitConverter.ToInt32(dl, 0)];
                    Stream.Read(data, 0, data.Length);
                    this.Invoke((MethodInvoker)delegate
                    {
                        textBox1.Text = Environment.NewLine + " " + Encoding.Default.GetString(data);
                        String A, B, C, trim;
                        double a, b, c;

                       // string equation = "-111111111111*x^2+544444444444*x-15555555555555";
                        string equation = textBox1.Text;
                        try
                        {//check if "a" is found before x^2

                            A = equation.Substring(0, equation.IndexOf("x") - 1);
                            a = Convert.ToDouble(A);

                        }
                        catch (Exception ex)
                        {
                            a = 1;
                        }

                        String _operator_b = equation.Substring(equation.IndexOf("x^2"), equation.IndexOf("x^2") + 4);//cut operator of b (- or +)

                        if (_operator_b.Contains("+")) //check if b positive
                        {
                            trim = equation.Substring(equation.IndexOf("x^2"));

                            B = trim.Substring(trim.IndexOf("+"), trim.IndexOf("*") - 3);
                            b = Convert.ToDouble(B);
                        }
                        else //if b negative
                        {
                            trim = equation.Substring(equation.IndexOf("x^2"));

                            B = trim.Substring(trim.IndexOf("-"), trim.IndexOf("*") - 3);

                            b = Convert.ToDouble(B);
                        }

                        trim = trim.Substring(trim.IndexOf("*x"));
                        int v = trim.IndexOf("*x") + 2;
                        C = trim.Substring(v);
                        c = Convert.ToDouble(C);

                        string solve = Solve(a,b,c);
                        //listBox1.Text= (" result x=" + x + "\n  result x2=" + x2);
                        //listBox1.Text = " Equation " + a + "x^2" + SB + b + "x" + SC + c;

                        //listBox1.Items.Add(a.ToString() + "  " + b.ToString() + "  " + c.ToString());
                        listBox1.Items.Add(solve);
                        //ServSend(a.ToString() + "  " + b.ToString() + "  " + c.ToString());
                        ServSend(solve);


                    });

                }
            }).Start(); ;
        }

        private void ServSend(String message)
        {

            Stream = Client.GetStream();
            byte[] data = Encoding.Default.GetBytes(message);

            byte[] datalen = new byte[4];
            datalen = BitConverter.GetBytes(data.Length);

            Stream.Write(datalen, 0, 4);
            Stream.Write(data, 0, data.Length);
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //String A, B, C, trim;
            //double a, b, c;

            //string equation = "-111111111111*x^2+544444444444*x-15555555555555";
            //try
            //{//check if "a" is found before x^2

            //    A = equation.Substring(0, equation.IndexOf("x") - 1);
            //    a = Convert.ToDouble(A);

            //}
            //catch (Exception ex)
            //{
            //    a = 1;
            //}

            //String _operator_b = equation.Substring(equation.IndexOf("x^2"), equation.IndexOf("x^2")+4);//cut operator of b (- or +)
            //MessageBox.Show(_operator_b);

            //if (_operator_b.Contains("+")) //check if b positive
            //{
            //    trim = equation.Substring(equation.IndexOf("x^2"));

            //    B = trim.Substring(trim.IndexOf("+"), trim.IndexOf("*") - 3);
            //    MessageBox.Show(B);
            //    b = Convert.ToDouble(B);
            //}
            //else //if b negative
            //{
            //    trim = equation.Substring(equation.IndexOf("x^2"));

            //    B = trim.Substring(trim.IndexOf("-"), trim.IndexOf("*") - 3);
            //    MessageBox.Show(B);

            //    b = Convert.ToDouble(B);
            //}

            //trim = trim.Substring(trim.IndexOf("*x"));
            //int v = trim.IndexOf("*x") + 2;
            //C = trim.Substring(v);
            //c = Convert.ToDouble(C);
            //MessageBox.Show(a.ToString() + "  " + b.ToString() + "  " + c.ToString());

        }

        
    }
}
