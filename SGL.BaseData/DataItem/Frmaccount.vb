Imports SGL.BLL



Public Class Frmaccount
#Region "成员变量声明"

    Private m_dsItemsInfo As New DataSet
    Private m_dsItemsInfo2 As New DataSet
    Private accountdata As New DataSet
    Private m_strItemClassName As String
    Public S_Classid As Integer = 0
    Public constr As String
    Private DBOpen As SGL.BLL.BLuser
    Public RtnDataTable As New DataSet
    Private Sglstr As String
#End Region
    Private Sub InitPage()
        Try
            Me.cobSearchType.Items.Add("科目代码")
            Me.cobSearchType.Items.Add("科目名称")
         

            Me.txtTypeName.Text = Me.m_strItemClassName
            Me.cobMatchingType.SelectedIndex = 0
            Me.cobSearchType.SelectedIndex = 0

            grdItemsBind("", "")
            Me.C1FlexGrid1.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FrmItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' If S_Classid > 0 Then
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        InitPage()
        ItemsTreeBind()
        C1FlexGrid1.Focus()
    End Sub
    Private Sub ItemsTreeBind()
        Dim topNode As New TreeNode
        Dim drItem As DataRow


        Try
            '取得所有的核算项目信息

            Me.trvItems.Nodes.Clear()
            Sglstr = "Select FClassID,FGroupID,FName AS FName, Fmodifytime,UUID From t_AcctGroup Order By FClassID, FGroupID "

            DBOpen = New BLuser
            m_dsItemsInfo2 = DBOpen.GetDataset(Sglstr, constr)

            Sglstr = "select * from T_account where  FDetail=0    order by fnumber "

            accountdata = DBOpen.GetDataset(Sglstr, constr)
            '添加根节点
            topNode.Text = "科目项目" & txtTypeName.Text
            topNode.Name = "-1000"
            topNode.Tag = ""
            topNode.ImageKey = "tree_folder_close.gif"
            topNode.SelectedImageKey = "tree_folder_open.gif"
            topNode.Expand()
            Me.trvItems.Nodes.Add(topNode)
            '添加科目第一层子接点
            If m_dsItemsInfo2.Tables.Count > 0 Then
                For Each drItem In m_dsItemsInfo2.Tables(0).Select("FGroupID = 0")
                    Dim FirstLevelNode As New TreeNode

                    FirstLevelNode.Text = drItem("FName").ToString
                    FirstLevelNode.Name = drItem("FClassID")
                    FirstLevelNode.Tag = 1

                    FirstLevelNode.ImageKey = "tree_jobcategory.gif"
                    ''FirstLevelNode.SelectedImageKey = "tree_job.gif"
                    'FirstLevelNode.ImageKey = "tree_folder_leaf.gif"
                    FirstLevelNode.SelectedImageKey = "tree_job.gif"


                    FirstLevelNode.Expand()
                    topNode.Nodes.Add(FirstLevelNode)
                    TreeSonNodeBind(FirstLevelNode, m_dsItemsInfo2, drItem("FClassID").ToString)
                Next
            End If

            topNode.Expand()
        Catch ex As Exception
            Throw ex
        Finally
            m_dsItemsInfo2.Dispose()
        End Try
    End Sub
    Private Sub TreeSonNodeBind(ByVal tNode As TreeNode, ByVal dsItemsInfo2 As DataSet, ByVal strItemID As String)
        Dim ChildNode As TreeNode

        Try
            'strItemID = PublicSharedResource.PublicSharedFunctions.GetSubString(tNode.Tag.ToString(), 1)
            For Each drItem As DataRow In m_dsItemsInfo2.Tables(0).Select(" FGroupID>0 and FClassID = " & strItemID)
                ChildNode = New TreeNode
                ChildNode.Text = drItem("FName")
                ChildNode.Name = drItem("FGroupID")
                ChildNode.Tag = 2
             
                ChildNode.ImageKey = "tree_folder_close.gif"
                ChildNode.SelectedImageKey = "tree_folder_open.gif"

                tNode.Nodes.Add(ChildNode)
                TreeSonNodeBindnew(ChildNode, accountdata, drItem("FGroupID").ToString)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
  
    Private Sub TreeSonNodeBindnew(ByVal tNode As TreeNode, ByVal dsItemsInfo2 As DataSet, ByVal strItemID As String)
        Dim ChildNode As TreeNode

        Try
            For Each drItem As DataRow In dsItemsInfo2.Tables(0).Select(" FParentID = 0 and FGroupID = " & strItemID)
                ChildNode = New TreeNode
                ChildNode.Text = drItem("FNumber").ToString & "-" & drItem("FName")
                ChildNode.Name = drItem("FNumber")
                ChildNode.Tag = drItem("faccountid").ToString() & "%" & drItem("FDetail").ToString() & "%" & drItem("FParentID").ToString()
                If drItem("FDetail") = 0 Then
                    ChildNode.ImageKey = "tree_folder_close.gif"
                    ChildNode.SelectedImageKey = "tree_folder_open.gif"
                Else
                    ChildNode.ImageKey = "tree_folder_leaf.gif"
                    ChildNode.SelectedImageKey = "tree_bigicon_end.gif"
                End If
                ChildNode.Expand()
                tNode.Nodes.Add(ChildNode)
                TreeSonNodeBindnew2(ChildNode, accountdata, drItem("faccountid").ToString)
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TreeSonNodeBindnew2(ByVal tNode As TreeNode, ByVal dsItemsInfo2 As DataSet, ByVal strItemID As String)
        Dim ChildNode As TreeNode

        Try
            For Each drItem As DataRow In dsItemsInfo2.Tables(0).Select("  FParentID = " & strItemID)
                ChildNode = New TreeNode
                ChildNode.Text = drItem("FNumber").ToString & "-" & drItem("FName")
                ChildNode.Name = drItem("FNumber")
                ChildNode.Tag = drItem("faccountid").ToString() & "%" & drItem("FDetail").ToString() & "%" & drItem("FParentID").ToString()
                If drItem("FDetail") = 0 Then
                    ChildNode.ImageKey = "tree_folder_close.gif"
                    ChildNode.SelectedImageKey = "tree_folder_open.gif"
                Else
                    ChildNode.ImageKey = "tree_folder_leaf.gif"
                    ChildNode.SelectedImageKey = "tree_bigicon_end.gif"
                End If
                ChildNode.Expand()
                tNode.Nodes.Add(ChildNode)
                TreeSonNodeBindnew2(ChildNode, accountdata, drItem("faccountid").ToString)
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub grdItemsBind(ByVal SelNode As String, ByVal SelNodetag As String)
        Try
            If m_dsItemsInfo.Tables.Count > 0 Then
                m_dsItemsInfo.Tables(0).Clear()
            End If
            If SelNode = "" Then
                Sglstr = ""
                Sglstr += " select top 100 identity(int,1,1) as 序号,a.FAccountID,a.FNumber as 科目代码,a.FName as 科目名称,a.FHelperCode as 助记码,case when "
                Sglstr += " a.FDC=1 then '借' else '贷' end as [余额方向],case when b.FName = '*' then '所有币别' else b.FName end as 币别核算,"
                Sglstr += " convert(nvarchar(800), '') as 核算项目 into #acc from t_Account a"
                Sglstr += " inner join t_Currency b on a.FCurrencyID = b.FCurrencyID  order by a.FNumber  select * from #acc order by 科目代码  drop table #acc"
            Else
                If SelNodetag = "1" Then
                    Sglstr = ""
                    Sglstr += " select identity(int,1,1) as 序号, a.FAccountID,a.FNumber as 科目代码,a.FName as 科目名称,a.FHelperCode as 助记码,case when "
                    Sglstr += " a.FDC=1 then '借' else '贷' end as [余额方向],case when b.FName = '*' then '所有币别' else b.FName end as 币别核算,"
                    Sglstr += " convert(nvarchar(800), '') as 核算项目 into #acc  from t_Account a"
                    Sglstr += " inner join t_Currency b on a.FCurrencyID = b.FCurrencyID where   a.FGroupID in (select FGroupID from t_AcctGroup where fclassid= '" & SelNode & "' )  order by a.FNumber  select * from #acc order by 科目代码  drop table #acc"

                ElseIf SelNodetag = "2" Then
                    Sglstr = ""
                    Sglstr += " select identity(int,1,1) as 序号, a.FAccountID,a.FNumber as 科目代码,a.FName as 科目名称,a.FHelperCode as 助记码,case when "
                    Sglstr += " a.FDC=1 then '借' else '贷' end as [余额方向],case when b.FName = '*' then '所有币别' else b.FName end as 币别核算,"
                    Sglstr += " convert(nvarchar(800), '') as 核算项目 into #acc  from t_Account a"
                    Sglstr += " inner join t_Currency b on a.FCurrencyID = b.FCurrencyID where a.FGroupID= '" & SelNode & "'  order by a.FNumber  select * from #acc order by 科目代码  drop table #acc"

                Else
                    Sglstr = ""
                    Sglstr += " select identity(int,1,1) as 序号, a.FAccountID,a.FNumber as 科目代码,a.FName as 科目名称,a.FHelperCode as 助记码,case when "
                    Sglstr += " a.FDC=1 then '借' else '贷' end as [余额方向],case when b.FName = '*' then '所有币别' else b.FName end as 币别核算,"
                    Sglstr += " convert(nvarchar(800), '') as 核算项目 into #acc  from t_Account a"
                    Sglstr += " inner join t_Currency b on a.FCurrencyID = b.FCurrencyID where a.FNumber like '" & SelNode & "%'  order by a.FNumber  select * from #acc order by 科目代码  drop table #acc"
                End If
            End If
            DBOpen = New BLuser
            m_dsItemsInfo = DBOpen.GetDataset(Sglstr, constr)

            If m_dsItemsInfo.Tables.Count > 0 Then
                Me.C1FlexGrid1.DataSource = m_dsItemsInfo.Tables(0)
                Me.C1FlexGrid1.Cols("faccountid").Width = -1
                Me.C1FlexGrid1.Cols(1).Width = 30
                Me.C1FlexGrid1.Cols(3).Width = 150
                Me.C1FlexGrid1.Cols(4).Width = 150
                Me.C1FlexGrid1.Cols(5).Width = 50
                Me.C1FlexGrid1.Cols(6).Width = 70
                Me.C1FlexGrid1.Cols(7).Width = 70

                'If SelNode = "" Then
                '    txtTypeName.Text = m_dsItemsInfo.Tables(1).Rows(0)(0)
                'End If
                txtTypeName.Enabled = False
                Me.C1FlexGrid1.Cols(1).Style.BackColor = Color.FromArgb(108, 155, 200)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub trvItems_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvItems.AfterSelect
        Me.Cursor = Cursors.WaitCursor
        Try
            If Not (Me.trvItems.SelectedNode Is Nothing) Then
                If Me.trvItems.SelectedNode.Tag.ToString() <> "" And Me.trvItems.SelectedNode.Name <> "" Then

                    grdItemsBind(Me.trvItems.SelectedNode.Name, Me.trvItems.SelectedNode.Tag)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Me.Cursor = Cursors.Default
    End Sub


    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Me.Cursor = Cursors.WaitCursor
        Dim sglmyh As String
        Try
            If m_dsItemsInfo.Tables.Count > 0 Then
                m_dsItemsInfo.Tables(0).Clear()
            End If
            If txtSearchText.Text <> "" Then
                Select Case cobSearchType.SelectedIndex
                    Case 0
                        Sglstr = ""
                        Sglstr += " select identity(int,1,1) as 序号, a.FAccountID,a.FNumber as 科目代码,a.FName as 科目名称,a.FHelperCode as 助记码,case when "
                        Sglstr += " a.FDC=1 then '借' else '贷' end as [余额方向],case when b.FName = '*' then '所有币别' else b.FName end as 币别核算,"
                        Sglstr += " convert(nvarchar(800), '') as 核算项目 into #acc  from t_Account a"
                        Sglstr += " inner join t_Currency b on a.FCurrencyID = b.FCurrencyID where a.fdetail = 1 and a.FNumber like '%" & txtSearchText.Text & "%'  order by a.FNumber  select * from #acc order by 科目代码  drop table #acc"

                    Case 1
                        Sglstr = ""
                        Sglstr += " select identity(int,1,1) as 序号, a.FAccountID,a.FNumber as 科目代码,a.FName as 科目名称,a.FHelperCode as 助记码,case when "
                        Sglstr += " a.FDC=1 then '借' else '贷' end as [余额方向],case when b.FName = '*' then '所有币别' else b.FName end as 币别核算,"
                        Sglstr += " convert(nvarchar(800), '') as 核算项目 into #acc  from t_Account a"
                        Sglstr += " inner join t_Currency b on a.FCurrencyID = b.FCurrencyID where a.fdetail = 1 and a.fname like '%" & txtSearchText.Text & "%'  order by a.FNumber  select * from #acc order by 科目代码  drop table #acc"

                End Select
                
                DBOpen = New BLuser
                m_dsItemsInfo = DBOpen.GetDataset(Sglstr, constr)

                If m_dsItemsInfo.Tables.Count > 0 Then
                    Me.C1FlexGrid1.DataSource = m_dsItemsInfo.Tables(0)
                    Me.C1FlexGrid1.Cols("faccountid").Width = -1
                    Me.C1FlexGrid1.Cols(1).Width = 30
                    Me.C1FlexGrid1.Cols(3).Width = 150
                    Me.C1FlexGrid1.Cols(4).Width = 150
                    Me.C1FlexGrid1.Cols(5).Width = 50
                    Me.C1FlexGrid1.Cols(6).Width = 70
                    Me.C1FlexGrid1.Cols(7).Width = 70


                    txtTypeName.Enabled = False
                    Me.C1FlexGrid1.Cols(1).Style.BackColor = Color.FromArgb(108, 155, 200)
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub C1FlexGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1FlexGrid1.DoubleClick

        Me.Cursor = Cursors.WaitCursor
        Dim intRow As Integer
        Dim dt As New DataTable
        Dim item As Integer
        Try

            intRow = Me.C1FlexGrid1.Row
            If intRow > 0 Then
                item = C1FlexGrid1.Item(intRow, "faccountid")
                Sglstr = "select faccountid as fitemid,* from  t_Account where faccountid ='" & item.ToString & "'"
                DBOpen = New BLuser
                RtnDataTable = DBOpen.GetDataset(Sglstr, constr)
                If Me.RtnDataTable.Tables(0).Rows.Count > 0 Then
                    m_dsItemsInfo.Tables(0).Clear()
                    m_dsItemsInfo2.Tables(0).Clear()
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Cursor = Cursors.Default
                    Me.Close()
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub C1FlexGrid1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles C1FlexGrid1.KeyDown
       
        Me.Cursor = Cursors.WaitCursor
        Dim intRow As Integer
        Dim dt As New DataTable
        Dim item As Integer
        Try
            If e.KeyCode <> Keys.Enter Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            intRow = Me.C1FlexGrid1.Row
            If intRow > 0 Then
                item = C1FlexGrid1.Item(intRow, "faccountid")
                Sglstr = "select faccountid as fitemid,* from  t_Account where faccountid ='" & item.ToString & "'"
                DBOpen = New BLuser
                RtnDataTable = DBOpen.GetDataset(Sglstr, constr)
                If Me.RtnDataTable.Tables(0).Rows.Count > 0 Then
                    m_dsItemsInfo.Tables(0).Clear()
                    m_dsItemsInfo2.Tables(0).Clear()
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Cursor = Cursors.Default
                    Me.Close()
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Me.Cursor = Cursors.Default
    End Sub
End Class