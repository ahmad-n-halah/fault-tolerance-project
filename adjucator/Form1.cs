using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace Client
{
    public partial class Form1 : Form
    {
        TcpClient Client;
        TcpClient Client2;
        TcpClient Client3;


        NetworkStream stream;
        NetworkStream stream2;
        NetworkStream stream3;


        int x;
        int x2;
        int x3;


        byte[] datalen = new Byte[4];
        byte[] datalen2 = new Byte[4];
        byte[] datalen3 = new Byte[4];

        int checkEquation (string equation)
        {
            string A, B, C,trim;
            String _operator_b;
            double a, b, c;
            try
            {//check if "a" is found before x^2

                A = equation.Substring(0, equation.IndexOf("x") - 1);

            }
            catch (Exception ex)
            {
                a = 1;
            }

            try
            {
                _operator_b = equation.Substring(equation.IndexOf("x^2"), equation.IndexOf("x^2") + 4);//cut operator of b (- or +)
            }
            catch (Exception ex)
            {
              return 0;

            }

            try
            {
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
            }
            catch (Exception ex)
            {
                return 0;
            }
            try
            {
                trim = trim.Substring(trim.IndexOf("*x"));
                int v = trim.IndexOf("*x") + 2;
                C = trim.Substring(v);
                c = Convert.ToDouble(C);
            }
            catch (Exception ex)
            {
                return 0;
            }

            return 1;//because there are'nt errors

        }

        private void RecClient()
        {
            
            new Thread(() =>
                {

                   
                        stream = Client.GetStream();

                        while ((x = stream.Read(datalen, 0, 4)) != 0)
                        {
                            byte[] buffer = new Byte[BitConverter.ToInt32(datalen, 0)];
                            stream.Read(buffer, 0, buffer.Length);
                            Invoke((MethodInvoker)delegate
                            {
                                Results.Items.Add(Environment.NewLine + "" + Encoding.Default.GetString(buffer));
                           });
                        }

                          


                }).Start();
        }

         private void RecClient2()
        {
            stream2 = Client2.GetStream();

            new Thread(() =>
                {
                    while ((x2 = stream2.Read(datalen, 0, 4)) != 0)
                    {
                        byte[] buffer = new Byte[BitConverter.ToInt32(datalen, 0)];
                        stream2.Read(buffer, 0, buffer.Length);
                        Invoke((MethodInvoker)delegate
                        {
                            Results.Items.Add(Environment.NewLine + "" + Encoding.Default.GetString(buffer));
                        });
                    }
                }).Start();
        }


        private void RecClient3()
        {
            stream3 = Client3.GetStream();

            new Thread(() =>
            {
        
                        while ((x3 = stream3.Read(datalen, 0, 4)) != 0)
                        {

                            byte[] buffer = new Byte[BitConverter.ToInt32(datalen, 0)];
                            stream3.Read(buffer, 0, buffer.Length);
                            Invoke((MethodInvoker)delegate
                            {
                                Results.Items.Add(Environment.NewLine + "" + Encoding.Default.GetString(buffer));
                            });
                        }
       
 }).Start();
        }

        private void Send(string msg)
        {
            stream = Client.GetStream();
            byte[] buf = Encoding.Default.GetBytes(msg);

            byte[] datalen = new byte[4];
            datalen = BitConverter.GetBytes(buf.Length);

            stream.Write(datalen, 0, 4);
            stream.Write(buf, 0, buf.Length);

        }

        private void Send2(string msg)
        {
            stream2 = Client2.GetStream();
            byte[] buf = Encoding.Default.GetBytes(msg);

            byte[] datalen = new byte[4];
            datalen2 = BitConverter.GetBytes(buf.Length);

            stream2.Write(datalen2, 0, 4);
            stream2.Write(buf, 0, buf.Length);

        }
        private void Send3(string msg)
        {
            stream3 = Client3.GetStream();
            byte[] buf = Encoding.Default.GetBytes(msg);

            byte[] datalen = new byte[4];
            datalen = BitConverter.GetBytes(buf.Length);

            stream3.Write(datalen, 0, 4);
            stream3.Write(buf, 0, buf.Length);

        }

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Results.Items.Clear();
            label1.Text = " ";
            int check=checkEquation(EquatioinText.Text);

            if (check<1)
              MessageBox.Show("Invalid equation 'the equation must be in this form (a*x^2+b*x+5)");
            else
            {

                try
                {
                    Send(EquatioinText.Text);

                }
                catch (Exception ex)
                {
                   
                }


                try
                {
                    Send2(EquatioinText.Text);

                }
                catch (Exception ex)
                {
                }

                try
                {
                    Send3(EquatioinText.Text);

                }
                catch (Exception ex)
                {
                }

            }

            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Client = new TcpClient(textBox2.Text, 4343);
                RecClient();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
         
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Client2 = new TcpClient(textBox4.Text, 5252);
                RecClient2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Client3 = new TcpClient(textBox1.Text, 1515);
                RecClient3();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            string result1;
            string result2;
            string result3;
            string R1, R2;

            string []roots1=new string[5];
            string [] roots2 = new string[5];
            string [] roots3 = new string[5];

            try
            {
                if (Results.Items[0].Equals(Results.Items[1]))
                    label1.Text = Results.Items[0].ToString();
                this.timer1.Stop();


            }
            catch (Exception ex)
            {

            }
            try
            {
                if (Results.Items[0].Equals(Results.Items[1]))
                {
                    label1.Text = Results.Items[0].ToString();
                    this.timer1.Stop();
                }
                else if (Results.Items[1].Equals(Results.Items[2]))
                {
                    label1.Text = Results.Items[1].ToString();

                    this.timer1.Stop();
                }
                else if (Results.Items[2].Equals(Results.Items[0]))
                {
                    label1.Text = Results.Items[2].ToString();
                    this.timer1.Stop();
                }

            }
            catch (Exception ex)
            {
            }
            try
            {
                result1 = Results.Items[0].ToString();
                result2 = Results.Items[1].ToString();
                result3 = Results.Items[2].ToString();
                double r1,r3,r5;
                double r2,r4,r6;

                roots1 = result1.Split(' ');
                R1 = roots1[0];
                R2 = roots1[1];
                r1 = Math.Ceiling(Convert.ToDouble(R1));
                r2 = Math.Ceiling(Convert.ToDouble(R2));

                roots2 = result2.Split(' ');
                R1 = roots2[0];
                R2 = roots2[1];
                r3 = Math.Ceiling(Convert.ToDouble(R1));
                r4 = Math.Ceiling(Convert.ToDouble(R2));

                roots3 = result3.Split(' ');
                R1 = roots3[0];
                R2 = roots3[1];
                r5 = Math.Ceiling(Convert.ToDouble(R1));
                r6 = Math.Ceiling(Convert.ToDouble(R2));
                if (r1==r3 && r2==r4 || r1==r5 &&r2==r6)
                {
           
                    label1.Text = "R1= " + r1 + "  R2= " + r2;
                    this.timer1.Stop();
                }
                else if (r3 == r1 && r4 == r2|| r3 == r5 && r4 ==r6)
                {  
                    label1.Text = "R1= " + r3 + "   R2= " + r4;
                    this.timer1.Stop();

                }
                else if (r5 == r1 && r6 == r2 || r5 == r3 && r6 == r4)
                {

                    label1.Text = "x1= " + r5 + "  x2= " + r6;
                    this.timer1.Stop();

                }

            }catch(Exception ex){
               
            }

            try
            {

                result1 = Results.Items[0].ToString();
                result2 = Results.Items[1].ToString();
                double r1, r3; 
                double r2, r4;
                roots1 = result1.Split(' ');
                R1 = roots1[0];
                R2 = roots1[1];
                r1 = Math.Ceiling(Convert.ToDouble(R1));
                r2 = Math.Ceiling(Convert.ToDouble(R2));

                roots2 = result2.Split(' ');
                R1 = roots2[0];
                R2 = roots2[1];
                r3 = Math.Ceiling(Convert.ToDouble(R1));
                r4 = Math.Ceiling(Convert.ToDouble(R2));

                if (r1 == r3 && r2 == r4)
                {
                    label1.Text = "R1= " + r1 + "  R2= " + r2;
                    this.timer1.Stop();

                }
               
            }
            catch (Exception ex)
            {

            }

}

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Results_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

    }
}
