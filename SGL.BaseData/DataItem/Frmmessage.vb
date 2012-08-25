

Imports SGL.BLL

Public Class Frmmessage
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
    Public IM As String = "0"
    Public m_sqlWhere As String = ""
#End Region
    Private Sub InitPage()
        Try
            'Me.cobSearchType.Items.Add("代码")
            'Me.cobSearchType.Items.Add("名称")


            Me.cobSearchType.Text = Me.m_strItemClassName
            Me.cobMatchingType.SelectedIndex = 0
            Me.cobSearchType.SelectedIndex = 1
            grdItemsBind(S_Classid)

            Me.C1FlexGrid1.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FrmItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If S_Classid > 0 Then
            InitPage()
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            'C1FlexGrid1.Focus()
            txtSearchText.Focus()
        Else
            Me.Close()
        End If

    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Me.Cursor = Cursors.WaitCursor
        Dim sglmyh As String
        Dim matchType As String = ""
        Try
            If m_dsItemsInfo.Tables.Count > 0 Then
                m_dsItemsInfo.Tables(0).Clear()
            End If
            If S_Classid = 99981 Or S_Classid = 99982 Then
                Exit Sub
            End If
            Select Case cobMatchingType.Text.Trim
                Case "包含"
                    matchType = " like '%" & txtSearchText.Text & "%'"
                Case "等于"
                    matchType = " = '" & txtSearchText.Text & "'"
                Case "左匹配"
                    matchType = " like '" & txtSearchText.Text & "%'"
                Case "右匹配"
                    matchType = " like '%" & txtSearchText.Text & "'"
            End Select
            If txtSearchText.Text <> "" Then
                Select Case cobSearchType.SelectedIndex
                    Case 0
                        If S_Classid = 99989 Then
                            Sglstr = "exec P_SGL_Htselname  '" & txtSearchText.Text & "'"
                            '结算方式 modified by nbb
                            Sglstr = ""
                            Sglstr += " select identity(int,1,1) as findex,fitemid,fnumber,fname into #dsub from t_Settle where fitemid>0 and FDeleted=0"
                            Sglstr += " select findex as 序号,fitemid ,fnumber as 代码,fname as 名称 from #dsub where FNumber " & matchType
                            Sglstr += "   drop table #dsub"

                        ElseIf S_Classid = 88889 Then
                            Sglstr = ""
                            Sglstr += " select identity(int,1,1) as findex,FInterID as fitemid,FBillNo as fname,fcustid into #dsub from seoutstock where  fstatus>0 and isnull(fclosed,0)=0"
                            Sglstr += " select t1.findex as 序号,fitemid ,t1.fname as 编号,t2.fname as 客户 from #dsub t1 left join t_item t2 on t1.fcustid=t2.fitemid where t1.fname " & matchType
                            Sglstr += "   drop table #dsub"
                        ElseIf S_Classid = 10999 Then
                            Sglstr = ""
                            Sglstr += " declare @custID int set @custID=" & Me.IM.ToString()
                            Sglstr += " if exists(select 1 from t_Organization where FItemID=@custID and isnull(F_103,0)>0)"                            Sglstr += " select @custID=F_103 from t_Organization where FItemID=@custid"
                            Sglstr += " select identity(int,1,1) as findex,t1.FNumber as fitemid,t1.FNumber as Fname,t2.FName as FCustName,t1.FAmount,t1.FDate into #dsub from t_SGL_newreceivebill t1"
                            Sglstr += " left join t_Organization t2 on t1.FCustomer=t2.FItemID"
                            Sglstr += " where t1.FClassTypeID=1000013 and t1.FCustomer in (select FItemID from t_Organization where isnull(F_103,0)=@custID or FItemID=@custID) order by t1.FDate DESC"
                            Sglstr += " select t1.findex as 序号,fitemid ,t1.fname as 编号,t1.FCustName as 客户,t1.FDate as 日期 from #dsub t1 where t1.fname " & matchType
                            Sglstr += "   drop table #dsub"
                        Else

                            Sglstr = ""
                            Sglstr += " select identity(int,1,1) as findex,finterid as fitemid ,fid  as fnumber,fname into #dsub from t_SubMessage where ftypeid='" & S_Classid & "'"
                            Sglstr += " select findex as 序号,fitemid ,fnumber as 代码,fname as 名称 from #dsub where FNumber " & matchType
                            Sglstr += "   drop table #dsub"
                        End If
                    Case 1
                        If S_Classid = 99989 Then
                            Sglstr = "exec P_SGL_Htselname  '" & txtSearchText.Text & "'"
                        ElseIf S_Classid = 88888 Then '结算方式 modified by nbb
                            Sglstr = ""
                            Sglstr += " select identity(int,1,1) as findex,fitemid,fnumber,fname into #dsub from t_Settle where fitemid>0 and FDeleted=0"
                            Sglstr += " select findex as 序号,fitemid ,fnumber as 代码,fname as 名称 from #dsub where fname " & matchType
                            Sglstr += "   drop table #dsub"
                        ElseIf S_Classid = 99988 Then
                            Sglstr = ""
                            Sglstr += " select fbillno,finterid into #dsub from icstockbill  where ftrantype=21"
                            Sglstr += " select fbillno,finterid  from #dsub  where fbillno" & matchType
                            Sglstr += "   drop table #dsub"
                        ElseIf S_Classid = 88889 Then
                            Sglstr = ""
                            Sglstr += " select identity(int,1,1) as findex,FInterID as fitemid,FBillNo as fname,fcustid into #dsub from seoutstock where  fstatus>0 and isnull(fclosed,0)=0"
                            Sglstr += " select t1.findex as 序号,t1.fitemid ,t1.fname as 编号,t2.fname as 客户 from #dsub t1 left join t_item t2 on t1.fcustid=t2.fitemid where t1.fname " & matchType
                            Sglstr += "   drop table #dsub"
                        ElseIf S_Classid = 10999 Then
                            Sglstr = ""
                            Sglstr += " declare @custID int set @custID=" & Me.IM.ToString()
                            Sglstr += " if exists(select 1 from t_Organization where FItemID=@custID and isnull(F_103,0)>0)"                            Sglstr += " select @custID=F_103 from t_Organization where FItemID=@custid"
                            Sglstr += " select identity(int,1,1) as findex,t1.FNumber as fitemid,t1.FNumber as Fname,t2.FName as FCustName,t1.FAmount,t1.FDate into #dsub from t_SGL_newreceivebill t1"
                            Sglstr += " left join t_Organization t2 on t1.FCustomer=t2.FItemID"
                            Sglstr += " where t1.FClassTypeID=1000013 and t1.FCustomer in (select FItemID from t_Organization where isnull(F_103,0)=@custID or FItemID=@custID) order by t1.FDate DESC"
                            Sglstr += " select t1.findex as 序号,fitemid ,t1.fname as 编号,t1.FCustName as 客户,t1.FDate as 日期 from #dsub t1 where t1.fname " & matchType
                            Sglstr += "   drop table #dsub"
                        Else
                            Sglstr = ""
                            Sglstr += " select identity(int,1,1) as findex,finterid as fitemid ,fid  as fnumber,fname into #dsub from t_SubMessage where ftypeid='" & S_Classid & "'"
                            Sglstr += " select findex as 序号,fitemid ,fnumber as 代码,fname as 名称 from #dsub where fname  " & matchType
                            Sglstr += "   drop table #dsub"
                        End If
                End Select

                DBOpen = New BLuser
                m_dsItemsInfo = DBOpen.GetDataset(Sglstr, constr)

                If m_dsItemsInfo.Tables.Count > 0 Then
                    Me.C1FlexGrid1.DataSource = m_dsItemsInfo.Tables(0)
                    Me.C1FlexGrid1.Cols("fitemid").Width = -1
                    Me.C1FlexGrid1.Cols(1).Width = 30
                    If Me.C1FlexGrid1.Cols.Count >= 4 Then
                        Me.C1FlexGrid1.Cols(3).Width = 150
                        Me.C1FlexGrid1.Cols(4).Width = 150
                    End If
                    Me.C1FlexGrid1.Cols(1).Style.BackColor = Color.FromArgb(108, 155, 200)
                Else

                    Me.C1FlexGrid1.DataSource = m_dsItemsInfo.Tables(0)
                    Me.C1FlexGrid1.Cols(1).Width = 150
                    Me.C1FlexGrid1.Cols(2).Width = 150
                End If
            Else
                grdItemsBind(S_Classid)

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
        Dim item As String
        Try
            intRow = Me.C1FlexGrid1.Row
            If intRow > 0 Then
                item = C1FlexGrid1.Item(intRow, "fitemid")
                If S_Classid = "99999" Then
                    Sglstr = "select fid as fitemid,* from  icbilltype where fid ='" & item.ToString & "'"
                ElseIf S_Classid = "99989" Then
                    Sglstr = "exec  P_SGL_Htsel  '" & item.ToString & "'"
                ElseIf S_Classid = "99987" Then
                    Sglstr = "select finterid as fitemid,fbillno as Fname,t2.FItemid as fitemid1 ,t2.fname as Fname1 from t_nzy_Contract t1 left join T_Item t2 on t1.fcustomerid=t2.fitemid   where finterid ='" & item.ToString & "'"
                ElseIf S_Classid = "99986" Then
                    Sglstr = "exec  P_SGL_NewHtsel  '" & item.ToString & "'"
                ElseIf S_Classid = "99981" Then
                    Sglstr = "exec  P_SGL_batchnosel1  '" & item.ToString & "'"
                ElseIf S_Classid = "99982" Then
                    Sglstr = "exec  P_SGL_batchnosel2  '" & item.ToString & "'"
                ElseIf S_Classid = "99980" Then
                    Sglstr = "exec  P_SGL_ColorManagerSel  '" & item.ToString & "'"
                ElseIf S_Classid = "88888" Then
                    Sglstr = "select  * from  t_Settle where fitemid ='" & item.ToString & "'"
                ElseIf S_Classid = "66666" Then   '币别
                    Sglstr = " select fcurrencyid as FItemID, fname ,FExchangeRate from  t_currency where fcurrencyid>0 and fcurrencyid= '" & item.ToString & "'"
                ElseIf S_Classid = "77777" Then
                    Sglstr = "Select FItemID,FName From t_rp_systemenum Where fitemid ='" & item.ToString & "'"
                ElseIf S_Classid = "10016" Then  '付款单
                    Sglstr = "Select FItemID ,FName  From t_rp_systemenum Where FType=14 and fitemid ='" & item.ToString & "'"
                ElseIf S_Classid = "10022" Then  '其他应付单单据类型
                    Sglstr = "Select FItemID ,FName  From t_rp_systemenum Where FType=12 and  fitemid ='" & item.ToString & "'"
                ElseIf S_Classid = "10021" Then  '其他应shou单单据类型
                    Sglstr = "Select FItemID ,FName  From t_rp_systemenum Where FType=11  and fitemid ='" & item.ToString & "'"
                ElseIf S_Classid = "10099" Then  '核算项目类别
                    Sglstr = "select fitemclassid  AS fitemid,FName    from t_itemclass where fitemclassid ='" & item.ToString & "'"
                ElseIf S_Classid = "10098" Then  '发票类型
                    Sglstr = " select * from (select 80 AS 序号,80 fitemid,'普通发票' as Fname,'普通发票' as FNumber union all select 85 AS 序号,85 fitemid,'专用发票' as 代码,'专用发票' ) t where fitemid='" & item.ToString & "'"
                ElseIf S_Classid = "88889" Then
                    Sglstr = " select FInterID as fitemid,FBillNo as FName from seoutstock where fstatus>0 and isnull(fclosed,0)=0 and finterid='" & item.ToString & "'"
                ElseIf S_Classid = "10999" Then
                    Sglstr = " select FNumber as fitemid,FNumber as FName from t_SGL_newreceivebill where FNumber='" & item.ToString & "'"
                ElseIf S_Classid > 1000000 Then
                    Dim tempDt As DataSet
                    Sglstr = " select FSQL from t_CS_LookUpSQL where FLookUpID=" + S_Classid.ToString()
                    tempDt = DBOpen.GetDataset(Sglstr, constr)
                    Sglstr = "select * into #dsub_" + S_Classid.ToString() + " from " + tempDt.Tables(0).Rows(0)("FSQL").ToString().Replace("^", "'")
                    Sglstr += " select fitemid ,fname from #dsub_" + S_Classid.ToString() + "  where FItemID=" + item.ToString()
                    Sglstr += "   drop table #dsub_" + S_Classid.ToString()
                Else

                    Sglstr = "select finterid as fitemid,* from  t_SubMessage where finterid ='" & item.ToString & "'"
                End If

                DBOpen = New BLuser
                RtnDataTable = DBOpen.GetDataset(Sglstr, constr)
                If Me.RtnDataTable.Tables(0).Rows.Count > 0 Then

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
    Private Sub grdItemsBind(ByVal SelNode As String)
        Try
            DBOpen = New BLL.BLuser
            If m_dsItemsInfo.Tables.Count > 0 Then
                m_dsItemsInfo.Tables(0).Clear()
            End If
            If SelNode = "99999" Then
                Sglstr = "select fid as 序号,fid as fitemid ,fnumber as 代码,fname as 名称 from icbilltype " 'where fid<3"
            ElseIf SelNode = "99989" Then
                Sglstr = "exec P_SGL_Ht '" & IM.ToString & "'"
            ElseIf SelNode = "99987" Then
                Sglstr = "select finterid as 序号,finterid as fitemid ,fbillno as 名称,t2.fname as 客户 from t_nzy_Contract t1 left join T_Item t2 on t1.fcustomerid=t2.fitemid   where isnull(fisgb,0)=0 and fstatus>0 order by fbillno"
            ElseIf SelNode = "99986" Then
                Sglstr = "exec P_SGL_NewHt '" & IM.ToString & "'"
            ElseIf SelNode = "99981" Then
                Sglstr = "exec P_SGL_batchno1 '" & IM.ToString & "'"
            ElseIf SelNode = "99982" Then
                Sglstr = "exec P_SGL_batchno2 '" & IM.ToString & "'"
            ElseIf SelNode = "99980" Then
                Sglstr = "exec  P_SGL_ColorManager  '" & IM.ToString & "'"
            ElseIf SelNode = "88888" Then
                Sglstr = "select fitemid as 序号, fitemid ,fnumber as 代码,fname as 名称 from  t_Settle where fitemid>0"
            ElseIf SelNode = "66666" Then   '币别
                Sglstr = " select fcurrencyid as 序号, fcurrencyid fitemid ,fnumber as 代码,fname as 名称 from  t_currency where fcurrencyid>0 "
            ElseIf SelNode = "77777" Then     '收款单
                Sglstr = "Select FItemID as 序号,fitemid,fnumber as 代码,FName as 名称 From t_rp_systemenum Where FType=13"
            ElseIf SelNode = "10016" Then  '付款单
                Sglstr = "Select FItemID as 序号,fitemid,fnumber as 代码,FName as 名称 From t_rp_systemenum Where FType=14"
            ElseIf SelNode = "10022" Then  '其他应付单单据类型
                Sglstr = "Select FItemID as 序号,fitemid,fnumber as 代码,FName as 名称 From t_rp_systemenum Where FType=12"
            ElseIf SelNode = "10021" Then  '其他应付单单据类型
                Sglstr = "Select FItemID as 序号,fitemid,fnumber as 代码,FName as 名称 From t_rp_systemenum Where FType=11"
            ElseIf SelNode = "10099" Then  '核算项目类别
                Sglstr = "select fitemclassid AS 序号,fitemclassid  AS fitemid,fnumber as 代码,FName as 名称   from t_itemclass where fitemclassid in (1,2,3,8) "
            ElseIf SelNode = "10098" Then  '发票类型
                Sglstr = "select 80 AS 序号,80 fitemid,'普通发票' as 代码,'普通发票' as 名称 union all select 85 AS 序号,85 fitemid,'专用发票' as 代码,'专用发票' as 名称 "
            ElseIf SelNode = "88889" Then
                Sglstr = " select finterid as 序号,finterid as fitemid ,fbillno as 名称,t2.fname as 客户 from seoutstock t1 left join T_Item t2 on t1.FCustID=t2.fitemid where fstatus>0 and isnull(fclosed,0)=0"
            ElseIf S_Classid = 10999 Then
                Sglstr = ""
                Sglstr += " declare @custID int set @custID=" & Me.IM.ToString()
                Sglstr += " if exists(select 1 from t_Organization where FItemID=@custID and isnull(F_103,0)>0)"                Sglstr += " select @custID=F_103 from t_Organization where FItemID=@custid"
                Sglstr += " select identity(int,1,1) as findex,t1.FNumber as fitemid,t1.FNumber as Fname,t2.FName as FCustName,t1.FAmount,t1.FDate into #dsub from t_SGL_newreceivebill t1"
                Sglstr += " left join t_Organization t2 on t1.FCustomer=t2.FItemID"
                Sglstr += " where t1.FClassTypeID=1000013 and t1.FCustomer in (select FItemID from t_Organization where isnull(F_103,0)=@custID or FItemID=@custID) order by t1.FDate DESC"
                Sglstr += " select t1.findex as 序号,fitemid ,t1.fname as 编号,t1.FCustName as 客户,t1.FDate as 日期 from #dsub t1"
                Sglstr += "   drop table #dsub"
            ElseIf S_Classid > 1000000 Then
                Dim tempDt As DataSet
                Sglstr = " select FSQL from t_CS_LookUpSQL where FLookUpID=" + S_Classid.ToString()
                tempDt = DBOpen.GetDataset(Sglstr, constr)
                Sglstr = "select * into #dsub_" + S_Classid.ToString() + " from " + tempDt.Tables(0).Rows(0)("FSQL").ToString().Replace("^", "'")
                Sglstr += " declare @SqlOtherFields varchar(1000) set @SqlOtherFields='' declare @Sql varchar(1000) set @Sql=''"
                Sglstr += " select @SqlOtherFields=@SqlOtherFields + ',' + Name from tempdb.dbo.syscolumns where id=object_id('tempdb.dbo.#dsub_" + S_Classid.ToString() + "')"
                Sglstr += " and Lower(Left(Name,1))<>'f'"
                Sglstr += " set @Sql='select findex as 序号,fitemid ,fnumber as 代码,fname as 名称' + @SqlOtherFields + ' from #dsub_" + S_Classid.ToString() + " where 1=1 " + m_sqlWhere + "  order by fnumber"
                Sglstr += "   drop table #dsub_" + S_Classid.ToString() + "'"
                Sglstr += " exec(@Sql)"
            Else
                Sglstr = ""
                Sglstr += " select identity(int,1,1) as findex,finterid as fitemid ,fid  as fnumber,fname into #dsub from t_SubMessage where ftypeid='" & SelNode & "'"
                Sglstr += " select findex as 序号,fitemid ,fnumber as 代码,fname as 名称 from #dsub  order by fnumber"
                Sglstr += "   drop table #dsub"
            End If

            m_dsItemsInfo = DBOpen.GetDataset(Sglstr, constr)

            If m_dsItemsInfo.Tables.Count > 0 Then
                Me.C1FlexGrid1.DataSource = m_dsItemsInfo.Tables(0)
                Me.C1FlexGrid1.Cols("fitemid").Width = -1
                Me.C1FlexGrid1.Cols(1).Width = 30
                If Me.C1FlexGrid1.Cols.Count >= 4 Then
                    Me.C1FlexGrid1.Cols(3).Width = 150
                    Me.C1FlexGrid1.Cols(4).Width = 150
                End If
                '批号信息的宽度格式修改
                If SelNode = "99981" Then
                    Me.C1FlexGrid1.Cols(3).Width = 70
                    Me.C1FlexGrid1.Cols(4).Width = 1
                End If


                'If SelNode = "" Then
                '    txtTypeName.Text = m_dsItemsInfo.Tables(1).Rows(0)(0)
                'End If

                Me.C1FlexGrid1.Cols(1).Style.BackColor = Color.FromArgb(108, 155, 200)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub C1FlexGrid1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles C1FlexGrid1.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Dim intRow As Integer
        Dim dt As New DataTable
        Dim item As String
        Try
            If e.KeyCode <> Keys.Enter Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            intRow = Me.C1FlexGrid1.Row
            If intRow > 0 Then
                item = C1FlexGrid1.Item(intRow, "fitemid")
                If S_Classid = "99999" Then
                    Sglstr = "select fid as fitemid,* from  icbilltype where fid ='" & item.ToString & "'"
                ElseIf S_Classid = "99989" Then
                    Sglstr = "exec  P_SGL_Htsel  '" & item.ToString & "'"
                ElseIf S_Classid = "99981" Then
                    Sglstr = "exec  P_SGL_batchnosel1  '" & item.ToString & "'"
                ElseIf S_Classid = "99982" Then
                    Sglstr = "exec  P_SGL_batchnosel2  '" & item.ToString & "'"
                ElseIf S_Classid = "99980" Then
                    Sglstr = "exec  P_SGL_ColorManagerSel  '" & item.ToString & "'"
                ElseIf S_Classid = "88888" Then
                    Sglstr = "select  * from  t_Settle where fitemid ='" & item.ToString & "'"
                ElseIf S_Classid = "66666" Then   '币别
                    Sglstr = " select fcurrencyid as FItemID, fname ,FExchangeRate from  t_currency where fcurrencyid>0 and fcurrencyid= '" & item.ToString & "'"
                ElseIf S_Classid = "77777" Then
                    Sglstr = "Select FItemID,FName From t_rp_systemenum Where fitemid ='" & item.ToString & "'"
                ElseIf S_Classid = "10016" Then  '付款单
                    Sglstr = "Select FItemID ,FName  From t_rp_systemenum Where FType=14 and fitemid ='" & item.ToString & "'"
                ElseIf S_Classid = "10022" Then  '其他应付单单据类型
                    Sglstr = "Select FItemID ,FName  From t_rp_systemenum Where FType=12 and  fitemid ='" & item.ToString & "'"
                ElseIf S_Classid = "10021" Then  '其他应shou单单据类型
                    Sglstr = "Select FItemID ,FName  From t_rp_systemenum Where FType=11  and fitemid ='" & item.ToString & "'"
                ElseIf S_Classid = "10099" Then  '核算项目类别
                    Sglstr = "select fitemclassid  AS fitemid,FName    from t_itemclass and fitemclassid ='" & item.ToString & "'"
                ElseIf S_Classid = "88889" Then
                    Sglstr = " select FInterID as fitemid,FBillNo as FName from seoutstock where fstatus>0 and isnull(fclosed,0)=0 and finterid='" & item.ToString & "'"
                Else

                    Sglstr = "select finterid as fitemid,* from  t_SubMessage where finterid ='" & item.ToString & "'"
                End If

                DBOpen = New BLuser
                RtnDataTable = DBOpen.GetDataset(Sglstr, constr)
                If Me.RtnDataTable.Tables(0).Rows.Count > 0 Then

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

    ''' <summary>
    ''' 查询框按回车查询
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtSearchText_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchText.KeyDown
        If e.KeyCode = 13 Then
            btnSearch_Click(sender, e)
        End If
    End Sub
End Class