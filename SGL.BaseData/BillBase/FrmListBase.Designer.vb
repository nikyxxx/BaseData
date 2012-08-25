<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListBase
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListBase))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.m_ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.L9 = New System.Windows.Forms.Label()
        Me.L10 = New System.Windows.Forms.Label()
        Me.L7 = New System.Windows.Forms.Label()
        Me.L8 = New System.Windows.Forms.Label()
        Me.L5 = New System.Windows.Forms.Label()
        Me.L3 = New System.Windows.Forms.Label()
        Me.L4 = New System.Windows.Forms.Label()
        Me.L6 = New System.Windows.Forms.Label()
        Me.L2 = New System.Windows.Forms.Label()
        Me.L1 = New System.Windows.Forms.Label()
        Me.BW_cellformat = New System.ComponentModel.BackgroundWorker()
        Me.PanelList = New System.Windows.Forms.Panel()
        Me.C2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ctxtSupply = New C1.Win.C1Input.C1TextBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.PanelList.SuspendLayout()
        CType(Me.C2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ctxtSupply, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.m_ToolStrip)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(902, 92)
        Me.Panel1.TabIndex = 1
        '
        'm_ToolStrip
        '
        Me.m_ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.m_ToolStrip.Name = "m_ToolStrip"
        Me.m_ToolStrip.Size = New System.Drawing.Size(902, 25)
        Me.m_ToolStrip.TabIndex = 609
        Me.m_ToolStrip.Text = "ToolStrip1"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.BackgroundImage = CType(resources.GetObject("GroupBox1.BackgroundImage"), System.Drawing.Image)
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox1.Controls.Add(Me.L9)
        Me.GroupBox1.Controls.Add(Me.L10)
        Me.GroupBox1.Controls.Add(Me.L7)
        Me.GroupBox1.Controls.Add(Me.L8)
        Me.GroupBox1.Controls.Add(Me.L5)
        Me.GroupBox1.Controls.Add(Me.L3)
        Me.GroupBox1.Controls.Add(Me.L4)
        Me.GroupBox1.Controls.Add(Me.L6)
        Me.GroupBox1.Controls.Add(Me.L2)
        Me.GroupBox1.Controls.Add(Me.L1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(902, 92)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'L9
        '
        Me.L9.AutoSize = True
        Me.L9.BackColor = System.Drawing.Color.Transparent
        Me.L9.Location = New System.Drawing.Point(819, 3)
        Me.L9.Name = "L9"
        Me.L9.Size = New System.Drawing.Size(0, 12)
        Me.L9.TabIndex = 607
        '
        'L10
        '
        Me.L10.AutoSize = True
        Me.L10.BackColor = System.Drawing.Color.Transparent
        Me.L10.Location = New System.Drawing.Point(819, 23)
        Me.L10.Name = "L10"
        Me.L10.Size = New System.Drawing.Size(0, 12)
        Me.L10.TabIndex = 606
        '
        'L7
        '
        Me.L7.AutoSize = True
        Me.L7.BackColor = System.Drawing.Color.Transparent
        Me.L7.Location = New System.Drawing.Point(734, 9)
        Me.L7.Name = "L7"
        Me.L7.Size = New System.Drawing.Size(0, 12)
        Me.L7.TabIndex = 605
        '
        'L8
        '
        Me.L8.AutoSize = True
        Me.L8.BackColor = System.Drawing.Color.Transparent
        Me.L8.Location = New System.Drawing.Point(734, 29)
        Me.L8.Name = "L8"
        Me.L8.Size = New System.Drawing.Size(0, 12)
        Me.L8.TabIndex = 604
        '
        'L5
        '
        Me.L5.AutoSize = True
        Me.L5.BackColor = System.Drawing.Color.Transparent
        Me.L5.Location = New System.Drawing.Point(501, 11)
        Me.L5.Name = "L5"
        Me.L5.Size = New System.Drawing.Size(0, 12)
        Me.L5.TabIndex = 603
        '
        'L3
        '
        Me.L3.AutoSize = True
        Me.L3.BackColor = System.Drawing.Color.Transparent
        Me.L3.Location = New System.Drawing.Point(236, 10)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(0, 12)
        Me.L3.TabIndex = 602
        '
        'L4
        '
        Me.L4.AutoSize = True
        Me.L4.BackColor = System.Drawing.Color.Transparent
        Me.L4.Location = New System.Drawing.Point(236, 30)
        Me.L4.Name = "L4"
        Me.L4.Size = New System.Drawing.Size(0, 12)
        Me.L4.TabIndex = 601
        '
        'L6
        '
        Me.L6.AutoSize = True
        Me.L6.BackColor = System.Drawing.Color.Transparent
        Me.L6.Location = New System.Drawing.Point(501, 31)
        Me.L6.Name = "L6"
        Me.L6.Size = New System.Drawing.Size(0, 12)
        Me.L6.TabIndex = 599
        '
        'L2
        '
        Me.L2.AutoSize = True
        Me.L2.BackColor = System.Drawing.Color.Transparent
        Me.L2.Location = New System.Drawing.Point(12, 30)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(0, 12)
        Me.L2.TabIndex = 597
        '
        'L1
        '
        Me.L1.AutoSize = True
        Me.L1.BackColor = System.Drawing.Color.Transparent
        Me.L1.Location = New System.Drawing.Point(12, 11)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(0, 12)
        Me.L1.TabIndex = 595
        '
        'PanelList
        '
        Me.PanelList.Controls.Add(Me.C2)
        Me.PanelList.Controls.Add(Me.C1FlexGrid1)
        Me.PanelList.Controls.Add(Me.ctxtSupply)
        Me.PanelList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelList.Location = New System.Drawing.Point(0, 92)
        Me.PanelList.Name = "PanelList"
        Me.PanelList.Size = New System.Drawing.Size(902, 406)
        Me.PanelList.TabIndex = 191
        '
        'C2
        '
        Me.C2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C2.ColumnInfo = "44,1,0,0,0,0,Columns:0{Width:50;}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Width:150;}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:150;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.C2.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Me.C2.Location = New System.Drawing.Point(3, 371)
        Me.C2.Name = "C2"
        Me.C2.Rows.Count = 1
        Me.C2.Rows.DefaultSize = 18
        Me.C2.Rows.Fixed = 0
        Me.C2.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.C2.Size = New System.Drawing.Size(901, 38)
        Me.C2.StyleInfo = resources.GetString("C2.StyleInfo")
        Me.C2.TabIndex = 231
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FlexGrid1.AllowEditing = False
        Me.C1FlexGrid1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FlexGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1FlexGrid1.ColumnInfo = resources.GetString("C1FlexGrid1.ColumnInfo")
        Me.C1FlexGrid1.Location = New System.Drawing.Point(2, 3)
        Me.C1FlexGrid1.Name = "C1FlexGrid1"
        Me.C1FlexGrid1.Rows.DefaultSize = 18
        Me.C1FlexGrid1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.C1FlexGrid1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.C1FlexGrid1.Size = New System.Drawing.Size(901, 371)
        Me.C1FlexGrid1.StyleInfo = resources.GetString("C1FlexGrid1.StyleInfo")
        Me.C1FlexGrid1.TabIndex = 178
        '
        'ctxtSupply
        '
        Me.ctxtSupply.Location = New System.Drawing.Point(493, 97)
        Me.ctxtSupply.Name = "ctxtSupply"
        Me.ctxtSupply.Size = New System.Drawing.Size(120, 21)
        Me.ctxtSupply.TabIndex = 1
        Me.ctxtSupply.Tag = Nothing
        Me.ctxtSupply.Visible = False
        '
        'FrmListBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 498)
        Me.Controls.Add(Me.PanelList)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmListBase"
        Me.Text = "FrmListBase"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.PanelList, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PanelList.ResumeLayout(False)
        CType(Me.C2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ctxtSupply, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents L9 As System.Windows.Forms.Label
    Friend WithEvents L10 As System.Windows.Forms.Label
    Friend WithEvents L7 As System.Windows.Forms.Label
    Friend WithEvents L8 As System.Windows.Forms.Label
    Friend WithEvents L5 As System.Windows.Forms.Label
    Friend WithEvents L3 As System.Windows.Forms.Label
    Friend WithEvents L4 As System.Windows.Forms.Label
    Friend WithEvents L6 As System.Windows.Forms.Label
    Friend WithEvents L2 As System.Windows.Forms.Label
    Friend WithEvents L1 As System.Windows.Forms.Label
    Friend WithEvents BW_cellformat As System.ComponentModel.BackgroundWorker
    Friend WithEvents m_ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents PanelList As System.Windows.Forms.Panel
    Friend WithEvents C2 As C1.Win.C1FlexGrid.C1FlexGrid
    Public WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
    Public WithEvents ctxtSupply As C1.Win.C1Input.C1TextBox
End Class
