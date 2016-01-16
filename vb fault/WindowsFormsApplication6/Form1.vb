Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading


Namespace WindowsFormsApplication6
	Partial Public Class Form1
		Inherits Form

        Private Server As New TcpListener(IPAddress.Any, 1515)
		Private Client As TcpClient
		Private Stream As NetworkStream
		Private Test As Int32
		Private dl(3) As Byte
		Private path As String



		Public Sub New()
			InitializeComponent()
			Server.Start()

			Call New Thread(Sub()

				Client = Server.AcceptTcpClient()
				SerRe()
			End Sub).Start()



		End Sub
		Public Function Solve(ByVal a As Double, ByVal b As Double, ByVal c As Double) As String
			Dim x1, x2, img, x As Double
		   Dim sqrtpart As Double = b * b - 4 * a * c
			If sqrtpart > 0 Then
				x1 = (-b + Math.Sqrt(sqrtpart)) / (2 * a)
				x2 = (-b - Math.Sqrt(sqrtpart)) / (2 * a)
				Return x1 & " " & x2
			ElseIf sqrtpart < 0 Then
				sqrtpart = -sqrtpart
				x = -b / (2 * a)
				img = Math.Sqrt(sqrtpart) / (2 * a)
				Return x & " " & img
			Else 'd=0
				x = (-b + Math.Sqrt(sqrtpart)) / (2 * a)
				Return "imagine number :" & x
			End If
		End Function
		Private Sub SerRe()

			Stream = Client.GetStream()
			Call New Thread(Sub()

'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: while ((Test = Stream.Read(dl, 0, 4)) != 0)
				Test = Stream.Read(dl, 0, 4)
				Do While Test <> 0
					Dim data(BitConverter.ToInt32(dl, 0) - 1) As Byte
					Stream.Read(data, 0, data.Length)
					Me.Invoke(CType(Sub()
					   ' string equation = "-111111111111*x^2+544444444444*x-15555555555555";
						'listBox1.Text= (" result x=" + x + "\n  result x2=" + x2);
						'listBox1.Text = " Equation " + a + "x^2" + SB + b + "x" + SC + c;
						'listBox1.Items.Add(a.ToString() + "  " + b.ToString() + "  " + c.ToString());
						'ServSend(a.ToString() + "  " + b.ToString() + "  " + c.ToString());
						textBox1.Text = Environment.NewLine & " " & Encoding.Default.GetString(data)
						Dim A, B, C, trim As String
'INSTANT VB NOTE: The variable a was renamed since Visual Basic will not allow local variables with the same name as parameters or other local variables:
'INSTANT VB NOTE: The variable b was renamed since Visual Basic will not allow local variables with the same name as parameters or other local variables:
'INSTANT VB NOTE: The variable c was renamed since Visual Basic will not allow local variables with the same name as parameters or other local variables:
						Dim a_Renamed, b_Renamed, c_Renamed As Double
						Dim equation As String = textBox1.Text
						Try
							A = equation.Substring(0, equation.IndexOf("x") - 1)
							a_Renamed = Convert.ToDouble(A)
						Catch ex As Exception
							a_Renamed = 1
						End Try
						Dim _operator_b As String = equation.Substring(equation.IndexOf("x^2"), equation.IndexOf("x^2") + 4)
						If _operator_b.Contains("+") Then
							trim = equation.Substring(equation.IndexOf("x^2"))
							B = trim.Substring(trim.IndexOf("+"), trim.IndexOf("*") - 3)
							b_Renamed = Convert.ToDouble(B)
						Else
							trim = equation.Substring(equation.IndexOf("x^2"))
							B = trim.Substring(trim.IndexOf("-"), trim.IndexOf("*") - 3)
							b_Renamed = Convert.ToDouble(B)
						End If
						trim = trim.Substring(trim.IndexOf("*x"))
						Dim v As Integer = trim.IndexOf("*x") + 2
						C = trim.Substring(v)
						c_Renamed = Convert.ToDouble(C)
'INSTANT VB NOTE: The variable solve was renamed since Visual Basic does not handle local variables named the same as class members well:
						Dim solve_Renamed As String = Solve(a_Renamed,b_Renamed,c_Renamed)
						listBox1.Items.Add(solve_Renamed)
						ServSend(solve_Renamed)
					End Sub, MethodInvoker))

					Test = Stream.Read(dl, 0, 4)
				Loop
			End Sub).Start()

		End Sub

		Private Sub ServSend(ByVal message As String)

			Stream = Client.GetStream()
			Dim data() As Byte = Encoding.Default.GetBytes(message)

			Dim datalen(3) As Byte
			datalen = BitConverter.GetBytes(data.Length)

			Stream.Write(datalen, 0, 4)
			Stream.Write(data, 0, data.Length)
		End Sub


		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

		End Sub

		Private Sub textBox1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles textBox1.TextChanged

		End Sub

		Private Sub groupBox1_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles groupBox1.Enter

		End Sub

        Private Sub button1_Click_1(ByVal sender As Object, ByVal e As EventArgs)
            'String A, B, C, trim;
            'double a, b, c;

            'string equation = "-111111111111*x^2+544444444444*x-15555555555555";
            'try
            '{//check if "a" is found before x^2

            '    A = equation.Substring(0, equation.IndexOf("x") - 1);
            '    a = Convert.ToDouble(A);

            '}
            'catch (Exception ex)
            '{
            '    a = 1;
            '}

            'String _operator_b = equation.Substring(equation.IndexOf("x^2"), equation.IndexOf("x^2")+4);//cut operator of b (- or +)
            'MessageBox.Show(_operator_b);

            'if (_operator_b.Contains("+")) //check if b positive
            '{
            '    trim = equation.Substring(equation.IndexOf("x^2"));

            '    B = trim.Substring(trim.IndexOf("+"), trim.IndexOf("*") - 3);
            '    MessageBox.Show(B);
            '    b = Convert.ToDouble(B);
            '}
            'else //if b negative
            '{
            '    trim = equation.Substring(equation.IndexOf("x^2"));

            '    B = trim.Substring(trim.IndexOf("-"), trim.IndexOf("*") - 3);
            '    MessageBox.Show(B);

            '    b = Convert.ToDouble(B);
            '}

            'trim = trim.Substring(trim.IndexOf("*x"));
            'int v = trim.IndexOf("*x") + 2;
            'C = trim.Substring(v);
            'c = Convert.ToDouble(C);
            'MessageBox.Show(a.ToString() + "  " + b.ToString() + "  " + c.ToString());

        End Sub


	End Class
End Namespace
