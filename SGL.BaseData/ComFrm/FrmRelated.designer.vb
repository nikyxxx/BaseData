<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRelated
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRelated))
        Me.Label1 = New System.Windows.Forms.Label
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ButOK = New System.Windows.Forms.Button
        Me.ButChanle = New System.Windows.Forms.Button
        Me.FCustID = New C1.Win.C1Input.C1TextBox
        Me.ButSearch = New System.Windows.Forms.Button
        Me.C1FlexGrid2 = New C1.Win.C1FlexGrid.C1FlexGrid
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FCustID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "客户："
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.ColumnInfo = resources.GetString("C1FlexGrid1.ColumnInfo")
        Me.C1FlexGrid1.Location = New System.Drawing.Point(2, 41)
        Me.C1FlexGrid1.Name = "C1FlexGrid1"
        Me.C1FlexGrid1.Rows.DefaultSize = 18
        Me.C1FlexGrid1.Size = New System.Drawing.Size(707, 193)
        Me.C1FlexGrid1.StyleInfo = resources.GetString("C1FlexGrid1.StyleInfo")
        Me.C1FlexGrid1.TabIndex = 1
        '
        'ButOK
        '
        Me.ButOK.Location = New System.Drawing.Point(551, 240)
        Me.ButOK.Name = "ButOK"
        Me.ButOK.Size = New System.Drawing.Size(95, 24)
        Me.ButOK.TabIndex = 2
        Me.ButOK.Text = "确 定"
        Me.ButOK.UseVisualStyleBackColor = True
        '
        'ButChanle
        '
        Me.ButChanle.Location = New System.Drawing.Point(425, 240)
        Me.ButChanle.Name = "ButChanle"
        Me.ButChanle.Size = New System.Drawing.Size(95, 24)
        Me.ButChanle.TabIndex = 2
        Me.ButChanle.Text = "取 消"
        Me.ButChanle.UseVisualStyleBackColor = True
        '
        'FCustID
        '
        Me.FCustID.Location = New System.Drawing.Point(67, 11)
        Me.FCustID.Name = "FCustID"
        Me.FCustID.Size = New System.Drawing.Size(179, 21)
        Me.FCustID.TabIndex = 3
        Me.FCustID.Tag = Nothing
        '
        'ButSearch
        '
        Me.ButSearch.Location = New System.Drawing.Point(258, 11)
        Me.ButSearch.Name = "ButSearch"
        Me.ButSearch.Size = New System.Drawing.Size(62, 24)
        Me.ButSearch.TabIndex = 2
        Me.ButSearch.Text = "查 询"
        Me.ButSearch.UseVisualStyleBackColor = True
        '
        'C1FlexGrid2
        '
        Me.C1FlexGrid2.ColumnInfo = "10,1,0,0,0,0,Columns:"
        Me.C1FlexGrid2.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1FlexGrid2.Location = New System.Drawing.Point(2, 213)
        Me.C1FlexGrid2.Name = "C1FlexGrid2"
        Me.C1FlexGrid2.Rows.Count = 1
        Me.C1FlexGrid2.Rows.DefaultSize = 18
        Me.C1FlexGrid2.Rows.Fixed = 0
        Me.C1FlexGrid2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.C1FlexGrid2.Size = New System.Drawing.Size(686, 20)
        Me.C1FlexGrid2.StyleInfo = resources.GetString("C1FlexGrid2.StyleInfo")
        Me.C1FlexGrid2.TabIndex = 4
        '
        'FrmRelated
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 276)
        Me.Controls.Add(Me.C1FlexGrid2)
        Me.Controls.Add(Me.FCustID)
        Me.Controls.Add(Me.C1FlexGrid1)
        Me.Controls.Add(Me.ButOK)
        Me.Controls.Add(Me.ButChanle)
        Me.Controls.Add(Me.ButSearch)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmRelated"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "关联窗体"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.ButSearch, 0)
        Me.Controls.SetChildIndex(Me.ButChanle, 0)
        Me.Controls.SetChildIndex(Me.ButOK, 0)
        Me.Controls.SetChildIndex(Me.C1FlexGrid1, 0)
        Me.Controls.SetChildIndex(Me.FCustID, 0)
        Me.Controls.SetChildIndex(Me.C1FlexGrid2, 0)
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FCustID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ButOK As System.Windows.Forms.Button
    Friend WithEvents ButChanle As System.Windows.Forms.Button
    Friend WithEvents FCustID As C1.Win.C1Input.C1TextBox
    Friend WithEvents ButSearch As System.Windows.Forms.Button
    Friend WithEvents C1FlexGrid2 As C1.Win.C1FlexGrid.C1FlexGrid
End Class
