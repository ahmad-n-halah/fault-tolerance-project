Namespace WindowsFormsApplication6
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
            Me.textBox1 = New System.Windows.Forms.TextBox()
            Me.label1 = New System.Windows.Forms.Label()
            Me.listBox1 = New System.Windows.Forms.ListBox()
            Me.groupBox1 = New System.Windows.Forms.GroupBox()
            Me.label2 = New System.Windows.Forms.Label()
            Me.groupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'textBox1
            '
            Me.textBox1.Location = New System.Drawing.Point(100, 12)
            Me.textBox1.Name = "textBox1"
            Me.textBox1.Size = New System.Drawing.Size(182, 20)
            Me.textBox1.TabIndex = 1
            '
            'label1
            '
            Me.label1.AutoSize = True
            Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label1.Location = New System.Drawing.Point(6, 16)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(75, 16)
            Me.label1.TabIndex = 2
            Me.label1.Text = "Received"
            '
            'listBox1
            '
            Me.listBox1.FormattingEnabled = True
            Me.listBox1.Location = New System.Drawing.Point(112, 87)
            Me.listBox1.Name = "listBox1"
            Me.listBox1.Size = New System.Drawing.Size(182, 121)
            Me.listBox1.TabIndex = 3
            '
            'groupBox1
            '
            Me.groupBox1.Controls.Add(Me.textBox1)
            Me.groupBox1.Controls.Add(Me.label1)
            Me.groupBox1.Location = New System.Drawing.Point(12, 12)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.Size = New System.Drawing.Size(291, 50)
            Me.groupBox1.TabIndex = 4
            Me.groupBox1.TabStop = False
            Me.groupBox1.Text = "groupBox1"
            '
            'label2
            '
            Me.label2.AutoSize = True
            Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label2.Location = New System.Drawing.Point(18, 87)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(68, 16)
            Me.label2.TabIndex = 4
            Me.label2.Text = "Results :"
            '
            'Form1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(506, 263)
            Me.Controls.Add(Me.label2)
            Me.Controls.Add(Me.groupBox1)
            Me.Controls.Add(Me.listBox1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            Me.groupBox1.ResumeLayout(False)
            Me.groupBox1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

		#End Region

		Private WithEvents textBox1 As System.Windows.Forms.TextBox
		Private label1 As System.Windows.Forms.Label
		Private listBox1 As System.Windows.Forms.ListBox
		Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
		Private label2 As System.Windows.Forms.Label
    End Class
End Namespace

