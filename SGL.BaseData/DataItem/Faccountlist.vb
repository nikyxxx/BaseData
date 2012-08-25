Imports PublicSharedResource
Imports SGL.BLL
Public Class Faccountlist
    Inherits frmBase
    Public ds, ds2, ds3, dsd, ds4 As New System.Data.DataSet
    Public sql, sqltemp, mefitemclassid, mefparentid, meflevel, mefrank As String
    Public finterid, i As Integer
    Private DBOpen As SGL.BLL.BLuser
    Public constr As String

#Region "成员变量声明"

    Private m_dsAccountInfo As New DataSet

#End Region

#Region "成员方法声明"

    Private Function IfSelectOneRecord() As Boolean
        Try
            Dim intRow As Integer
            Dim blnReturnValue As Boolean
            intRow = Me.C1FlexGrid.Row
            If intRow >= 0 Then
                If Me.C1FlexGrid.Rows(intRow)("编码") Is Nothing Then
                    MsgBox("请选择一条记录！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
                    blnReturnValue = False
                Else
                    blnReturnValue = True
                End If
            Else
                MsgBox("请选择一条记录！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
                blnReturnValue = False
            End If
            Return blnReturnValue
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 加载科目的类别节点
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AccountTreeBind()
        Dim topNode As New TreeNode
        Dim dsAcctGroups1 As DataSet
        Dim sql As String
        Dim strsql As String

        sql = "select * from t_acctGroup where FGroupID <> 0"
        DBOpen = New BLuser
        dsAcctGroups1 = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)

        strsql = "select FAccountID,FNumber,FName,FLevel,FDetail,FParentID,FGroupID,Left(FNumber,1) FClassID from t_account"
        ds4.Clear()
        DBOpen = New BLuser
        ds4 = DBOpen.GetDataset(strsql, Me.CYSysInfo.ConnStrValue)


        Try
            '取得科目的类别
            'Dim _WSAccounts As New refAccounts.WSAccounts
            '_WSAccounts.Url = PublicSharedFunctions.GetWebServiceUrl(My.Settings.DNA_BaseData_refAccounts_WSAccounts)
            Dim dsAcctGroups As DataSet
            Dim drAcctGroup As DataRow

            strsql = "select FclassID,FgroupID,FName from t_acctGroup where FgroupID=0"
            DBOpen = New BLuser
            dsAcctGroups = DBOpen.GetDataset(strsql, Me.CYSysInfo.ConnStrValue)
            '取得所有的科目信息
            Dim dsAccountInfo As DataSet
            'dsAccountInfo = PublicSharedResource.PublicSharedFunctions.BinaryDeserialize(_WSAccounts.GetAllAccountInfo(Me.CYUserInfo.UserID, Me.CYSysInfo.ConnStrValue, 0))
            strsql = "select FAccountID,FNumber,FName,FLevel,FDetail,FParentID,Left(FNumber,1) FClassID from t_account "
            DBOpen = New BLuser
            dsAccountInfo = DBOpen.GetDataset(strsql, Me.CYSysInfo.ConnStrValue)
            Me.TreeView1.Nodes.Clear()

            '添加根节点
            topNode.Text = "科目表"
            topNode.Name = "-1000"
            topNode.Tag = ""
            topNode.ImageIndex = 4
            topNode.SelectedImageIndex = 6
            topNode.Expand()
            Me.TreeView1.Nodes.Add(topNode)
            '添加科目第二子接点
            If dsAcctGroups.Tables.Count > 0 Then
                For Each drAcctGroup In dsAcctGroups.Tables(0).Rows
                    Dim SecondChild As New TreeNode
                    SecondChild.Text = drAcctGroup("FName")
                    SecondChild.Name = drAcctGroup("FGroupID")
                    SecondChild.Tag = drAcctGroup("FClassID").ToString()
                    SecondChild.ImageIndex = 4
                    SecondChild.SelectedImageIndex = 6
                    SecondChild.Expand()
                    topNode.Nodes.Add(SecondChild)
                    TreeOneBind(SecondChild, dsAcctGroups1)
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' 加载科目的类别子节点
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TreeOneBind(ByVal NodeClassType As TreeNode, ByVal dsAccounts As DataSet)
        Try
            For Each drAccountOne As DataRow In dsAccounts.Tables(0).Select(" FClassID = " & NodeClassType.Tag)
                Dim tNode = New TreeNode
                tNode.Text = drAccountOne("FName")
                tNode.Name = drAccountOne("FGroupID")
                tNode.Tag = drAccountOne("FClassID")
                tNode.ImageKey = "tree_folder_close.gif"
                tNode.SelectedImageKey = "tree_folder_open.gif"
                tNode.Expand()
                NodeClassType.Nodes.Add(tNode)
                TreeLevelOneBind(tNode, ds4)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 加载科目的根节点
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TreeLevelOneBind(ByVal NodeClassType As TreeNode, ByVal dsAccounts As DataSet)
        Dim tNode As TreeNode
        Try

            For Each drAccountOne As DataRow In dsAccounts.Tables(0).Select("FLevel = 1 and FDetail=0 and FClassID = " & NodeClassType.Tag & "and FGroupID=" & NodeClassType.Name)
                tNode = New TreeNode
                tNode.Text = drAccountOne("FName")
                tNode.Name = drAccountOne("FNumber")
                tNode.Tag = drAccountOne("FAccountID").ToString() & "%" & drAccountOne("FLevel").ToString() & "%" & drAccountOne("FDetail").ToString() & "%" & drAccountOne("FParentID").ToString() & "%" & drAccountOne("FClassID").ToString()

                tNode.ImageKey = "tree_folder_close.gif"
                tNode.SelectedImageKey = "tree_folder_open.gif"

                tNode.Expand()
                NodeClassType.Nodes.Add(tNode)
                TreeSonNodeBind(tNode, dsAccounts)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' 科目子节点的绑定
    ''' </summary>
    ''' <param name="tNode"></param>
    ''' <param name="dsAccounts"></param>
    ''' <remarks></remarks>
    Private Sub TreeSonNodeBind(ByVal tNode As TreeNode, ByVal dsAccounts As DataSet)
        Dim ChildNode As TreeNode
        Dim strAccountID As String
        Try
            strAccountID = PublicSharedResource.PublicSharedFunctions.GetSubString(tNode.Tag.ToString(), 1)
            For Each drAccountOne As DataRow In dsAccounts.Tables(0).Select(" FDetail=0 and FParentID = " & strAccountID)
                ChildNode = New TreeNode
                ChildNode.Text = drAccountOne("FName")
                ChildNode.Name = drAccountOne("FNumber")
                ChildNode.Tag = drAccountOne("FAccountID").ToString() & "%" & drAccountOne("FLevel").ToString() & "%" & drAccountOne("FDetail").ToString() & "%" & drAccountOne("FParentID").ToString() & "%" & drAccountOne("FClassID").ToString()

                ChildNode.ImageKey = "tree_folder_close.gif"
                ChildNode.SelectedImageKey = "tree_folder_open.gif"

                tNode.Nodes.Add(ChildNode)
                TreeSonNodeBind(ChildNode, dsAccounts)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BindOneItemInfo()
        'ToolStripButton1.Enabled = True
        'sql = "SELECT a.FParentID,a.fname,a.fitemid,a.FLevel,a.fnumber,b.fmodel,'' as fcheckername,'' as FExplanation  FROM  t_item a left join t_icitem b on a.fitemid=b.fitemid where a.fdeleted=0 and fdetail=0 and a.fitemclassid=" + FItemClassID.SelectedValue.ToString + " order by a.fnumber"
        'ds.Clear()
        'ds = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
        'If ds.Tables(0).Rows.Count = 0 Then
        'sql = "SELECT a.FParentID,a.fnumber  as 编码,a.fname as 名称,a.fitemid,a.FLevel,b.fmodel as 规格型号,'' as 审核人,'' as 附件,a.fdetail  FROM  t_item a left join t_icitem b on a.fitemid=b.fitemid where a.fdeleted=0 and a.fitemclassid=" + FItemClassID.SelectedValue.ToString + " order by a.fnumber"
        ' ds2.Clear()
        ' ds2 = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
        'C1FlexGrid.DataSource = ds2.Tables(0)
        'C1FlexGrid.Cols("fparentid").Width = -1
        'C1FlexGrid.Cols("fdetail").Width = -1
        'C1FlexGrid.Cols("fitemid").Width = -1
        'C1FlexGrid.Cols("FLevel").Width = -1
        'C1FlexGrid.Cols("名称").Width = 100
        'C1FlexGrid.Cols("编码").Width = 150
        'C1FlexGrid.Cols("规格型号").Width = 100
        'C1FlexGrid.Cols("审核人").Width = 100
        'C1FlexGrid.Cols("附件").Width = 200

        'End If
        'mefitemclassid = FItemClassID.SelectedValue
        AccountTreeBind()
    End Sub
    ''' <summary>
    ''' 判断是否有子科目
    ''' </summary>
    ''' <remarks></remarks>
    Private Function HaveSunNode(ByVal FAccountID As Integer) As Boolean
        Try
            Dim ds As DataSet
            sql = "select FAccountID from t_Account where FParentID =" & FAccountID.ToString()
            DBOpen = New BLuser
            ds = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
            If ds.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 判断科目是否被使用
    ''' </summary>
    ''' <remarks></remarks>
    Private Function HaveUsed(ByVal FAccountID As Integer) As Boolean
        Try
            Dim ds As DataSet
            Dim bln As Boolean = False
            sql = ""
            sql = " DECLARE	@return_value int "
            sql += "EXEC	@return_value = [dbo].[sp_ObjectInUsed]"
            sql += " @ObjectType = 0, @ObjectID = " & FAccountID.ToString
            sql += " SELECT	'Return Value' = @return_value "
            DBOpen = New BLuser
            ds = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
            If ds.Tables(0).Rows(0)(0) = 1 Then
                bln = True
            Else
                bln = False
            End If

            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 删除Account
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteAccount(ByVal FAccountID As Integer)
        Try
            sql = ""
            sql = "Select FParentID, FNumber,FControl,FName from t_Account where FAccountID=" & FAccountID.ToString
            ds.Clear()
            DBOpen = New BLuser
            ds = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)

            sql = ""
            sql = " delete from t_Account where FAccountID=" + FAccountID.ToString
            DBOpen = New BLuser
            DBOpen.sqlexecnon(sql, Me.CYSysInfo.ConnStrValue)

            sql = ""
            sql = "select FAccountID from t_Account where FParentID='" & ds.Tables(0).Rows(0)("FParentID").ToString & "'"
            ds2.Clear()
            DBOpen = New BLuser
            ds2 = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)

            If ds2.Tables(0).Rows.Count = 0 Then
                sql = ""
                sql = "update t_Account set FDetail=1 where FAccountID=" & ds.Tables(0).Rows(0)("FParentID").ToString
                DBOpen = New BLuser
                DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
            End If

            MsgBox("删除成功！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            'Me.C1FlexGrid.Rows.Remove(C1FlexGrid.Row)
            finterid = 0
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
#End Region

    Private Sub Out_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Out.Click
        Me.Close()
    End Sub


    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Me.Cursor = Cursors.WaitCursor
        Try
            If IsNothing(TreeView1.SelectedNode) Then
                sql = "select a.faccountid as 编码,a.fnumber as 科目编码 ,a.fname as 科目名称,a.flevel as 科目级次 ,a.fhelpercode as 助记码,t.FName as 科目类别,case when FDC=1 then '借' else '贷' end as '余额方向',case a.FcurrencyID when 0 then '所有币别' when 1 then '不核算' else b.Fname end [外币核算],case a.FQuantities when 1 then '是' else '否' end [数量核算],a.fdetail,a.frootid,a.fgroupid ,FdetailID,convert(varchar(255),'') [核算项目] into #aa from t_account a  , t_acctGroup t,t_currency b where ( FDelete=0 Or  FIsAcnt=1) and a.FGroupID=t.FGroupID and a.FcurrencyID=b.FcurrencyID order by a.fgroupid,a.fnumber" '最高等级的树
                sql = sql & " declare @name varchar(100)  declare my_cursor cursor for select distinct FdetailID from #aa where FdetailID>0"
                sql = sql & " open my_cursor declare @detailID int fetch next from my_cursor into @detailID while(@@fetch_status=0)"
                sql = sql & " begin 	set @name='' 	select @name=@name + Fname+ '/' from t_itemdetailv v1 inner join "
                sql = sql & " t_itemclass t1 on v1.FitemclassID=t1.FitemclassID where FdetailID=@detailID update #aa set 核算项目="
                sql = sql & " substring(@name,1,len(@name)-1) where FdetailID=@detailID 	fetch next from my_cursor into @detailID"
                sql = sql & " end close my_cursor deallocate my_cursor select * from #aa order by 科目编码 drop table #aa"
            ElseIf Integer.Parse(TreeView1.SelectedNode.Level.ToString) = 1 Then
                sql = "select a.faccountid as 编码,a.fnumber as 科目编码 ,a.fname as 科目名称,a.flevel as 科目级次 ,a.fhelpercode as 助记码,t.FName as 科目类别,case when FDC=1 then '借' else '贷' end as '余额方向',case a.FcurrencyID when 0 then '所有币别' when 1 then '不核算' else b.Fname end [外币核算],case a.FQuantities when 1 then '是' else '否' end [数量核算],a.fdetail,a.frootid,a.fgroupid ,FdetailID,convert(varchar(255),'') [核算项目] into #aa from t_acctgroup t , t_account a,t_currency b where ( FDelete=0 Or  FIsAcnt=1) and t.fgroupid=a.fgroupid and a.FcurrencyID=b.FcurrencyID and FClassID =" & Me.TreeView1.SelectedNode.Tag & " " '第二级别的树
                sql = sql & " declare @name varchar(100)  declare my_cursor cursor for select distinct FdetailID from #aa where FdetailID>0"
                sql = sql & " open my_cursor declare @detailID int fetch next from my_cursor into @detailID while(@@fetch_status=0)"
                sql = sql & " begin 	set @name='' 	select @name=@name + Fname+ '/' from t_itemdetailv v1 inner join "
                sql = sql & " t_itemclass t1 on v1.FitemclassID=t1.FitemclassID where FdetailID=@detailID update #aa set 核算项目="
                sql = sql & " substring(@name,1,len(@name)-1) where FdetailID=@detailID 	fetch next from my_cursor into @detailID"
                sql = sql & " end close my_cursor deallocate my_cursor select * from #aa order by 科目编码 drop table #aa"
            ElseIf Integer.Parse(TreeView1.SelectedNode.Level.ToString) = 2 Then
                sql = "select a.faccountid as 编码,a.fnumber as 科目编码 ,a.fname as 科目名称,a.flevel as 科目级次 ,a.fhelpercode as 助记码,t.FName as 科目类别,case when FDC=1 then '借' else '贷' end as '余额方向',case a.FcurrencyID when 0 then '所有币别' when 1 then '不核算' else b.Fname end [外币核算],case a.FQuantities when 1 then '是' else '否' end [数量核算],a.fdetail,a.frootid,a.fgroupid ,FdetailID,convert(varchar(255),'') [核算项目] into #aa from t_account a  , t_acctGroup t,t_currency b where ( FDelete=0 Or  FIsAcnt=1) and a.FGroupID=t.FGroupID and a.FcurrencyID=b.FcurrencyID and a.fgroupid =" & Me.TreeView1.SelectedNode.Name & " " '第三级别的树
                sql = sql & " declare @name varchar(100)  declare my_cursor cursor for select distinct FdetailID from #aa where FdetailID>0"
                sql = sql & " open my_cursor declare @detailID int fetch next from my_cursor into @detailID while(@@fetch_status=0)"
                sql = sql & " begin 	set @name='' 	select @name=@name + Fname+ '/' from t_itemdetailv v1 inner join "
                sql = sql & " t_itemclass t1 on v1.FitemclassID=t1.FitemclassID where FdetailID=@detailID update #aa set 核算项目="
                sql = sql & " substring(@name,1,len(@name)-1) where FdetailID=@detailID 	fetch next from my_cursor into @detailID"
                sql = sql & " end close my_cursor deallocate my_cursor select * from #aa order by 科目编码 drop table #aa"
            ElseIf Integer.Parse(TreeView1.SelectedNode.Level.ToString) = 0 Then
                sql = "select a.faccountid as 编码,a.fnumber as 科目编码 ,a.fname as 科目名称,a.flevel as 科目级次 ,a.fhelpercode as 助记码,t.FName as 科目类别,case when FDC=1 then '借' else '贷' end as '余额方向',case a.FcurrencyID when 0 then '所有币别' when 1 then '不核算' else b.Fname end [外币核算],case a.FQuantities when 1 then '是' else '否' end [数量核算],a.fdetail,a.frootid,a.fgroupid ,FdetailID,convert(varchar(255),'') [核算项目] into #aa from t_account a  , t_acctGroup t,t_currency b where ( FDelete=0 Or  FIsAcnt=1) and a.FGroupID=t.FGroupID and a.FcurrencyID=b.FcurrencyID order by a.fgroupid,a.fnumber" '最高等级的树
                sql = sql & " declare @name varchar(100)  declare my_cursor cursor for select distinct FdetailID from #aa where FdetailID>0"
                sql = sql & " open my_cursor declare @detailID int fetch next from my_cursor into @detailID while(@@fetch_status=0)"
                sql = sql & " begin 	set @name='' 	select @name=@name + Fname+ '/' from t_itemdetailv v1 inner join "
                sql = sql & " t_itemclass t1 on v1.FitemclassID=t1.FitemclassID where FdetailID=@detailID update #aa set 核算项目="
                sql = sql & " substring(@name,1,len(@name)-1) where FdetailID=@detailID 	fetch next from my_cursor into @detailID"
                sql = sql & " end close my_cursor deallocate my_cursor select * from #aa order by 科目编码 drop table #aa"
            Else
                sql = "select a.faccountid as 编码,a.fnumber as 科目编码 ,a.fname as 科目名称,a.flevel as 科目级次 ,a.fhelpercode as 助记码,t.FName as 科目类别,case when FDC=1 then '借' else '贷' end as '余额方向',case a.FcurrencyID when 0 then '所有币别' when 1 then '不核算' else b.Fname end [外币核算],case a.FQuantities when 1 then '是' else '否' end [数量核算],a.fdetail,a.frootid,a.fgroupid  ,FdetailID,convert(varchar(255),'') [核算项目] into #aa from t_account a ,t_acctGroup t,t_currency b where ( FDelete=0 Or  FIsAcnt=1)  and a.FGroupID=t.FGroupID and a.FcurrencyID=b.FcurrencyID and a.FNumber like '" & Me.TreeView1.SelectedNode.Name & "%'  " '接下来的级别
                sql = sql & " declare @name varchar(100)  declare my_cursor cursor for select distinct FdetailID from #aa where FdetailID>0"
                sql = sql & " open my_cursor declare @detailID int fetch next from my_cursor into @detailID while(@@fetch_status=0)"
                sql = sql & " begin 	set @name='' 	select @name=@name + Fname+ '/' from t_itemdetailv v1 inner join "
                sql = sql & " t_itemclass t1 on v1.FitemclassID=t1.FitemclassID where FdetailID=@detailID update #aa set 核算项目="
                sql = sql & " substring(@name,1,len(@name)-1) where FdetailID=@detailID 	fetch next from my_cursor into @detailID"
                sql = sql & " end close my_cursor deallocate my_cursor select * from #aa order by 科目编码 drop table #aa"
            End If

            ds2.Clear()
            DBOpen = New BLuser
            ds2 = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
            C1FlexGrid.DataSource = ds2.Tables(0)
            C1FlexGrid.Cols("编码").Width = -1
            C1FlexGrid.Cols("科目编码").Width = 120
            C1FlexGrid.Cols("科目名称").Width = 150
            C1FlexGrid.Cols("科目级次").Width = 100
            C1FlexGrid.Cols("助记码").Width = 100
            C1FlexGrid.Cols("科目类别").Width = 100
            C1FlexGrid.Cols("余额方向").Width = 100
            C1FlexGrid.Cols("fdetail").Width = -1
            C1FlexGrid.Cols("frootid").Width = -1
            C1FlexGrid.Cols("fgroupid").Width = -1
            C1FlexGrid.Cols("FDetailID").Width = -1
            C1FlexGrid.Cols("核算项目").Width = 120
            '绑定序号一级右上角的信息
            For i = 0 To ds2.Tables(0).Rows.Count - 1
                Me.C1FlexGrid.Rows(i + 1)("序号") = (i + 1).ToString
            Next
            If IsNothing(TreeView1.SelectedNode) Then
                Me.Label2.Text = "[所有科目] 的内容------共计：" & ds2.Tables(0).Rows.Count & "记录"
            Else
                Me.Label2.Text = "[" & TreeView1.SelectedNode.Text & "] 的内容------共计：" & ds2.Tables(0).Rows.Count & "记录"
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub C1FlexGrid_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1FlexGrid.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If IfSelectOneRecord() = True Then
                Dim _frmaccount As New FrmAccT
                _frmaccount.CYUserInfo = Me.CYUserInfo
                _frmaccount.CYSysInfo = Me.CYSysInfo
                _frmaccount.faccountid = Me.C1FlexGrid.Rows(Me.C1FlexGrid.Row)("编码")
                _frmaccount.FLnumber = Me.C1FlexGrid.Rows(Me.C1FlexGrid.Row)("科目编码")
                _frmaccount.FLname = Me.C1FlexGrid.Rows(Me.C1FlexGrid.Row)("科目名称")
                If IsNothing(TreeView1.SelectedNode) = False Then
                    _frmaccount.frank = Me.TreeView1.SelectedNode.Level
                Else
                    _frmaccount.frank = 1
                End If

                _frmaccount.gridindex = C1FlexGrid.Row
                _frmaccount.frm = Me
                _frmaccount.StartPosition = FormStartPosition.CenterScreen
                _frmaccount.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub C1FlexGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1FlexGrid.Click
        If C1FlexGrid.Rows.Count > 1 Then
            finterid = C1FlexGrid(C1FlexGrid.Row, "编码")
        End If

    End Sub
    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        Me.Cursor = Cursors.WaitCursor
        If Me.TreeView1.SelectedNode.Level = 2 And Me.TreeView1.Focused = True Then
            sql = ""
            sql = "Select FNumber From t_Account WHere FGroupID=" & Me.TreeView1.SelectedNode.Name
            ds.Clear()
            DBOpen = New BLuser
            ds = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
            If ds.Tables(0).Rows.Count = 0 Then
                sql = ""
                sql = "Delete From t_AcctGroup Where FGroupID=" & Me.TreeView1.SelectedNode.Name
                DBOpen = New BLuser
                DBOpen.sqlexecnon(sql, Me.CYSysInfo.ConnStrValue)
                MsgBox("删除成功！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)

                refresh_Click(Nothing, Nothing)
            Else
                MsgBox("该科目下面已经有业务发生，不能被删除！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            End If
        Else
            Try
                Dim Result As DialogResult

                '权限
                If Me.IfSelectOneRecord = True Then
                    Result = MsgBox("是否确认删除", MsgBoxStyle.OkCancel, "提示")
                    If Result = DialogResult.OK Then
                        '权限判断处理         
                        If 1 = 1 Then
                            If Me.HaveSunNode(finterid) = False Then
                                If Me.HaveUsed(finterid) = False Then
                                    DeleteAccount(finterid)
                                    refesh()
                                Else
                                    MsgBox("该科目已经有业务发生，不能被删除！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
                                End If
                            Else
                                MsgBox("该科目下面有明细科目，不能被删除！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
                            End If

                        Else
                            MsgBox("没有删除权限，不能被删除！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)

                        End If
                    End If
                End If

            Catch ex As Exception
                Throw ex
            End Try

        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Faccountlist_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        FItemClassID.Enabled = False
        AccountTreeBind()
        sql = "select a.faccountid as 编码,a.fnumber as 科目编码 ,a.fname as 科目名称,a.flevel as 科目级次 ,a.fhelpercode as 助记码,t.FName as 科目类别,case when FDC=1 then '借' else '贷' end as '余额方向',case a.FcurrencyID when 0 then '所有币别' when 1 then '不核算' else b.Fname end [外币核算],case a.FQuantities when 1 then '是' else '否' end [数量核算],a.fdetail,a.frootid,a.fgroupid  ,FdetailID,convert(varchar(255),'') [核算项目] into #aa from t_account a ,t_acctGroup t,t_currency b where ( FDelete=0 Or  FIsAcnt=1)  and a.FGroupID=t.FGroupID and a.FcurrencyID=b.FcurrencyID  " '接下来的级别
        sql = sql & " declare @name varchar(100)  declare my_cursor cursor for select distinct FdetailID from #aa where FdetailID>0"
        sql = sql & " open my_cursor declare @detailID int fetch next from my_cursor into @detailID while(@@fetch_status=0)"
        sql = sql & " begin 	set @name='' 	select @name=@name + Fname+ '/' from t_itemdetailv v1 inner join "
        sql = sql & " t_itemclass t1 on v1.FitemclassID=t1.FitemclassID where FdetailID=@detailID update #aa set 核算项目="
        sql = sql & " substring(@name,1,len(@name)-1) where FdetailID=@detailID 	fetch next from my_cursor into @detailID"
        sql = sql & " end close my_cursor deallocate my_cursor select * from #aa order by 科目编码 drop table #aa"

        DBOpen = New BLuser
        ds2 = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
        C1FlexGrid.DataSource = ds2.Tables(0)
        C1FlexGrid.Cols("编码").Width = -1
        C1FlexGrid.Cols("科目编码").Width = 120
        C1FlexGrid.Cols("科目名称").Width = 150
        C1FlexGrid.Cols("科目级次").Width = 100
        C1FlexGrid.Cols("助记码").Width = 100
        C1FlexGrid.Cols("科目类别").Width = 100
        C1FlexGrid.Cols("余额方向").Width = 100
        C1FlexGrid.Cols("fdetail").Width = -1
        C1FlexGrid.Cols("frootid").Width = -1
        C1FlexGrid.Cols("fgroupid").Width = -1
        C1FlexGrid.Cols("FDetailID").Width = -1
        C1FlexGrid.Cols("核算项目").Width = 120
        '绑定序号一级右上角的信息
        For i = 0 To ds2.Tables(0).Rows.Count - 1
            Me.C1FlexGrid.Rows(i + 1)("序号") = (i + 1).ToString
        Next
        Me.Label2.Text = "[科目表] 的内容------共计：" & ds2.Tables(0).Rows.Count & "记录"
    End Sub

    Private Sub FItemClassID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FItemClassID.SelectedValueChanged

    End Sub

    Private Sub SendDownww_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendDownww.Click
        Me.Cursor = Cursors.WaitCursor
        Dim Result As DialogResult
        Try

            If Me.IfSelectOneRecord = True Then
                Result = MsgBox("是否确认禁用", MsgBoxStyle.OkCancel, "提示")
                If Result = Windows.Forms.DialogResult.OK Then
                    '权限判断
                    'If _WSFuncRight.IsHaveFuncRight(Me.CYUserInfo.FID, Me.CYUserInfo.FUGroupID, Me.CYSysInfo.DBID, "BD0101005", FuncType.禁用) = True Then
                    If Me.HaveSunNode(finterid) = False Then
                        sql = "Update t_Account Set  FDelete=1 Where FAccountID=" + finterid.ToString
                        DBOpen = New BLuser
                        DBOpen.sqlexecnon(sql, Me.CYSysInfo.ConnStrValue)
                        MsgBox("成功禁用！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
                        refesh()
                    Else
                        MsgBox("该科目下面有明细科目，不能被禁用！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
                    End If
                    'Else
                    '    MsgBox("没有禁用权限，不能被删除！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
                    'End If
                End If

            End If
        Catch ex As Exception
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Recall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Recall.Click

        '权限判断
        '    If _WSFuncRight.IsHaveFuncRight(Me.CYUserInfo.FID, Me.CYUserInfo.FUGroupID, Me.CYSysInfo.DBID, "BD0101005", FuncType.核销) = True Then
        Dim _fbasetemp As New fbasetemp
        _fbasetemp.frmactlist = Me
        _fbasetemp.tablename = "管理科目禁用"
        _fbasetemp.StartPosition = FormStartPosition.CenterScreen
        _fbasetemp.ShowDialog()
        'Else
        'MsgBox("没有反禁用权限，不能被删除！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
        'End If


    End Sub

    Private Sub refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles refresh.Click
        AccountTreeBind()


    End Sub
    Public Sub refesh()
        TreeView1_AfterSelect(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        '_WSFuncRight.Url = PublicSharedFunctions.GetWebServiceUrl(My.Settings.DNA_BaseData_refRightFunc_WSRightFunc)

        If Me.TreeView1.SelectedNode Is Nothing Then
            '权限
            'If _WSFuncRight.IsHaveFuncRight(Me.CYUserInfo.FID, Me.CYUserInfo.FUGroupID, Me.CYSysInfo.DBID, "BD0101005", FuncType.新增) = True Then '新增明细
            Dim _frmaccount As New FrmAccT
            _frmaccount.gridindex = Me.C1FlexGrid.Row
            _frmaccount.faccountid = 0
            _frmaccount.CYUserInfo = Me.CYUserInfo
            _frmaccount.CYSysInfo = Me.CYSysInfo
            _frmaccount.frm = Me
            _frmaccount.StartPosition = FormStartPosition.CenterScreen
            _frmaccount.ShowDialog()
            'End If
            sql = "select a.faccountid as 编码,a.fnumber as 科目编码 ,a.fname as 科目名称,a.flevel as 科目级次 ,a.fhelpercode as 助记码,t.FName as 科目类别,case when FDC=1 then '借' else '贷' end as '余额方向',case a.FcurrencyID when 0 then '所有币别' when 1 then '不核算' else b.Fname end [外币核算],case a.FQuantities when 1 then '是' else '否' end [数量核算],a.fdetail,a.frootid,a.fgroupid  ,FdetailID,convert(varchar(255),'') [核算项目] into #aa from t_account a ,t_acctGroup t,t_currency b where ( FDelete=0 Or  FIsAcnt=1)  and a.FGroupID=t.FGroupID  and a.FcurrencyID=b.FcurrencyID " '接下来的级别
            sql = sql & " declare @name varchar(100)  declare my_cursor cursor for select distinct FdetailID from #aa where FdetailID>0"
            sql = sql & " open my_cursor declare @detailID int fetch next from my_cursor into @detailID while(@@fetch_status=0)"
            sql = sql & " begin 	set @name='' 	select @name=@name + Fname+ '/' from t_itemdetailv v1 inner join "
            sql = sql & " t_itemclass t1 on v1.FitemclassID=t1.FitemclassID where FdetailID=@detailID update #aa set 核算项目="
            sql = sql & " substring(@name,1,len(@name)-1) where FdetailID=@detailID 	fetch next from my_cursor into @detailID"
            sql = sql & " end close my_cursor deallocate my_cursor select * from #aa order by 科目编码 drop table #aa"

            DBOpen = New BLuser
            ds2 = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
            C1FlexGrid.DataSource = ds2.Tables(0)
            C1FlexGrid.Cols("编码").Width = -1
            C1FlexGrid.Cols("科目编码").Width = 120
            C1FlexGrid.Cols("科目名称").Width = 150
            C1FlexGrid.Cols("科目级次").Width = 100
            C1FlexGrid.Cols("助记码").Width = 100
            C1FlexGrid.Cols("科目类别").Width = 100
            C1FlexGrid.Cols("余额方向").Width = 100
            C1FlexGrid.Cols("fdetail").Width = -1
            C1FlexGrid.Cols("frootid").Width = -1
            C1FlexGrid.Cols("fgroupid").Width = -1
            C1FlexGrid.Cols("FDetailID").Width = -1
            C1FlexGrid.Cols("核算项目").Width = 120
            '绑定序号一级右上角的信息
            For i = 0 To ds2.Tables(0).Rows.Count - 1
                Me.C1FlexGrid.Rows(i + 1)("序号") = (i + 1).ToString
            Next
            Me.Label2.Text = "[科目表] 的内容------共计：" & ds2.Tables(0).Rows.Count & "记录"
            Exit Sub
        End If
        If Me.TreeView1.Focused = True And (Me.TreeView1.SelectedNode.Level = 1 Or Me.TreeView1.SelectedNode.Level = 2) Then '判断组别或则新增明细
            'If _WSFuncRight.IsHaveFuncRight(Me.CYUserInfo.FID, Me.CYUserInfo.FUGroupID, Me.CYSysInfo.DBID, "BD0101005", FuncType.新增) = True Then '新增组别
            Dim _frmaddgroup As New frmAddAcountGroup
            _frmaddgroup.frm = Me
            _frmaddgroup.style = "科目组-新增"
            _frmaddgroup.CYUserInfo = Me.CYUserInfo
            _frmaddgroup.CYSysInfo = Me.CYSysInfo
            _frmaddgroup.StartPosition = FormStartPosition.CenterScreen
            _frmaddgroup.ShowDialog()
            'End If
        Else
            '权限
            'If _WSFuncRight.IsHaveFuncRight(Me.CYUserInfo.FID, Me.CYUserInfo.FUGroupID, Me.CYSysInfo.DBID, "BD0101005", FuncType.新增) = True Then '新增明细
            Dim _frmaccount As New FrmAccT
            _frmaccount.gridindex = Me.C1FlexGrid.Row
            _frmaccount.faccountid = 0
            _frmaccount.CYUserInfo = Me.CYUserInfo
            _frmaccount.CYSysInfo = Me.CYSysInfo
            _frmaccount.frm = Me
            _frmaccount.StartPosition = FormStartPosition.CenterScreen
            _frmaccount.ShowDialog()
            'End If
            sql = "select a.faccountid as 编码,a.fnumber as 科目编码 ,a.fname as 科目名称,a.flevel as 科目级次 ,a.fhelpercode as 助记码,t.FName as 科目类别,case when FDC=1 then '借' else '贷' end as '余额方向',case a.FcurrencyID when 0 then '所有币别' when 1 then '不核算' else b.Fname end [外币核算],case a.FQuantities when 1 then '是' else '否' end [数量核算],a.fdetail,a.frootid,a.fgroupid  ,FdetailID,convert(varchar(255),'') [核算项目] into #aa from t_account a ,t_acctGroup t,t_currency b where ( FDelete=0 Or  FIsAcnt=1)  and a.FGroupID=t.FGroupID and a.FcurrencyID=b.FcurrencyID  " '接下来的级别
            sql = sql & " declare @name varchar(100)  declare my_cursor cursor for select distinct FdetailID from #aa where FdetailID>0"
            sql = sql & " open my_cursor declare @detailID int fetch next from my_cursor into @detailID while(@@fetch_status=0)"
            sql = sql & " begin 	set @name='' 	select @name=@name + Fname+ '/' from t_itemdetailv v1 inner join "
            sql = sql & " t_itemclass t1 on v1.FitemclassID=t1.FitemclassID where FdetailID=@detailID update #aa set 核算项目="
            sql = sql & " substring(@name,1,len(@name)-1) where FdetailID=@detailID 	fetch next from my_cursor into @detailID"
            sql = sql & " end close my_cursor deallocate my_cursor select * from #aa order by 科目编码 drop table #aa"

            DBOpen = New BLuser
            ds2 = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
            C1FlexGrid.DataSource = ds2.Tables(0)
            C1FlexGrid.Cols("编码").Width = -1
            C1FlexGrid.Cols("科目编码").Width = 120
            C1FlexGrid.Cols("科目名称").Width = 150
            C1FlexGrid.Cols("科目级次").Width = 100
            C1FlexGrid.Cols("助记码").Width = 100
            C1FlexGrid.Cols("科目类别").Width = 100
            C1FlexGrid.Cols("余额方向").Width = 100
            C1FlexGrid.Cols("fdetail").Width = -1
            C1FlexGrid.Cols("frootid").Width = -1
            C1FlexGrid.Cols("fgroupid").Width = -1
            C1FlexGrid.Cols("FDetailID").Width = -1
            C1FlexGrid.Cols("核算项目").Width = 120
            '绑定序号一级右上角的信息
            For i = 0 To ds2.Tables(0).Rows.Count - 1
                Me.C1FlexGrid.Rows(i + 1)("序号") = (i + 1).ToString
            Next
            Me.Label2.Text = "[科目表] 的内容------共计：" & ds2.Tables(0).Rows.Count & "记录"
        End If
    End Sub

    Private Sub Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Update.Click

        If IsNothing(Me.TreeView1.SelectedNode) = True Then
            C1FlexGrid_DoubleClick(Nothing, Nothing)
            Exit Sub
        End If
        If Me.TreeView1.SelectedNode.Level = 2 And TreeView1.Focused = True Then
            Dim _frmaddgroup As New frmAddAcountGroup
            _frmaddgroup.frm = Me
            _frmaddgroup.style = "科目组-修改"
            _frmaddgroup.fgrouid = Me.TreeView1.SelectedNode.Name
            _frmaddgroup.CYUserInfo = Me.CYUserInfo
            _frmaddgroup.CYSysInfo = Me.CYSysInfo
            _frmaddgroup.StartPosition = FormStartPosition.CenterScreen
            _frmaddgroup.ShowDialog()
        Else
            C1FlexGrid_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        'If CheckBox1.Checked = True Then
        'Try
        'sql = ""
        'sql = "select a.faccountid as 编码,a.fnumber as 科目编码 ,a.fname as 科目名称,a.flevel as 科目级次 ,a.fhelpercode as 助记码,t.FName as 科目类别,case when FDC=1 then '借' else '贷' end as '余额方向',a.fdetail,a.frootid,a.fgroupid  from t_account a ,t_acctGroup t where ( FDelete=0 Or  FIsAcnt=1)  and a.FGroupID=t.FGroupID and FParentID=" & Me.TreeView1.SelectedNode.Name '接下来的级别
        '  ds2.Clear()
        'ds2 = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
        'C1FlexGrid.DataSource = ds2.Tables(0)
        'C1FlexGrid.Cols("编码").Width = -1
        ' C1FlexGrid.Cols("科目编码").Width = 120
        'C1FlexGrid.Cols("科目名称").Width = 150
        ' C1FlexGrid.Cols("科目级次").Width = 100
        ' C1FlexGrid.Cols("助记码").Width = 100
        'C1FlexGrid.Cols("科目类别").Width = 100
        'C1FlexGrid.Cols("余额方向").Width = 100
        'C1FlexGrid.Cols("fdetail").Width = -1
        'C1FlexGrid.Cols("frootid").Width = -1
        ' C1FlexGrid.Cols("fgroupid").Width = -1
        '绑定序号一级右上角的信息
        ' For i = 0 To ds2.Tables(0).Rows.Count - 1
        'Me.C1FlexGrid.Rows(i + 1)("序号") = (i + 1).ToString
        ' Next
        'Me.Label2.Text = "[" & TreeView1.SelectedNode.Text & "] 的内容------共计：" & ds2.Tables(0).Rows.Count & "记录"
        ' Catch ex As Exception
        '    Throw ex
        'End Try
        'Else
        ' refesh()
        'End If
    End Sub

    Private Sub ToolLeadInto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolLeadInto.Click
        Try
            If C1FlexGrid.Rows.Count > 1 Then
                MsgBox("已经有科目存在，不允许再导入科目", MsgBoxStyle.OkOnly, "创源提示")

            Else
                Dim frmnew As New FrmLeadInto
                frmnew.CYSysInfo = Me.CYSysInfo
                frmnew.CYUserInfo = Me.CYUserInfo
                frmnew.Show()
                AccountTreeBind()
                sql = "select a.faccountid as 编码,a.fnumber as 科目编码 ,a.fname as 科目名称,a.flevel as 科目级次 ,a.fhelpercode as 助记码,t.FName as 科目类别,case when FDC=1 then '借' else '贷' end as '余额方向',case a.FcurrencyID when 0 then '所有币别' when 1 then '不核算' else b.Fname end [外币核算],case a.FQuantities when 1 then '是' else '否' end [数量核算],a.fdetail,a.frootid,a.fgroupid  ,FdetailID,convert(varchar(255),'') [核算项目] into #aa from t_account a ,t_acctGroup t,t_currency b where ( FDelete=0 Or  FIsAcnt=1)  and a.FGroupID=t.FGroupID and b.FcurrencyID=a.FcurrencyID  " '接下来的级别
                sql = sql & " declare @name varchar(100)  declare my_cursor cursor for select distinct FdetailID from #aa where FdetailID>0"
                sql = sql & " open my_cursor declare @detailID int fetch next from my_cursor into @detailID while(@@fetch_status=0)"
                sql = sql & " begin 	set @name='' 	select @name=@name + Fname+ '/' from t_itemdetailv v1 inner join "
                sql = sql & " t_itemclass t1 on v1.FitemclassID=t1.FitemclassID where FdetailID=@detailID update #aa set 核算项目="
                sql = sql & " substring(@name,1,len(@name)-1) where FdetailID=@detailID 	fetch next from my_cursor into @detailID"
                sql = sql & " end close my_cursor deallocate my_cursor select * from #aa order by 科目编码 drop table #aa"
        
                DBOpen = New BLuser
                ds2 = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
                C1FlexGrid.DataSource = ds2.Tables(0)
                C1FlexGrid.Cols("编码").Width = -1
                C1FlexGrid.Cols("科目编码").Width = 120
                C1FlexGrid.Cols("科目名称").Width = 150
                C1FlexGrid.Cols("科目级次").Width = 100
                C1FlexGrid.Cols("助记码").Width = 100
                C1FlexGrid.Cols("科目类别").Width = 100
                C1FlexGrid.Cols("余额方向").Width = 100
                C1FlexGrid.Cols("fdetail").Width = -1
                C1FlexGrid.Cols("frootid").Width = -1
                C1FlexGrid.Cols("fgroupid").Width = -1
                C1FlexGrid.Cols("FDetailID").Width = -1
                C1FlexGrid.Cols("核算项目").Width = 120
                '绑定序号一级右上角的信息
                For i = 0 To ds2.Tables(0).Rows.Count - 1
                    Me.C1FlexGrid.Rows(i + 1)("序号") = (i + 1).ToString
                Next
                Me.Label2.Text = "[科目表] 的内容------共计：" & ds2.Tables(0).Rows.Count & "记录"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class