<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTH
    Inherits PublicSharedResource.frmBase

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTH))
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ButOk = New System.Windows.Forms.Button()
        Me.ButChanle = New System.Windows.Forms.Button()
        Me.ButDelRow = New System.Windows.Forms.Button()
        Me.ButAddRow = New System.Windows.Forms.Button()
        Me.ButTH = New System.Windows.Forms.Button()
        Me.ButTHChinal = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.C1FlexGrid2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cb_NeedSwape = New System.Windows.Forms.CheckBox()
        Me.RadioButHB = New System.Windows.Forms.RadioButton()
        Me.RadioButJJ = New System.Windows.Forms.RadioButton()
        Me.FNeedSwape = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.ColumnInfo = resources.GetString("C1FlexGrid1.ColumnInfo")
        Me.C1FlexGrid1.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1FlexGrid1.Location = New System.Drawing.Point(3, 34)
        Me.C1FlexGrid1.Name = "C1FlexGrid1"
        Me.C1FlexGrid1.Rows.Count = 2
        Me.C1FlexGrid1.Rows.DefaultSize = 22
        Me.C1FlexGrid1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.C1FlexGrid1.Size = New System.Drawing.Size(344, 50)
        Me.C1FlexGrid1.StyleInfo = resources.GetString("C1FlexGrid1.StyleInfo")
        Me.C1FlexGrid1.TabIndex = 0
        '
        'ButOk
        '
        Me.ButOk.Location = New System.Drawing.Point(353, 238)
        Me.ButOk.Name = "ButOk"
        Me.ButOk.Size = New System.Drawing.Size(75, 23)
        Me.ButOk.TabIndex = 1
        Me.ButOk.Text = "确 定"
        Me.ButOk.UseVisualStyleBackColor = True
        '
        'ButChanle
        '
        Me.ButChanle.Location = New System.Drawing.Point(353, 281)
        Me.ButChanle.Name = "ButChanle"
        Me.ButChanle.Size = New System.Drawing.Size(75, 23)
        Me.ButChanle.TabIndex = 2
        Me.ButChanle.Text = "取 消"
        Me.ButChanle.UseVisualStyleBackColor = True
        '
        'ButDelRow
        '
        Me.ButDelRow.Location = New System.Drawing.Point(353, 195)
        Me.ButDelRow.Name = "ButDelRow"
        Me.ButDelRow.Size = New System.Drawing.Size(75, 23)
        Me.ButDelRow.TabIndex = 3
        Me.ButDelRow.Text = "删 行"
        Me.ButDelRow.UseVisualStyleBackColor = True
        '
        'ButAddRow
        '
        Me.ButAddRow.Location = New System.Drawing.Point(353, 152)
        Me.ButAddRow.Name = "ButAddRow"
        Me.ButAddRow.Size = New System.Drawing.Size(75, 23)
        Me.ButAddRow.TabIndex = 4
        Me.ButAddRow.Text = "添 行"
        Me.ButAddRow.UseVisualStyleBackColor = True
        '
        'ButTH
        '
        Me.ButTH.Location = New System.Drawing.Point(71, 352)
        Me.ButTH.Name = "ButTH"
        Me.ButTH.Size = New System.Drawing.Size(45, 23)
        Me.ButTH.TabIndex = 4
        Me.ButTH.Text = "替 换"
        Me.ButTH.UseVisualStyleBackColor = True
        Me.ButTH.Visible = False
        '
        'ButTHChinal
        '
        Me.ButTHChinal.Location = New System.Drawing.Point(20, 352)
        Me.ButTHChinal.Name = "ButTHChinal"
        Me.ButTHChinal.Size = New System.Drawing.Size(45, 23)
        Me.ButTHChinal.TabIndex = 4
        Me.ButTHChinal.Text = "撤 销"
        Me.ButTHChinal.UseVisualStyleBackColor = True
        Me.ButTHChinal.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "原物料"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "替换物料"
        '
        'C1FlexGrid2
        '
        Me.C1FlexGrid2.ColumnInfo = resources.GetString("C1FlexGrid2.ColumnInfo")
        Me.C1FlexGrid2.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1FlexGrid2.Location = New System.Drawing.Point(3, 128)
        Me.C1FlexGrid2.Name = "C1FlexGrid2"
        Me.C1FlexGrid2.Rows.Count = 8
        Me.C1FlexGrid2.Rows.DefaultSize = 22
        Me.C1FlexGrid2.Size = New System.Drawing.Size(344, 176)
        Me.C1FlexGrid2.StyleInfo = resources.GetString("C1FlexGrid2.StyleInfo")
        Me.C1FlexGrid2.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cb_NeedSwape)
        Me.GroupBox1.Controls.Add(Me.RadioButHB)
        Me.GroupBox1.Controls.Add(Me.RadioButJJ)
        Me.GroupBox1.Location = New System.Drawing.Point(84, 82)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(263, 42)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'cb_NeedSwape
        '
        Me.cb_NeedSwape.AutoSize = True
        Me.cb_NeedSwape.Location = New System.Drawing.Point(155, 15)
        Me.cb_NeedSwape.Name = "cb_NeedSwape"
        Me.cb_NeedSwape.Size = New System.Drawing.Size(72, 16)
        Me.cb_NeedSwape.TabIndex = 2
        Me.cb_NeedSwape.Text = "订单出库"
        Me.cb_NeedSwape.UseVisualStyleBackColor = True
        '
        'RadioButHB
        '
        Me.RadioButHB.AutoSize = True
        Me.RadioButHB.Checked = True
        Me.RadioButHB.Location = New System.Drawing.Point(78, 15)
        Me.RadioButHB.Name = "RadioButHB"
        Me.RadioButHB.Size = New System.Drawing.Size(47, 16)
        Me.RadioButHB.TabIndex = 1
        Me.RadioButHB.TabStop = True
        Me.RadioButHB.Text = "换标"
        Me.RadioButHB.UseVisualStyleBackColor = True
        '
        'RadioButJJ
        '
        Me.RadioButJJ.AutoSize = True
        Me.RadioButJJ.Location = New System.Drawing.Point(19, 15)
        Me.RadioButJJ.Name = "RadioButJJ"
        Me.RadioButJJ.Size = New System.Drawing.Size(47, 16)
        Me.RadioButJJ.TabIndex = 0
        Me.RadioButJJ.Text = "降级"
        Me.RadioButJJ.UseVisualStyleBackColor = True
        '
        'FNeedSwape
        '
        Me.FNeedSwape.AutoSize = True
        Me.FNeedSwape.Location = New System.Drawing.Point(155, 15)
        Me.FNeedSwape.Name = "FNeedSwape"
        Me.FNeedSwape.Size = New System.Drawing.Size(72, 16)
        Me.FNeedSwape.TabIndex = 2
        Me.FNeedSwape.Text = "物料置换"
        Me.FNeedSwape.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(3, 316)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(383, 24)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "*[订单出库]勾选后，表示用发货通知单上的物料替换实际发货的物料；" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "反之，则只显示实际扫描发货的物料；"
        '
        'FrmTH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 340)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButAddRow)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ButTHChinal)
        Me.Controls.Add(Me.ButDelRow)
        Me.Controls.Add(Me.ButTH)
        Me.Controls.Add(Me.ButChanle)
        Me.Controls.Add(Me.ButOk)
        Me.Controls.Add(Me.C1FlexGrid1)
        Me.Controls.Add(Me.C1FlexGrid2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "替换窗体"
        Me.Controls.SetChildIndex(Me.C1FlexGrid2, 0)
        Me.Controls.SetChildIndex(Me.C1FlexGrid1, 0)
        Me.Controls.SetChildIndex(Me.ButOk, 0)
        Me.Controls.SetChildIndex(Me.ButChanle, 0)
        Me.Controls.SetChildIndex(Me.ButTH, 0)
        Me.Controls.SetChildIndex(Me.ButDelRow, 0)
        Me.Controls.SetChildIndex(Me.ButTHChinal, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.ButAddRow, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ButOk As System.Windows.Forms.Button
    Friend WithEvents ButChanle As System.Windows.Forms.Button
    Friend WithEvents ButDelRow As System.Windows.Forms.Button
    Friend WithEvents ButAddRow As System.Windows.Forms.Button
    Friend WithEvents ButTH As System.Windows.Forms.Button
    Friend WithEvents ButTHChinal As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents C1FlexGrid2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButHB As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButJJ As System.Windows.Forms.RadioButton
    Friend WithEvents cb_NeedSwape As System.Windows.Forms.CheckBox
    Friend WithEvents FNeedSwape As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
