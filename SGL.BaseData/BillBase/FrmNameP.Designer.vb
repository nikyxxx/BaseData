<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNameP
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNameP))
        Me.newwayname = New System.Windows.Forms.TextBox()
        Me.cmdChanel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'newwayname
        '
        Me.newwayname.Location = New System.Drawing.Point(12, 12)
        Me.newwayname.Name = "newwayname"
        Me.newwayname.Size = New System.Drawing.Size(214, 21)
        Me.newwayname.TabIndex = 8
        '
        'cmdChanel
        '
        Me.cmdChanel.Location = New System.Drawing.Point(151, 48)
        Me.cmdChanel.Name = "cmdChanel"
        Me.cmdChanel.Size = New System.Drawing.Size(75, 23)
        Me.cmdChanel.TabIndex = 7
        Me.cmdChanel.Text = "取消"
        Me.cmdChanel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(12, 48)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 6
        Me.cmdOK.Text = "确定"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'FrmNameP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(237, 78)
        Me.Controls.Add(Me.newwayname)
        Me.Controls.Add(Me.cmdChanel)
        Me.Controls.Add(Me.cmdOK)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmNameP"
        Me.Text = "方案保存"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents newwayname As System.Windows.Forms.TextBox
    Friend WithEvents cmdChanel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
End Class
