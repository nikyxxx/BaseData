<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddAcountGroup
    Inherits PublicSharedResource.frmBase

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddAcountGroup))
        Me.C1TextBox1 = New C1.Win.C1Input.C1TextBox
        Me.C1TextBox2 = New C1.Win.C1Input.C1TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        CType(Me.C1TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1TextBox1
        '
        Me.C1TextBox1.Location = New System.Drawing.Point(72, 9)
        Me.C1TextBox1.Name = "C1TextBox1"
        Me.C1TextBox1.Size = New System.Drawing.Size(199, 21)
        Me.C1TextBox1.TabIndex = 1
        Me.C1TextBox1.Tag = Nothing
        '
        'C1TextBox2
        '
        Me.C1TextBox2.Location = New System.Drawing.Point(72, 47)
        Me.C1TextBox2.Name = "C1TextBox2"
        Me.C1TextBox2.Size = New System.Drawing.Size(199, 21)
        Me.C1TextBox2.TabIndex = 2
        Me.C1TextBox2.Tag = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "编码："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "名称："
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(149, 73)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(51, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(215, 73)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(56, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "取消"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmAddAcountGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(280, 108)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.C1TextBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.C1TextBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddAcountGroup"
        Me.Text = "科目组新增"
        Me.Controls.SetChildIndex(Me.C1TextBox1, 0)
        Me.Controls.SetChildIndex(Me.Button1, 0)
        Me.Controls.SetChildIndex(Me.Button2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.C1TextBox2, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        CType(Me.C1TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C1TextBox1 As C1.Win.C1Input.C1TextBox
    Friend WithEvents C1TextBox2 As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
