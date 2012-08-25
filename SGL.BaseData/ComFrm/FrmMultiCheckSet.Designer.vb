<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMultiCheckSet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMultiCheckSet))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheFCurrency = New System.Windows.Forms.CheckBox()
        Me.CheMultiCheckAmount = New System.Windows.Forms.CheckBox()
        Me.FMaxCheckLevel = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FCheckLevel = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheIsUse = New System.Windows.Forms.CheckBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButDel = New System.Windows.Forms.Button()
        Me.ButSel = New System.Windows.Forms.Button()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.C1FlexGrid2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.C1FlexGrid3 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.C1FlexGrid4 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.C1FlexGrid5 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.C1FlexGrid6 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.C1FlexGrid7 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.C1FlexGrid9 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.C1FlexGrid8 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ButChale = New System.Windows.Forms.Button()
        Me.ButOK = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.FMaxCheckLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FCheckLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.C1FlexGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        CType(Me.C1FlexGrid4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage7.SuspendLayout()
        CType(Me.C1FlexGrid5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage8.SuspendLayout()
        CType(Me.C1FlexGrid6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage9.SuspendLayout()
        CType(Me.C1FlexGrid7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.C1FlexGrid9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.C1FlexGrid8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(1, 10)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(506, 328)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.CheckBox3)
        Me.TabPage1.Controls.Add(Me.CheckBox2)
        Me.TabPage1.Controls.Add(Me.CheckBox1)
        Me.TabPage1.Controls.Add(Me.CheFCurrency)
        Me.TabPage1.Controls.Add(Me.CheMultiCheckAmount)
        Me.TabPage1.Controls.Add(Me.FMaxCheckLevel)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.FCheckLevel)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.CheIsUse)
        Me.TabPage1.Location = New System.Drawing.Point(4, 21)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(498, 303)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "审核基础设置"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Enabled = False
        Me.CheckBox3.Location = New System.Drawing.Point(6, 203)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(252, 16)
        Me.CheckBox3.TabIndex = 4
        Me.CheckBox3.Text = "上一审核组的人只能审核同一组人员的单据"
        Me.CheckBox3.UseVisualStyleBackColor = True
        Me.CheckBox3.Visible = False
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Enabled = False
        Me.CheckBox2.Location = New System.Drawing.Point(6, 167)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(168, 16)
        Me.CheckBox2.TabIndex = 4
        Me.CheckBox2.Text = "修改无需反审核到最低一级"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(8, 133)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(132, 16)
        Me.CheckBox1.TabIndex = 4
        Me.CheckBox1.Text = "审核时必须逐级进行"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheFCurrency
        '
        Me.CheFCurrency.AutoSize = True
        Me.CheFCurrency.Enabled = False
        Me.CheFCurrency.Location = New System.Drawing.Point(6, 99)
        Me.CheFCurrency.Name = "CheFCurrency"
        Me.CheFCurrency.Size = New System.Drawing.Size(132, 16)
        Me.CheFCurrency.TabIndex = 3
        Me.CheFCurrency.Text = "按金额确认审核级次"
        Me.CheFCurrency.UseVisualStyleBackColor = True
        '
        'CheMultiCheckAmount
        '
        Me.CheMultiCheckAmount.AutoSize = True
        Me.CheMultiCheckAmount.Enabled = False
        Me.CheMultiCheckAmount.Location = New System.Drawing.Point(6, 62)
        Me.CheMultiCheckAmount.Name = "CheMultiCheckAmount"
        Me.CheMultiCheckAmount.Size = New System.Drawing.Size(132, 16)
        Me.CheMultiCheckAmount.TabIndex = 3
        Me.CheMultiCheckAmount.Text = "按金额确认多级审核"
        Me.CheMultiCheckAmount.UseVisualStyleBackColor = True
        '
        'FMaxCheckLevel
        '
        Me.FMaxCheckLevel.Location = New System.Drawing.Point(382, 29)
        Me.FMaxCheckLevel.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.FMaxCheckLevel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.FMaxCheckLevel.Name = "FMaxCheckLevel"
        Me.FMaxCheckLevel.Size = New System.Drawing.Size(38, 21)
        Me.FMaxCheckLevel.TabIndex = 2
        Me.FMaxCheckLevel.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(266, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "业务审核级次"
        '
        'FCheckLevel
        '
        Me.FCheckLevel.Location = New System.Drawing.Point(136, 29)
        Me.FCheckLevel.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.FCheckLevel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.FCheckLevel.Name = "FCheckLevel"
        Me.FCheckLevel.Size = New System.Drawing.Size(38, 21)
        Me.FCheckLevel.TabIndex = 2
        Me.FCheckLevel.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "多级审核级次设定"
        '
        'CheIsUse
        '
        Me.CheIsUse.AutoSize = True
        Me.CheIsUse.Location = New System.Drawing.Point(8, 9)
        Me.CheIsUse.Name = "CheIsUse"
        Me.CheIsUse.Size = New System.Drawing.Size(96, 16)
        Me.CheIsUse.TabIndex = 0
        Me.CheIsUse.Text = "启动多级审核"
        Me.CheIsUse.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel1)
        Me.TabPage2.Controls.Add(Me.ButDel)
        Me.TabPage2.Controls.Add(Me.ButSel)
        Me.TabPage2.Controls.Add(Me.TabControl2)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.C1FlexGrid1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 21)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(498, 303)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "审核权限设置"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(481, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(10, 19)
        Me.Panel1.TabIndex = 4
        '
        'ButDel
        '
        Me.ButDel.Location = New System.Drawing.Point(140, 170)
        Me.ButDel.Name = "ButDel"
        Me.ButDel.Size = New System.Drawing.Size(46, 23)
        Me.ButDel.TabIndex = 3
        Me.ButDel.Text = "< -"
        Me.ButDel.UseVisualStyleBackColor = True
        '
        'ButSel
        '
        Me.ButSel.Location = New System.Drawing.Point(140, 109)
        Me.ButSel.Name = "ButSel"
        Me.ButSel.Size = New System.Drawing.Size(46, 23)
        Me.ButSel.TabIndex = 3
        Me.ButSel.Text = "- >"
        Me.ButSel.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Controls.Add(Me.TabPage5)
        Me.TabControl2.Controls.Add(Me.TabPage6)
        Me.TabControl2.Controls.Add(Me.TabPage7)
        Me.TabControl2.Controls.Add(Me.TabPage8)
        Me.TabControl2.Controls.Add(Me.TabPage9)
        Me.TabControl2.Location = New System.Drawing.Point(192, 33)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(300, 264)
        Me.TabControl2.TabIndex = 2
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.C1FlexGrid2)
        Me.TabPage4.Location = New System.Drawing.Point(4, 21)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(292, 239)
        Me.TabPage4.TabIndex = 0
        Me.TabPage4.Text = "一级"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'C1FlexGrid2
        '
        Me.C1FlexGrid2.ColumnInfo = "3,1,0,0,0,0,Columns:1{Name:""FCheckerID"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:230;Name:""CCheckerName"";Caption" & _
            ":""审核人名称"";Style:""TextAlign:CenterCenter;"";StyleFixed:""TextAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9) & _
            ""
        Me.C1FlexGrid2.Location = New System.Drawing.Point(25, 4)
        Me.C1FlexGrid2.Name = "C1FlexGrid2"
        Me.C1FlexGrid2.Rows.Count = 1
        Me.C1FlexGrid2.Rows.DefaultSize = 18
        Me.C1FlexGrid2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.C1FlexGrid2.Size = New System.Drawing.Size(242, 229)
        Me.C1FlexGrid2.StyleInfo = resources.GetString("C1FlexGrid2.StyleInfo")
        Me.C1FlexGrid2.TabIndex = 2
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.C1FlexGrid3)
        Me.TabPage5.Location = New System.Drawing.Point(4, 21)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(292, 239)
        Me.TabPage5.TabIndex = 1
        Me.TabPage5.Text = "二级"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'C1FlexGrid3
        '
        Me.C1FlexGrid3.ColumnInfo = "3,1,0,0,0,0,Columns:1{Name:""FCheckerID"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:230;Name:""CCheckerName"";Caption" & _
            ":""审核人名称"";Style:""TextAlign:CenterCenter;"";StyleFixed:""TextAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9) & _
            ""
        Me.C1FlexGrid3.Location = New System.Drawing.Point(25, 5)
        Me.C1FlexGrid3.Name = "C1FlexGrid3"
        Me.C1FlexGrid3.Rows.Count = 1
        Me.C1FlexGrid3.Rows.DefaultSize = 18
        Me.C1FlexGrid3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.C1FlexGrid3.Size = New System.Drawing.Size(242, 229)
        Me.C1FlexGrid3.StyleInfo = resources.GetString("C1FlexGrid3.StyleInfo")
        Me.C1FlexGrid3.TabIndex = 3
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.C1FlexGrid4)
        Me.TabPage6.Location = New System.Drawing.Point(4, 21)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(292, 239)
        Me.TabPage6.TabIndex = 2
        Me.TabPage6.Text = "三级"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'C1FlexGrid4
        '
        Me.C1FlexGrid4.ColumnInfo = "3,1,0,0,0,0,Columns:1{Name:""FCheckerID"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:230;Name:""CCheckerName"";Caption" & _
            ":""审核人名称"";Style:""TextAlign:CenterCenter;"";StyleFixed:""TextAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9) & _
            ""
        Me.C1FlexGrid4.Location = New System.Drawing.Point(25, 5)
        Me.C1FlexGrid4.Name = "C1FlexGrid4"
        Me.C1FlexGrid4.Rows.Count = 1
        Me.C1FlexGrid4.Rows.DefaultSize = 18
        Me.C1FlexGrid4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.C1FlexGrid4.Size = New System.Drawing.Size(242, 229)
        Me.C1FlexGrid4.StyleInfo = resources.GetString("C1FlexGrid4.StyleInfo")
        Me.C1FlexGrid4.TabIndex = 3
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.C1FlexGrid5)
        Me.TabPage7.Location = New System.Drawing.Point(4, 21)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(292, 239)
        Me.TabPage7.TabIndex = 3
        Me.TabPage7.Text = "四级"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'C1FlexGrid5
        '
        Me.C1FlexGrid5.ColumnInfo = "3,1,0,0,0,0,Columns:1{Name:""FCheckerID"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:230;Name:""CCheckerName"";Caption" & _
            ":""审核人名称"";Style:""TextAlign:CenterCenter;"";StyleFixed:""TextAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9) & _
            ""
        Me.C1FlexGrid5.Location = New System.Drawing.Point(25, 5)
        Me.C1FlexGrid5.Name = "C1FlexGrid5"
        Me.C1FlexGrid5.Rows.Count = 1
        Me.C1FlexGrid5.Rows.DefaultSize = 18
        Me.C1FlexGrid5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.C1FlexGrid5.Size = New System.Drawing.Size(242, 229)
        Me.C1FlexGrid5.StyleInfo = resources.GetString("C1FlexGrid5.StyleInfo")
        Me.C1FlexGrid5.TabIndex = 3
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.C1FlexGrid6)
        Me.TabPage8.Location = New System.Drawing.Point(4, 21)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage8.Size = New System.Drawing.Size(292, 239)
        Me.TabPage8.TabIndex = 4
        Me.TabPage8.Text = "五级"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'C1FlexGrid6
        '
        Me.C1FlexGrid6.ColumnInfo = "3,1,0,0,0,0,Columns:1{Name:""FCheckerID"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:230;Name:""CCheckerName"";Caption" & _
            ":""审核人名称"";Style:""TextAlign:CenterCenter;"";StyleFixed:""TextAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9) & _
            ""
        Me.C1FlexGrid6.Location = New System.Drawing.Point(25, 5)
        Me.C1FlexGrid6.Name = "C1FlexGrid6"
        Me.C1FlexGrid6.Rows.Count = 1
        Me.C1FlexGrid6.Rows.DefaultSize = 18
        Me.C1FlexGrid6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.C1FlexGrid6.Size = New System.Drawing.Size(242, 229)
        Me.C1FlexGrid6.StyleInfo = resources.GetString("C1FlexGrid6.StyleInfo")
        Me.C1FlexGrid6.TabIndex = 3
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add(Me.C1FlexGrid7)
        Me.TabPage9.Location = New System.Drawing.Point(4, 21)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage9.Size = New System.Drawing.Size(292, 239)
        Me.TabPage9.TabIndex = 5
        Me.TabPage9.Text = "六级"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'C1FlexGrid7
        '
        Me.C1FlexGrid7.ColumnInfo = "3,1,0,0,0,0,Columns:1{Name:""FCheckerID"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:230;Name:""CCheckerName"";Caption" & _
            ":""审核人名称"";Style:""TextAlign:CenterCenter;"";StyleFixed:""TextAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9) & _
            ""
        Me.C1FlexGrid7.Location = New System.Drawing.Point(25, 5)
        Me.C1FlexGrid7.Name = "C1FlexGrid7"
        Me.C1FlexGrid7.Rows.Count = 1
        Me.C1FlexGrid7.Rows.DefaultSize = 18
        Me.C1FlexGrid7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.C1FlexGrid7.Size = New System.Drawing.Size(242, 229)
        Me.C1FlexGrid7.StyleInfo = resources.GetString("C1FlexGrid7.StyleInfo")
        Me.C1FlexGrid7.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(194, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "审核级次"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "用户列表"
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.ColumnInfo = "3,1,0,0,0,0,Columns:1{Name:""FUserID"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:110;Name:""FName"";Caption:""用户名称"";St" & _
            "yle:""TextAlign:LeftCenter;"";StyleFixed:""TextAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.C1FlexGrid1.Location = New System.Drawing.Point(6, 33)
        Me.C1FlexGrid1.Name = "C1FlexGrid1"
        Me.C1FlexGrid1.Rows.DefaultSize = 18
        Me.C1FlexGrid1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.C1FlexGrid1.Size = New System.Drawing.Size(131, 267)
        Me.C1FlexGrid1.StyleInfo = resources.GetString("C1FlexGrid1.StyleInfo")
        Me.C1FlexGrid1.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 21)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(498, 303)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "关联菜单设置"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.C1FlexGrid9)
        Me.GroupBox2.Location = New System.Drawing.Point(246, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(240, 291)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "序时簿菜单"
        '
        'C1FlexGrid9
        '
        Me.C1FlexGrid9.ColumnInfo = resources.GetString("C1FlexGrid9.ColumnInfo")
        Me.C1FlexGrid9.Location = New System.Drawing.Point(6, 20)
        Me.C1FlexGrid9.Name = "C1FlexGrid9"
        Me.C1FlexGrid9.Rows.DefaultSize = 18
        Me.C1FlexGrid9.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.C1FlexGrid9.Size = New System.Drawing.Size(228, 265)
        Me.C1FlexGrid9.StyleInfo = resources.GetString("C1FlexGrid9.StyleInfo")
        Me.C1FlexGrid9.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.C1FlexGrid8)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(228, 291)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "单据菜单"
        '
        'C1FlexGrid8
        '
        Me.C1FlexGrid8.ColumnInfo = resources.GetString("C1FlexGrid8.ColumnInfo")
        Me.C1FlexGrid8.Location = New System.Drawing.Point(6, 20)
        Me.C1FlexGrid8.Name = "C1FlexGrid8"
        Me.C1FlexGrid8.Rows.DefaultSize = 18
        Me.C1FlexGrid8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.C1FlexGrid8.Size = New System.Drawing.Size(216, 265)
        Me.C1FlexGrid8.StyleInfo = resources.GetString("C1FlexGrid8.StyleInfo")
        Me.C1FlexGrid8.TabIndex = 4
        '
        'ButChale
        '
        Me.ButChale.Location = New System.Drawing.Point(254, 344)
        Me.ButChale.Name = "ButChale"
        Me.ButChale.Size = New System.Drawing.Size(78, 27)
        Me.ButChale.TabIndex = 2
        Me.ButChale.Text = "取 消"
        Me.ButChale.UseVisualStyleBackColor = True
        '
        'ButOK
        '
        Me.ButOK.Location = New System.Drawing.Point(395, 344)
        Me.ButOK.Name = "ButOK"
        Me.ButOK.Size = New System.Drawing.Size(78, 27)
        Me.ButOK.TabIndex = 2
        Me.ButOK.Text = "确 定"
        Me.ButOK.UseVisualStyleBackColor = True
        '
        'FrmMultiCheckSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 387)
        Me.Controls.Add(Me.ButOK)
        Me.Controls.Add(Me.ButChale)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmMultiCheckSet"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "多级审核设置界面"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.ButChale, 0)
        Me.Controls.SetChildIndex(Me.ButOK, 0)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.FMaxCheckLevel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FCheckLevel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        CType(Me.C1FlexGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        CType(Me.C1FlexGrid4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage7.ResumeLayout(False)
        CType(Me.C1FlexGrid5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage8.ResumeLayout(False)
        CType(Me.C1FlexGrid6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage9.ResumeLayout(False)
        CType(Me.C1FlexGrid7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.C1FlexGrid9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.C1FlexGrid8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents CheMultiCheckAmount As System.Windows.Forms.CheckBox
    Friend WithEvents FCheckLevel As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheIsUse As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents CheFCurrency As System.Windows.Forms.CheckBox
    Friend WithEvents FMaxCheckLevel As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ButDel As System.Windows.Forms.Button
    Friend WithEvents ButSel As System.Windows.Forms.Button
    Friend WithEvents C1FlexGrid2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FlexGrid3 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FlexGrid4 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FlexGrid5 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FlexGrid6 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FlexGrid7 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FlexGrid8 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents C1FlexGrid9 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ButChale As System.Windows.Forms.Button
    Friend WithEvents ButOK As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
