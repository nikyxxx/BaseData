<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fbasetemp
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fbasetemp))
        Me.C1FlexGrid = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.C1FlexGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1FlexGrid
        '
        Me.C1FlexGrid.AllowEditing = False
        Me.C1FlexGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1FlexGrid.ColumnInfo = resources.GetString("C1FlexGrid.ColumnInfo")
        Me.C1FlexGrid.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.C1FlexGrid.Location = New System.Drawing.Point(12, 12)
        Me.C1FlexGrid.Name = "C1FlexGrid"
        Me.C1FlexGrid.Rows.Count = 15
        Me.C1FlexGrid.Rows.DefaultSize = 18
        Me.C1FlexGrid.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FlexGrid.Size = New System.Drawing.Size(340, 333)
        Me.C1FlexGrid.StyleInfo = resources.GetString("C1FlexGrid.StyleInfo")
        Me.C1FlexGrid.TabIndex = 357
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(67, 365)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 358
        Me.Button1.Text = "确认"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(204, 365)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 359
        Me.Button2.Text = "取消"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'fbasetemp
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 400)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.C1FlexGrid)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "fbasetemp"
        Me.ShowInTaskbar = False
        Me.Text = "fbasetemp"
        CType(Me.C1FlexGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1FlexGrid As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
