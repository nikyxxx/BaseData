<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPublicQueryList
    Inherits SGL.BaseData.frmQueryBase

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPublicQueryList))
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtNumber = New System.Windows.Forms.TextBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.CtgrdSubMessage = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.pnlTop.SuspendLayout()
        CType(Me.CtgrdSubMessage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTop
        '
        Me.pnlTop.Controls.Add(Me.Button1)
        Me.pnlTop.Controls.Add(Me.Label2)
        Me.pnlTop.Controls.Add(Me.Label1)
        Me.pnlTop.Controls.Add(Me.txtName)
        Me.pnlTop.Controls.Add(Me.txtNumber)
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(682, 61)
        Me.pnlTop.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(505, 31)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "过滤"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(239, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "名称："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "代码："
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(286, 33)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(193, 21)
        Me.txtName.TabIndex = 2
        '
        'txtNumber
        '
        Me.txtNumber.Location = New System.Drawing.Point(59, 34)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(164, 21)
        Me.txtNumber.TabIndex = 1
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(3, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(65, 12)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "辅助资料－"
        '
        'CtgrdSubMessage
        '
        Me.CtgrdSubMessage.AllowSort = False
        Me.CtgrdSubMessage.AllowUpdate = False
        Me.CtgrdSubMessage.AllowUpdateOnBlur = False
        Me.CtgrdSubMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtgrdSubMessage.EmptyRows = True
        Me.CtgrdSubMessage.ExtendRightColumn = True
        Me.CtgrdSubMessage.GroupByCaption = "Drag a column header here to group by that column"
        Me.CtgrdSubMessage.Images.Add(CType(resources.GetObject("CtgrdSubMessage.Images"), System.Drawing.Image))
        Me.CtgrdSubMessage.Location = New System.Drawing.Point(0, 0)
        Me.CtgrdSubMessage.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedRowBorder
        Me.CtgrdSubMessage.Name = "CtgrdSubMessage"
        Me.CtgrdSubMessage.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.CtgrdSubMessage.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.CtgrdSubMessage.PreviewInfo.ZoomFactor = 75.0R
        Me.CtgrdSubMessage.PrintInfo.PageSettings = CType(resources.GetObject("CtgrdSubMessage.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.CtgrdSubMessage.Size = New System.Drawing.Size(682, 312)
        Me.CtgrdSubMessage.TabIndex = 0
        Me.CtgrdSubMessage.Text = "C1TrueDBGrid1"
        Me.CtgrdSubMessage.PropBag = resources.GetString("CtgrdSubMessage.PropBag")
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.pnlBottom)
        Me.pnlMain.Controls.Add(Me.pnlTop)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(682, 373)
        Me.pnlMain.TabIndex = 1
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.CtgrdSubMessage)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBottom.Location = New System.Drawing.Point(0, 61)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(682, 312)
        Me.pnlBottom.TabIndex = 1
        '
        'frmPublicQueryList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 373)
        Me.Controls.Add(Me.pnlMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPublicQueryList"
        Me.Text = "辅助资料管理"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        CType(Me.CtgrdSubMessage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents CtgrdSubMessage As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtNumber As System.Windows.Forms.TextBox
End Class
