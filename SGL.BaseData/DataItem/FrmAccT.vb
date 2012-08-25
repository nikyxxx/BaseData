Imports PublicSharedResource
Imports C1.Win.C1FlexGrid
Imports SGL.BLL
Imports PublicSharedResource.PublicSharedFunctions
Public Class FrmAccT
    Inherits frmBase
    Public frm As Faccountlist
    Public faccountid, FLnumber, FCnumber, FLname, flevel, frank, sql, sql1, sql2, FDC As String
    Public i, j, gridindex As Integer
    Public ds, ds1, ds2, dsd, dsd1 As System.Data.DataSet
    Public S_Classid As Integer
    Public constr As String
    Private DBOpen As BLuser
    Public RtnDataTable As DataSet
    Private dstable As DataTable
    Public Sub AddNew()
        Me.C1TextBox1.Text = ""
        Me.ComboBox1.Text = ""
        Me.fnumber.Text = ""
        Me.C1TextBox7.Text = ""
        Me.C1TextBox7.Value = ""
        Me.C1TextBox2.Text = ""
        Me.C1TextBox2.Value = ""
        Me.fname.Text = ""
        Me.fname.Value = ""
        Me.CheckBox8.Checked = False
        Me.CheckBox2.Checked = False
        Me.CheckBox1.Checked = False
        Me.CheckBox3.Checked = False
        Me.CheckBox4.Checked = False
        Me.CheckBox6.Checked = False
        Me.CheckBox7.Checked = False
        Me.CheckBox5.Checked = False
        Me.CheckBox17.Checked = False
        Me.C1TextBox5.Text = 0
        Me.C1TextBox6.Text = ""
        Me.C1TextBox9.Text = ""
        Me.C1TextBox10.Text = ""
        Me.C1TextBox25.Text = ""
        Me.C1TextBox26.Text = 1
        Me.CurrencyItem.SelectedValue = 1

        C1DropDownControl4.Text = ""
        Me.Text = "会计科目-新增"
        toolBarControlStatus(Status.新增)
    End Sub
    ''' <summary>
    ''' 取基础资料
    ''' </summary>
    ''' <param name="itm">ID条件</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Loaditamdate(ByVal itm As String) As System.Data.DataTable
        Dim newform As New SGL.BaseData.Frmaccount
        Dim newform2 As New SGL.BaseData.FrmItems
        Dim newform3 As New SGL.BaseData.Frmmessage
        Dim clid As Integer
        Dim ssss As DataTable
        clid = itm
        If clid = -1 Then
            newform.constr = Me.CYSysInfo.ConnStrValue
            newform.ShowDialog()
            If newform.RtnDataTable.Tables.Count > 0 Then
                ssss = newform.RtnDataTable.Tables(0)
                Return ssss
            End If
        ElseIf clid < -1 Then
            newform3.constr = Me.CYSysInfo.ConnStrValue
            newform3.S_Classid = clid * -1
            newform3.ShowDialog()
            If newform3.RtnDataTable.Tables.Count > 0 Then
                ssss = newform3.RtnDataTable.Tables(0)
                Return ssss
            End If
        Else
            newform2.constr = Me.CYSysInfo.ConnStrValue
            newform2.S_Classid = clid
            newform2.ShowDialog()
            If newform2.RtnDataTable.Tables.Count > 0 Then
                ssss = newform2.RtnDataTable.Tables(0)
                Return ssss
            End If
        End If
        Return Nothing
    End Function

    Private Sub bind(ByVal faccountid As Integer, ByVal frank As Integer)
        Dim dr As System.Data.DataRow

        Me.Cursor = Cursors.WaitCursor
        sql = "Select a.*, c.FNumber as FCurrencyNumber, c.FName as FCurrencyName, case when u.FName='*' then '' else u.FName end as FUnitGroup, case when mu.FName='*' then '' else mu.FName end  as FMeasureUnit ,t.fname as '科目类别' from t_Account a Left Outer join t_MeasureUnit "
        sql += "mu on a.FMeasureUnitID = mu.FMeasureUnitID , t_Currency c, t_UnitGroup u ,t_AcctGroup t where a.FGroupID=t.FGroupID and a.FCurrencyID = c.FCurrencyID and a.FUnitGroupID = u.FUnitGroupID and a.FAccountID = " & faccountid
        'ds.Clear()
        DBOpen = New BLuser
        ds = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
        'Me.fnumber.Text = ds.Tables(0).Rows(0)("FNumber").ToString
        Me.C1TextBox1.Text = ds.Tables(0).Rows(0)("FName").ToString
        Me.ComboBox1.Text = ConvertFDC(ds.Tables(0).Rows(0)("FDC").ToString)

        FDC = ds.Tables(0).Rows(0)("FDC").ToString
        Me.fnumber.Text = ds.Tables(0).Rows(0)("Fnumber").ToString
        Me.C1TextBox7.Text = ds.Tables(0).Rows(0)("科目类别").ToString
        Me.C1TextBox7.Value = ds.Tables(0).Rows(0)("FGroupid")
        Me.C1TextBox2.Text = ds.Tables(0).Rows(0)("FUnitGroup").ToString
        Me.C1TextBox2.Value = ds.Tables(0).Rows(0)("funitgroupid").ToString
        Me.fname.Text = ds.Tables(0).Rows(0)("FMeasureUnit").ToString
        Me.fname.Value = ds.Tables(0).Rows(0)("fmeasureunitid").ToString
        Me.CheckBox8.Checked = ds.Tables(0).Rows(0)("FQuantities").ToString
        Me.CheckBox2.Checked = ds.Tables(0).Rows(0)("FIsBank").ToString
        Me.CheckBox1.Checked = ds.Tables(0).Rows(0)("FIsCash").ToString
        Me.CheckBox3.Checked = ds.Tables(0).Rows(0)("FIsCashFlow").ToString
        Me.CheckBox4.Checked = ds.Tables(0).Rows(0)("FJournal").ToString
        Me.CheckBox6.Checked = ds.Tables(0).Rows(0)("FAcctint").ToString
        Me.CheckBox7.Checked = ds.Tables(0).Rows(0)("FContact").ToString
        Me.CheckBox5.Checked = ds.Tables(0).Rows(0)("FIsBudget") * 1000
        Me.CheckBox17.Checked = ds.Tables(0).Rows(0)("FAdjustRate").ToString
        Me.C1TextBox5.Text = ds.Tables(0).Rows(0)("FintRate").ToString
        Me.C1TextBox6.Text = ds.Tables(0).Rows(0)("FName_Eng").ToString
        Me.C1TextBox9.Text = ds.Tables(0).Rows(0)("FBank").ToString
        Me.C1TextBox10.Text = ds.Tables(0).Rows(0)("FBankNO").ToString
        Me.C1TextBox25.Text = ds.Tables(0).Rows(0)("FHelperCode").ToString
        Me.C1TextBox26.Text = ds.Tables(0).Rows(0)("FLevel").ToString
        Me.CurrencyItem.SelectedValue = ds.Tables(0).Rows(0)("FCurrencyID").ToString
        If PublicSharedFunctions.ChgNullToDouble(ds.Tables(0).Rows(0)("FSubCFItemID")) = 1 Then
            C1DropDownControl4.Text = "应收应付系统"
        Else
            C1DropDownControl4.Text = ""
        End If


        Me.C1TextBox8.Enabled = False
        Me.C1TextBox26.Enabled = False

        ' 判断其下面是否还有子节点
        If Me.Text = "会计科目-修改" Then

            If Me.HaveUsed(Integer.Parse(Me.faccountid)) = True Then
                Me.CheckBox8.Enabled = False
                Me.C1TextBox2.Enabled = False
                Me.fname.Enabled = False
                Me.Button4.Enabled = False
                Me.Button7.Enabled = False
                Me.CheckBox2.Enabled = False
                Me.C1TextBox9.Enabled = False
                Me.C1TextBox10.Enabled = False
                Me.CheckBox1.Enabled = False
                Me.CheckBox3.Enabled = False
                Me.CheckBox4.Enabled = False
                Me.CheckBox7.Enabled = False
                Me.btnSearch.Enabled = False
                Me.Button13.Enabled = False
            End If

            If ds.Tables(0).Rows(0)("FLevel") > 1 Then
                sql = ""
                sql = "select fname from t_account where faccountid=" & ds.Tables(0).Rows(0)("FParentID")
                'ds1.Clear()
                DBOpen = New BLuser
                ds1 = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
                Me.C1TextBox8.Text = ds1.Tables(0).Rows(0)("fname")
            End If
        End If


        '''''绑定现金流量表
        If Me.Text = "会计科目-修改" Then
            Me.C1TextBox7.Enabled = False
            sql = ""
            sql = "select i.fitemid,i.FName from t_account a , t_item i where fitemid <> 0 and i.fitemid=a.fcfitemid and faccountid=" & faccountid
            'ds.Clear()
            DBOpen = New BLuser
            ds = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
            If ds.Tables(0).Rows.Count <> 0 Then
                Me.C1TextBox3.Text = ds.Tables(0).Rows(0)("fname")
                Me.C1TextBox3.Value = ds.Tables(0).Rows(0)("fitemid")
            End If


            sql = ""
            sql = "select i.fitemid,i.FName from t_account a , t_item i where fitemid <> 0 and  i.fitemid=a.FSubCFItemID and faccountid=" & faccountid
            ds.Clear()
            DBOpen = New BLuser
            ds = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
            If ds.Tables(0).Rows.Count <> 0 Then
                Me.C1TextBox4.Text = ds.Tables(0).Rows(0)("fname")
                Me.C1TextBox4.Value = ds.Tables(0).Rows(0)("fitemid")
            End If
        End If

        '''''绑定核算项目
        '''''
        sql = ""
        sql = "Select i.FNumber FItemClassNumber, i.FName FItemClassName, i.FItemClassID FItemClassID ,CASE ai.FItemID WHEN -1 THEN 1 ELSE 0 END FBalChecked  From t_Account a, "
        sql += " t_ItemClass i,t_ItemDetailV ai Where  a.FDetailID = ai.FDetailID And  ai.FItemClassID = i.FItemClassID And  ai.FItemID In(-1,-2) And a.faccountid=" & faccountid
        ds.Clear()
        DBOpen = New BLuser
        ds = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            Me.C1FlexGrid2.Item(i + 1, "FItemClassNumber") = ds.Tables(0).Rows(i)("FItemClassNumber")
            Me.C1FlexGrid2.Item(i + 1, "FItemClassName") = ds.Tables(0).Rows(i)("FItemClassName")
            Me.C1FlexGrid2.Item(i + 1, "FItemClassID") = ds.Tables(0).Rows(i)("FItemClassID")
            Me.C1FlexGrid2.Item(i + 1, "序号") = (i + 1).ToString
        Next
        '科目预算-绑定币别
        If Me.Text = "会计科目-修改" Then
            sql = ""
            sql = "select t.Fcurrencyid,t.Fname from t_account a,t_currency t where  a.fcurrencyid=t.fcurrencyid and  t.fcurrencyid<>0 and a.faccountid =" & faccountid

            DBOpen = New BLuser
            dsd = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
            If dsd.Tables(0).Rows.Count = 0 Then
                sql1 = ""
                sql1 = "select Fcurrencyid,FName from t_currency where fcurrencyid<>0"
                'dsd1.Clear()
                dsd1 = DBOpen.GetDataset(sql1, Me.CYSysInfo.ConnStrValue)
                dr = dsd1.Tables(0).NewRow()
                dr(0) = "0"
                dr(1) = "综合本位币 "
                dsd1.Tables(0).Rows.Add(dr)
                Me.C1Combo1.DataSource = dsd1.Tables(0)
                Me.C1Combo1.DisplayMember = "fname"
                Me.C1Combo1.ValueMember = "fcurrencyid"
                Me.C1Combo1.Splits(0).DisplayColumns(0).Visible = False
                Me.C1Combo1.ColumnHeaders = False
                Me.C1Combo1.SelectedIndex = 0
            Else
                dr = dsd.Tables(0).NewRow
                dr(0) = "0"
                dr(1) = "综合本位币 "
                dsd.Tables(0).Rows.Add(dr)
                Me.C1Combo1.DataSource = dsd.Tables(0)
                Me.C1Combo1.DisplayMember = "Fname"
                Me.C1Combo1.ValueMember = "Fcurrencyid"
                Me.C1Combo1.Splits(0).DisplayColumns(0).Visible = False
                Me.C1Combo1.ColumnHeaders = False
                Me.C1Combo1.SelectedIndex = 0
            End If
        End If

        ''界面逻辑判断
        If Me.Text = "会计科目-新增" Then
            Me.C1DockingTabPage3.Enabled = False
            If Me.C1TextBox7.Text = "" Then

            Else
                Me.C1TextBox7.Enabled = False
            End If
        Else         '会计科目-编辑
            Me.Button6.Enabled = False
        End If
        Me.Cursor = Cursors.Default
    End Sub
    ''' <summary>
    ''' 保存科目
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveAccount()
        Dim currencyid As String

        currencyid = Me.CurrencyItem.SelectedValue.ToString

        If Me.fnumber.Text = "" Then
            MsgBox("请输入科目代码！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Exit Sub
        End If
        If Me.C1TextBox1.Text = "" Then
            MsgBox("请输入科目名称！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Exit Sub
        End If
        If Me.C1TextBox7.Text = "" Then
            MsgBox("请输入科目类别！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Exit Sub
        End If
        Try
            sql1 = ""
            sql1 = "select * from t_account where fnumber='" & Me.fnumber.Text.Trim.ToString & "' "
            '20110124 修改BYZZJ ,允许名称相同，原来名称不能相同
            'sql1 = sql1 & " or fname='" & Me.C1TextBox1.Text.Trim.ToString & "'"
            'ds.Clear()
            DBOpen = New BLuser
            ds = DBOpen.GetDataset(sql1, Me.CYSysInfo.ConnStrValue)
            If ds.Tables(0).Rows.Count = 0 Then  '判断是否存在
                If Me.fnumber.Text.Contains(".") = True Then  '是否为一级科目
                    Me.FLnumber = Me.fnumber.Text.Substring(0, Me.fnumber.Text.LastIndexOf("."))
                    sql2 = ""
                    sql2 = "select * from t_account where fnumber='" & Me.FLnumber.Trim.ToString & "'"

                    'ds2.Clear()
                    ds2 = DBOpen.GetDataset(sql2, Me.CYSysInfo.ConnStrValue)
                    If ds2.Tables(0).Rows.Count <> 0 Then '新增记录
                        If Me.ChangeDetail(Me.FLnumber) = True Then '更改上一级的fdetail
                            sql = ""
                            sql = "INSERT INTO t_Account "
                            sql += "(FNumber,FName,FGroupID,FDC,FHelperCode,FCurrencyID,FAdjustRate,FIsCash,FIsBank,FJournal,FContact,FQuantities,FUnitGroupID,FMeasureUnitID,FDetailID,FIsCashFlow,FAcnt,FInterest,FIsAcnt,FAcctint,FintRate,FLevel,FDetail,FParentID,FRootID,FIsBudget,FControlSystem,FName_Eng,FBank,FBankNO,FCFItemID,FSubCFItemID) "
                            sql += "  VALUES('" & Me.fnumber.Text.Trim.ToString & "','" & Me.C1TextBox1.Text.Trim & "','" & Me.C1TextBox7.Value & "',"
                            sql += Integer.Parse(ConvertFDC1(Me.ComboBox1.Text)) & ",'" & Me.C1TextBox25.Text.Trim.ToString & "'," & currencyid & " ," & ConvertTF(Me.CheckBox17.Checked) & "," & ConvertTF(Me.CheckBox1.Checked) & "," & ConvertTF(Me.CheckBox2.Checked) & ","
                            sql += ConvertTF(Me.CheckBox4.Checked) & "," & ConvertTF(Me.CheckBox7.Checked) & "," & ConvertTF(Me.CheckBox8.Checked) & ",'" & Me.C1TextBox2.Value & "','" & Me.fname.Value & "','" & InsertItem() & "',"
                            sql += ConvertTF(Me.CheckBox3.Checked) & ",0,0,0," & ConvertTF(Me.CheckBox6.Checked) & ",'" & Me.C1TextBox5.Text / 1000 & "'," & Integer.Parse(ds2.Tables(0).Rows(0)("FLevel").ToString) + 1 & ",1," & ds2.Tables(0).Rows(0)("FAccountid").ToString & "," & ds2.Tables(0).Rows(0)("FRootID") & "," & ConvertTF(Me.CheckBox5.Checked) & ",0,'"
                            sql += Me.C1TextBox6.Text.Trim.ToString & "','" & C1TextBox9.Text.Trim.ToString & "','" & C1TextBox10.Text.Trim.ToString & "','" & C1TextBox3.Value & "'," & IIf(C1DropDownControl4.Text = "应收应付系统", 1, 0) & ")"
                            DBOpen = New BLuser
                            DBOpen.sqlexecnon(sql, Me.CYSysInfo.ConnStrValue)
                            MsgBox("新增成功！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
                            AddNew()
                        Else
                            Exit Sub
                        End If
                    Else
                        MsgBox("上级科目不存在！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
                    End If


                Else '成为一级科目
                    sql = ""
                    sql = "INSERT INTO t_Account "
                    sql += "(FNumber,FName,FGroupID,FDC,FHelperCode,FCurrencyID,FAdjustRate,FIsCash,FIsBank,FJournal,FContact,FQuantities,FUnitGroupID,FMeasureUnitID,FDetailID,FIsCashFlow,FAcnt,FInterest,FIsAcnt,FAcctint,FintRate,FLevel,FDetail,FParentID,FRootID,FIsBudget,FControlSystem,FName_Eng,FBank,FBankNO,FCFItemID,FSubCFItemID) "
                    sql += "  VALUES('" & Me.fnumber.Text.Trim.ToString & "','" & Me.C1TextBox1.Text.Trim & "','" & Me.C1TextBox7.Value & "',"
                    sql += Integer.Parse(ConvertFDC1(Me.ComboBox1.Text)) & ",'" & Me.C1TextBox25.Text.Trim.ToString & "','" & Me.CurrencyItem.SelectedValue & "' ," & ConvertTF(Me.CheckBox17.Checked) & "," & ConvertTF(Me.CheckBox1.Checked) & "," & ConvertTF(Me.CheckBox2.Checked) & ","
                    sql += ConvertTF(Me.CheckBox4.Checked) & "," & ConvertTF(Me.CheckBox7.Checked) & "," & ConvertTF(Me.CheckBox8.Checked) & ",'" & Me.C1TextBox2.Value & "','" & Me.fname.Value & "','" & InsertItem() & "',"
                    sql += ConvertTF(Me.CheckBox3.Checked) & ",0,0,0," & ConvertTF(Me.CheckBox6.Checked) & ",'" & Me.C1TextBox5.Text.Trim & "',1,1,0,0," & ConvertTF(Me.CheckBox5.Checked) & ",0,'"
                    sql += Me.C1TextBox6.Text.Trim.ToString & "','" & C1TextBox9.Text.Trim.ToString & "','" & C1TextBox10.Text.Trim.ToString & "','" & C1TextBox3.Value & "','" & IIf(C1DropDownControl4.Text = "应收应付系统", 1, 0) & "')"
                    DBOpen = New BLuser
                    DBOpen.sqlexecnon(sql, Me.CYSysInfo.ConnStrValue)


                    sql2 = ""
                    sql2 = "select * from t_account where fnumber='" & Me.fnumber.Text.Trim.ToString & "'"
                    'ds2.Clear()
                    ds2 = DBOpen.GetDataset(sql2, Me.CYSysInfo.ConnStrValue)

                    sql = ""
                    sql = "Update t_Account Set FRootID=" & ds2.Tables(0).Rows(0)("faccountid")
                    sql += " Where FAccountID=" & ds2.Tables(0).Rows(0)("faccountid")
                    DBOpen = New BLuser
                    DBOpen.sqlexecnon(sql, Me.CYSysInfo.ConnStrValue)
                    MsgBox("新增成功！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
                    AddNew()
                End If
            Else
                MsgBox("当前数据已经存在！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' 判断科目是否被使用
    ''' </summary>
    ''' <remarks></remarks>
    Private Function HaveUsed(ByVal FAccountID As Integer) As Boolean
        Dim dsd2 As New System.Data.DataSet
        Try
            Dim bln As Boolean = False
            sql = ""
            sql = " DECLARE	@return_value int "
            sql += "EXEC	@return_value = [dbo].[sp_ObjectInUsed]"
            sql += " @ObjectType = 0, @ObjectID = " & FAccountID.ToString
            sql += " SELECT	'Return Value' = @return_value "
            DBOpen = New BLuser
            dsd2 = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
            If dsd2.Tables(0).Rows(0)(0) = 1 Then
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
    ''' 更改上一级的detail
    ''' </summary>
    ''' <param name="fnumber"></param>
    ''' <remarks></remarks>
    Private Function ChangeDetail(ByVal fnumber As String) As Boolean
        Dim Result As DialogResult
        Dim fid As Integer
        sql1 = ""
        sql1 = "select * from t_account where fnumber='" & fnumber & "'"
        'ds1.Clear()
        ds1 = DBOpen.GetDataset(sql1, Me.CYSysInfo.ConnStrValue)
        fid = Integer.Parse(ds1.Tables(0).Rows(0)("faccountid").ToString)
        If Me.HaveUsed(fid) And ds1.Tables(0).Rows(0)("fdetail").ToString = True Then
            Result = MsgBox("该上级科目已经最明细科目且已经被使用，不能建立子科目。是否将上级科目业务转到新建的科目上", MsgBoxStyle.OkCancel, "提示")
            If Result = Windows.Forms.DialogResult.OK Then
                sql = ""
                sql = "update t_account set fdetail=0 where fnumber='" & fnumber & "'"
                DBOpen = New BLuser
                DBOpen.sqlexecnon(sql, Me.CYSysInfo.ConnStrValue)
                Return True
            Else
                Return False
                Exit Function
            End If
            'MsgBox("该上级科目已经最明细科目且已经被使用，不能建立子科目", MsgBoxStyle.OkOnly, "提示")
            'Return False

        Else
            sql = ""
            sql = "update t_account set fdetail=0 where fnumber='" & fnumber & "'"
            DBOpen = New BLuser
            DBOpen.sqlexecnon(sql, Me.CYSysInfo.ConnStrValue)
            Return True
        End If

    End Function
    ''' <summary>
    '''新增核算项目组别
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function InsertItem() As String
        Dim a(20) As String
        Dim fdetail As String
        Dim b, flag As Integer
        DBOpen = New BLuser
        fdetail = "0"
        For i = 0 To 20
            If Me.C1FlexGrid2.Item(i + 1, "FItemclassID") Is Nothing Then
                Exit For
            Else
                a(i) = "F" & Me.C1FlexGrid2.Item(i + 1, "FItemclassID")
                b = i
                flag = 1
            End If
        Next
        If flag = 0 Then
            Return fdetail
            Exit Function
        End If
        Try

            If b >= 0 Then
                sql = ""
                sql = "Select FDetailID From t_ItemDetail Where FDetailCount = " & b + 1
                For i = 0 To b
                    sql += "And " & a(i) & "=-1"

                Next
                'ds.Clear()
                ds = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
                If ds.Tables(0).Rows.Count <> 0 Then
                    Return ds.Tables(0).Rows(0)("FDetailID")
                Else
                    sql1 = ""
                    sql1 = "Insert Into t_ItemDetail(FDetailCount"
                    For i = 0 To b
                        sql1 += "," & a(i)

                    Next
                    sql1 += ") values (" & b + 1
                    For i = 0 To b
                        sql1 += ",-1"

                    Next
                    sql1 += ")"
                    DBOpen = New BLuser
                    ds1 = DBOpen.GetDataset(sql1, Me.CYSysInfo.ConnStrValue)

                    ds = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
                    fdetail = ds.Tables(0).Rows(0)("Fdetailid")
                    For i = 0 To b
                        sql2 = "Insert Into t_ItemDetailV(FDetailID,FItemClassID,FItemID)Values('"
                        sql2 += fdetail & "','" & Me.C1FlexGrid2.Item(i + 1, "FItemClassID") & "',-1)"
                        dbopen.sqlexecnon(sql2, Me.CYSysInfo.ConnStrValue)
                    Next
                    Return fdetail
                End If
            Else
                Return fdetail
            End If
            Return fdetail
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 转换
    ''' </summary>
    ''' <param name="TF"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConvertTF(ByVal TF As Boolean) As Integer
        If TF = True Then
            Return 1
        Else
            Return 0
        End If
    End Function

    ''' <summary>
    ''' 判断是否为子科目
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub subDetail()

    End Sub

    ''' <summary>
    ''' 编辑科目
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ModifyAccount()
        Dim count1 As New Integer
        Dim count2 As New Integer
        DBOpen = New BLuser
        sql = ""
        sql = "select * from t_account where faccountid=" & Me.faccountid
        'ds.Clear()
        ds = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
        Me.FCnumber = ds.Tables(0).Rows(0)("FNumber").ToString
        count1 = Len(ds.Tables(0).Rows(0)("fnumber").ToString) - Len(Replace(ds.Tables(0).Rows(0)("fnumber").ToString, ".", ""))
        count2 = Len(Me.fnumber.Text.Trim.ToString) - Len(Replace(Me.fnumber.Text.Trim.ToString, ".", ""))

        If count1 <> count2 Then '判断能否改变科目级别或上级科目
            MsgBox("不能改变科目级别或改变上级科目！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
        Else
            sql1 = ""
            sql1 = "SELECT fnumber FROM t_Account WHERE FNumber = '" & Me.fnumber.Text.Trim.ToString
            sql1 += "' and FAccountID<>" & Me.faccountid
            'ds1.Clear()
            ds1 = DBOpen.GetDataset(sql1, Me.CYSysInfo.ConnStrValue)

            If ds1.Tables(0).Rows.Count = 0 Then '判断科目代码是否相同
                '更新操作
                sql = ""
                sql = "update t_account set fnumber='" & Me.fnumber.Text.Trim.ToString & "' , fname='" & Me.C1TextBox1.Text.Trim.ToString & "', FDC=" & Integer.Parse(ConvertFDC1(Me.ComboBox1.Text))
                sql += ",FCurrencyID=" & Me.CurrencyItem.SelectedValue & ",FAdjustRate=" & ConvertTF(Me.CheckBox17.Checked) & ",FIsCash=" & ConvertTF(Me.CheckBox1.Checked) & ",FIsBank=" & ConvertTF(Me.CheckBox2.Checked)
                sql += ",FJournal=" & ConvertTF(Me.CheckBox4.Checked) & ",FContact=" & ConvertTF(Me.CheckBox7.Checked) & ",FQuantities=" & ConvertTF(Me.CheckBox8.Checked)
                sql += ",FUnitGroupID='" & Me.C1TextBox2.Value & "',FMeasureUnitID='" & Me.fname.Value & "',FDetailID='" & InsertItem() & "',FIsCashFlow=" & ConvertTF(Me.CheckBox3.Checked)
                sql += ",FAcctint= " & ConvertTF(Me.CheckBox6.Checked) & ",FintRate='" & Me.C1TextBox5.Text.Trim & "',FLastIntDate='',FTradeNum='',FControl=0,FViewMsg=0,FMessage='',FDelete=0,FControlSystem=0"
                sql += ",FHelperCode='" & Me.C1TextBox25.Text.Trim.ToString & "',FName_Eng='" & Me.C1TextBox6.Text.Trim.ToString & "',FBank='" & Me.C1TextBox9.Text.Trim.ToString & "',FBankNO='" & Me.C1TextBox10.Text.Trim.ToString
                sql += "',FCFItemID='" & Me.C1TextBox3.Value & "',FSubCFItemID='" & Me.C1TextBox4.Value & "'" & ",FGroupid='" & Me.C1TextBox7.Value
                sql += "'where faccountid=" & Me.faccountid
                dbopen.sqlexecnon(sql, Me.CYSysInfo.ConnStrValue)


                sql = ""
                sql = "UPDATE t_Account Set FNumber = {fn INSERT(FNumber, 1, " & Len(Me.FCnumber)
                sql += ", '" & Me.fnumber.Text.Trim.ToString
                sql += "')} WHERE FNumber = '" & Me.FCnumber & "' Or FNumber LIKE '" & Me.FCnumber & ".%'"
                DBOpen.sqlexecnon(sql, Me.CYSysInfo.ConnStrValue)

                sql = ""
                sql = "Update t_Account Set FFullName ='' Where FNumber Like'" & Me.fnumber.Text.Trim.ToString & ".%'"
                DBOpen.sqlexecnon(sql, Me.CYSysInfo.ConnStrValue)
                MsgBox("更新成功！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Else
                MsgBox("当前数据已经存在！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            End If
        End If
    End Sub

    ''' <summary>
    ''' 初始界面逻辑
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub init()
        'Me.C1TextBox7.Enabled = False
        'Me.Button6.Enabled = False
        'Me.CheckBox1.Enabled = False
        'Me.CheckBox17.Enabled = False
        ' Me.CheckBox3.Enabled = False
        'Me.CheckBox4.Enabled = False
        'Me.CheckBox5.Enabled = False
        'Me.CheckBox2.Enabled = False
        If Me.Text = "会计科目-新增" Then
            If Me.CheckBox8.Checked = False Then
                Me.C1TextBox2.Enabled = False
                Me.fname.Enabled = False
                Me.Button7.Enabled = False
                Me.Button4.Enabled = False
            Else
                Me.C1TextBox2.Enabled = True
                Me.fname.Enabled = True
                Me.Button7.Enabled = True
                Me.Button4.Enabled = True
            End If
        End If

        If Me.CheckBox6.Checked = True Then
            Me.C1TextBox5.Enabled = True
        Else
            Me.C1TextBox5.Enabled = False
        End If
        If Me.CheckBox2.Checked = True Then
            Me.C1TextBox9.Enabled = True
            Me.C1TextBox10.Enabled = True
        Else
            Me.C1TextBox9.Enabled = False
            Me.C1TextBox10.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' 绑定科目预算
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BindAccountBudget(ByVal fcurrencyid As String, ByVal FDC As String)
        '& (Me.CYSysInfo.CurrentYear - 1) & "
        '初始
        DBOpen = New BLuser
        For i = 1 To 12
            Me.C1FlexGrid3.Item(i, "序号") = i.ToString
            For j = 1 To 37
                Me.C1FlexGrid3.Item(i, j) = 0.0
            Next
        Next

        'sql = ""
        'sql = "SELECT FPeriod,FEndBalanceFor,FEndBalance From t_Balance  Where FYear = 2006 And faccountid = " & faccountid
        'sql += "AND FCurrencyID = (  select FCurrencyID from t_account where faccountid=" & faccountid
        'sql += " ) AND FDetailID=(select FDetailID from t_account where faccountid=" & faccountid & ")"

        sql = ""
        sql = "SELECT FPeriod,FEndBalanceFor,FEndBalance From t_Balance  Where FYear = " & Me.CYSysInfo.CurrentYear - 1 & " And faccountid = " & faccountid
        sql += "AND FCurrencyID = '" & fcurrencyid
        sql += "'and FDetailID=0" '(select FDetailID from t_account where faccountid=" & faccountid & ")"

        'ds.Clear()
        ds = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            For j = 1 To 12
                If Integer.Parse(Me.C1FlexGrid3.Item(j, "序号").ToString) = Integer.Parse(ds.Tables(0).Rows(i)("FPeriod").ToString) Then
                    Me.C1FlexGrid3.Item(j, "LastFEndBalanceFor") = (Double.Parse(ds.Tables(0).Rows(i)("FEndBalanceFor").ToString) * Integer.Parse(FDC)).ToString
                    Me.C1FlexGrid3.Item(j, "LastFEndBalance") = Double.Parse(ds.Tables(0).Rows(i)("FEndBalance")) * Integer.Parse(FDC)
                End If
            Next
        Next

        sql = ""
        sql = "SELECT FPeriod,FBudgetFor,FBudget,FMinBudgetFor,FMinBudget,  FBudgetDebitFor,FBudgetDebit,FBudgetCreditFor,FBudgetCredit,  "
        sql += "FSingMaxDebitFor,FSingMaxDebit,FSingMinDebitFor,FSingMinDebit,  FSingMaxCreditFor,FSingMaxCredit,FSingMinCreditFor,FSingMinCredit  From t_Budget  Where FYear=" & Me.CYSysInfo.CurrentYear - 1
        sql += " AND FAccountID=" & faccountid
        sql += "AND FCurrencyID ='" & fcurrencyid
        sql += "' AND FDetailID=0" '(select FDetailID from t_account where faccountid=" & faccountid & ")"
        'ds.Clear()
        ds = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            For j = 1 To 12
                If Integer.Parse(Me.C1FlexGrid3.Item(j, "序号").ToString) = Integer.Parse(ds.Tables(0).Rows(i)("FPeriod").ToString) Then
                    Me.C1FlexGrid3.Item(j, "LastFBudgetFor") = Double.Parse(ds.Tables(0).Rows(i)("FBudgetFor")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "LastFBudget") = Double.Parse(ds.Tables(0).Rows(i)("FBudget")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "LastFMinBudgetFor") = Double.Parse(ds.Tables(0).Rows(i)("FMinBudgetFor")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "LastFMinBudget") = Double.Parse(ds.Tables(0).Rows(i)("FMinBudget")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "LastFBudgetDebitFor") = Double.Parse(ds.Tables(0).Rows(i)("FBudgetDebitFor")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "LastFBudgetDebit") = Double.Parse(ds.Tables(0).Rows(i)("FBudgetDebit")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "LastFSingMaxDebitFor") = Double.Parse(ds.Tables(0).Rows(i)("FSingMaxDebitFor")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "LastFSingMaxDebit") = Double.Parse(ds.Tables(0).Rows(i)("FSingMaxDebit")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "LastFSingMinDebitFor") = Double.Parse(ds.Tables(0).Rows(i)("FSingMinDebitFor")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "LastFSingMinDebit") = Double.Parse(ds.Tables(0).Rows(i)("FSingMinDebit")) * Integer.Parse(FDC)
                End If
            Next
        Next


        sql = ""
        sql += "SELECT FPeriod,FEndBalanceFor,FEndBalance From t_Balance  Where FYear =" & Me.CYSysInfo.CurrentYear
        sql += " AND FAccountID=" & faccountid
        sql += "AND FCurrencyID = '" & fcurrencyid
        sql += "'AND FDetailID=0" '(select FDetailID from t_account where faccountid=" & faccountid & ")"
        'ds.Clear()
        ds = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            For j = 1 To 12
                If Integer.Parse(Me.C1FlexGrid3.Item(j, "序号").ToString) = Integer.Parse(ds.Tables(0).Rows(i)("FPeriod").ToString) Then
                    Me.C1FlexGrid3.Item(j, "FCEndBalanceFor") = Double.Parse(ds.Tables(0).Rows(i)("FEndBalanceFor")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "FCEndBalance") = Double.Parse(ds.Tables(0).Rows(i)("FEndBalance")) * Integer.Parse(FDC)
                End If
            Next
        Next

        sql = ""
        sql += "SELECT FPeriod,FDebitFor, FCreditFor, FDebit, FCredit From t_Balance  Where FYear =" & Me.CYSysInfo.CurrentYear - 1
        sql += " AND FAccountID=" & faccountid
        sql += "AND FCurrencyID = '" & fcurrencyid
        sql += "'AND FDetailID=0" '(select FDetailID from t_account where faccountid=" & faccountid & ")"
        'ds.Clear()
        ds = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            For j = 1 To 12
                If Integer.Parse(Me.C1FlexGrid3.Item(j, "序号").ToString) = Integer.Parse(ds.Tables(0).Rows(i)("FPeriod").ToString) Then
                    Me.C1FlexGrid3.Item(j, "LastFDebitFor") = Double.Parse(ds.Tables(0).Rows(i)("FDebitFor")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "LastFDebit") = Double.Parse(ds.Tables(0).Rows(i)("FDebit")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "LastFCreditFor") = Double.Parse(ds.Tables(0).Rows(i)("FCreditFor")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "LastFCredit") = Double.Parse(ds.Tables(0).Rows(i)("FCredit")) * Integer.Parse(FDC)
                End If
            Next
        Next

        sql = ""
        sql += "Select v.FPeriod,Sum(e.FAmountFor*e.FDC) as FDebitFor , Sum(e.FAmount*e.FDC) as FDebit ,  Sum(e.FAmountFor*(1-e.FDC)) as FCreditFor , Sum(e.FAmount*(1-e.FDC)) as "
        sql += "FCredit  From t_Voucher v , t_VoucherEntry e , t_Account a  Where v.FVoucherID = e.FVoucherID  And e.FAccountID = a.FAccountID  And v.FYear =" & Me.CYSysInfo.CurrentYear
        sql += "And e.FAccountID = " & faccountid
        sql += "AND e.FCurrencyID= '" & fcurrencyid
        sql += "'Group by v.FPeriod "

        ds = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            For j = 1 To 12
                If Integer.Parse(Me.C1FlexGrid3.Item(j, "序号").ToString) = Integer.Parse(ds.Tables(0).Rows(i)("FPeriod").ToString) Then
                    Me.C1FlexGrid3.Item(j, "FCDebitFor") = Double.Parse(ds.Tables(0).Rows(i)("FDebitFor")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "FCDebit") = Double.Parse(ds.Tables(0).Rows(i)("FDebit")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "FCCreditFor") = Double.Parse(ds.Tables(0).Rows(i)("FCreditFor")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "FCCredit") = Double.Parse(ds.Tables(0).Rows(i)("FCredit")) * Integer.Parse(FDC)
                End If
            Next
        Next


        sql = ""
        sql = "SELECT FPeriod,FBudgetFor,FBudget,FMinBudgetFor,FMinBudget,  FBudgetDebitFor,FBudgetDebit,FBudgetCreditFor,FBudgetCredit,  "
        sql += "FSingMaxDebitFor,FSingMaxDebit,FSingMinDebitFor,FSingMinDebit,  FSingMaxCreditFor,FSingMaxCredit,FSingMinCreditFor,FSingMinCredit  From t_Budget  Where FYear=" & Me.CYSysInfo.CurrentYear
        sql += " AND FAccountID=" & faccountid
        sql += "AND FCurrencyID ='" & fcurrencyid
        sql += "' AND FDetailID=0" '(select FDetailID from t_account where faccountid=" & faccountid & ")"

        ds = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            For j = 1 To 12
                If Integer.Parse(Me.C1FlexGrid3.Item(j, "序号").ToString) = Integer.Parse(ds.Tables(0).Rows(i)("FPeriod").ToString) Then
                    Me.C1FlexGrid3.Item(j, "FBudgetFor") = Double.Parse(ds.Tables(0).Rows(i)("FBudgetFor")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "FBudget") = Double.Parse(ds.Tables(0).Rows(i)("FBudget")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "FBudgetDebitFor") = Double.Parse(ds.Tables(0).Rows(i)("FBudgetDebitFor")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "FBudgetDebit") = Double.Parse(ds.Tables(0).Rows(i)("FBudgetDebit")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "FBudgetCreditFor") = Double.Parse(ds.Tables(0).Rows(i)("FBudgetCreditFor")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "FBudgetCredit") = Double.Parse(ds.Tables(0).Rows(i)("FBudgetCredit")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "FSingMaxDebitFor") = Double.Parse(ds.Tables(0).Rows(i)("FSingMaxDebitFor")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "FSingMaxDebit") = Double.Parse(ds.Tables(0).Rows(i)("FSingMaxDebit")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "FSingMaxCreditFor") = Double.Parse(ds.Tables(0).Rows(i)("FSingMaxCreditFor")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "FSingMaxCredit") = Double.Parse(ds.Tables(0).Rows(i)("FSingMaxCredit")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "FSingMinDebitFor") = Double.Parse(ds.Tables(0).Rows(i)("FSingMinDebitFor")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "FSingMinDebit") = Double.Parse(ds.Tables(0).Rows(i)("FSingMinDebit")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "FSingMinCreditFor") = Double.Parse(ds.Tables(0).Rows(i)("FSingMinCreditFor")) * Integer.Parse(FDC)
                    Me.C1FlexGrid3.Item(j, "FSingMinCredit") = Double.Parse(ds.Tables(0).Rows(i)("FSingMinCredit")) * Integer.Parse(FDC)
                End If
            Next
        Next

    End Sub
    ''' <summary>
    ''' 借贷跟1或-1进行转换
    ''' </summary>
    ''' <param name="FDC"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConvertFDC(ByVal FDC As String) As String
        Dim FDCName As String
        If FDC = 1 Then
            FDCName = "借"
        Else
            FDCName = "贷"
        End If
        Return FDCName


    End Function
    Private Function ConvertFDC1(ByVal FDC As String) As String
        Dim FDCName As String
        If FDC = "借" Then
            FDCName = "1"
        Else
            FDCName = "-1"
        End If
        Return FDCName
    End Function
    Private Enum Status As Integer
        新增 = 0
        修改 = 1
        查看 = 2
    End Enum
    Private Function toolBarControlStatus(ByVal s As Status)
        Select Case s
            Case Status.新增
                Me.copy.Visible = False
                '  Me.Save.Enabled = False
                Me.UpSelect.Visible = False
                Me.ToolStripButton2.Visible = False
                Me.ToolStripButton3.Visible = False
                Me.DownSelect.Visible = False
                Me.Out.Visible = True
            Case Status.修改
                Me.copy.Visible = True
                '  Me.Save.Enabled = False
                Me.UpSelect.Visible = True
                Me.ToolStripButton2.Visible = True
                Me.ToolStripButton3.Visible = True
                Me.DownSelect.Visible = True
                Me.Out.Visible = True
        End Select
    End Function


    Private Sub Frmaccount_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dsd2 As New System.Data.DataSet
        DBOpen = New BLuser

        '''''
        '''''绑定币别
        '''''
        sql = ""
        sql = "select FCurrencyID, case when FName ='*' then '所有币别'  when Fname ='人民币' then '不核算' else fname end as Fname from t_currency"

        dsd2 = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
        Me.CurrencyItem.DataSource = dsd2.Tables(0)
        Me.CurrencyItem.DisplayMember = "FName"
        Me.CurrencyItem.ValueMember = "FCurrencyID"
        Me.CurrencyItem.Splits(0).DisplayColumns(0).Visible = False
        Me.CurrencyItem.ColumnHeaders = False
        Me.CurrencyItem.SelectedIndex = 0
        '进行判断
        If Integer.Parse(faccountid) > 0 Then
            Me.Text = "会计科目-修改"
            bind(Integer.Parse(faccountid), Integer.Parse(frank))
            toolBarControlStatus(Status.修改)
            init()

        Else
            Me.Text = "会计科目-新增"
            Me.C1DockingTabPage3.Enabled = False
            toolBarControlStatus(Status.新增)
            init()

        End If
    End Sub

    Private Sub Out_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Out.Click
        Me.Close()
        Me.frm.refesh()
    End Sub

    Private Sub CheckBox8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox8.CheckedChanged
        If Me.CheckBox8.Checked = False Then
            Me.C1TextBox2.Enabled = False
            Me.fname.Enabled = False
            Me.Button7.Enabled = False
            Me.Button4.Enabled = False
        Else
            Me.C1TextBox2.Enabled = True
            Me.fname.Enabled = True
            Me.Button7.Enabled = True
            Me.Button4.Enabled = True

        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox6.CheckedChanged
        If Me.CheckBox6.Checked = True Then
            Me.C1TextBox5.Enabled = True
        Else
            Me.C1TextBox5.Enabled = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            CheckBox4.Checked = True
            CheckBox2.Checked = False
            CheckBox3.Checked = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            CheckBox4.Checked = True
            CheckBox1.Checked = False
            CheckBox3.Checked = False
            Me.C1TextBox9.Enabled = True
            Me.C1TextBox10.Enabled = True
        Else
            Me.C1TextBox9.Text = ""
            Me.C1TextBox10.Text = ""

            Me.C1TextBox9.Enabled = False
            Me.C1TextBox10.Enabled = False

        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            CheckBox1.Checked = False
            CheckBox2.Checked = False

        End If
    End Sub

    Private Sub C1TextBox2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1TextBox2.DoubleClick

        Dim _fbasetemp As New fbasetemp
        _fbasetemp.frmact = Me
        _fbasetemp.tablename = "计量单位组"
        _fbasetemp.ShowDialog()

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim _fbasetemp As New fbasetemp
        _fbasetemp.frmact = Me
        _fbasetemp.tablename = "计量单位组"
        _fbasetemp.ShowDialog()
    End Sub

    Private Sub C1TextBox2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1TextBox2.TextChanged
        Me.fname.Text = ""
    End Sub

    Private Sub fname_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles fname.DoubleClick
        If C1TextBox2.Text = "" Then
            MsgBox("请先输入计量单位组")
        Else
            Dim _fbasetemp As New fbasetemp
            _fbasetemp.frmact = Me
            _fbasetemp.tablename = "计量单位"
            _fbasetemp.rtname = C1TextBox2.Value
            _fbasetemp.ShowDialog()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If C1TextBox2.Text = "" Then
            MsgBox("请先输入计量单位组")
        Else
            Dim _fbasetemp As New fbasetemp
            _fbasetemp.frmact = Me
            _fbasetemp.tablename = "计量单位"
            _fbasetemp.rtname = C1TextBox2.Value
            _fbasetemp.ShowDialog()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim _fbasetemp As New fbasetemp
        _fbasetemp.frmact = Me
        _fbasetemp.tablename = "核算项目"
        _fbasetemp.ShowDialog()
    End Sub

    Private Sub C1TextBox7_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1TextBox7.DoubleClick
        Dim _fbasetemp As New fbasetemp
        _fbasetemp.frmact = Me
        _fbasetemp.tablename = "科目类别"
        _fbasetemp.ShowDialog()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim _fbasetemp As New fbasetemp
        _fbasetemp.frmact = Me
        _fbasetemp.tablename = "科目类别"
        _fbasetemp.ShowDialog()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If gridindex <= 1 Then
            MsgBox("这是第一条记录！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
        Else
            gridindex = gridindex - 1
            Me.faccountid = frm.C1FlexGrid.Rows(gridindex)("编码")
            Me.Cursor = Cursors.WaitCursor

            bind(faccountid, frank)
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If gridindex >= frm.C1FlexGrid.Rows.Count - 1 Then
            MsgBox("这是最后一条记录！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
        Else
            gridindex = gridindex + 1
            Me.faccountid = frm.C1FlexGrid.Rows(gridindex)("编码")
            Me.Cursor = Cursors.WaitCursor
            bind(faccountid, frank)
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub UpSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpSelect.Click
        gridindex = 1
        Me.faccountid = frm.C1FlexGrid.Rows(gridindex)("编码")
        Me.Cursor = Cursors.WaitCursor
        bind(faccountid, frank)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DownSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownSelect.Click
        If gridindex >= frm.C1FlexGrid.Rows.Count - 1 Then
            MsgBox("这是最后一条记录！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
        Else
            gridindex = frm.C1FlexGrid.Rows.Count - 1
            Me.faccountid = frm.C1FlexGrid.Rows(gridindex)("编码")
            Me.Cursor = Cursors.WaitCursor
            bind(faccountid, frank)
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub C1DockingTabPage3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DockingTabPage3.GotFocus
        Me.Cursor = Cursors.WaitCursor

        If Me.Text = "会计科目-修改" Then
            BindAccountBudget(Me.C1Combo1.SelectedValue, Me.FDC)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Me.C1FlexGrid2.Rows.Remove(Me.C1FlexGrid2.Row)
    End Sub

    'Private Sub fnumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles fnumber.KeyDown
    '    If (e.KeyCode = Keys.Enter) Then
    '        SendKeys.Send("{TAB} ")
    '    End If
    'End Sub



    'Private Sub fnumber_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles fnumber.LostFocus
    '    Me.Cursor = Cursors.WaitCursor

    '    DBOpen = New BLuser
    '    If Me.fnumber.Text.Contains(".") = True And Me.Text = "会计科目-新增" Then
    '        Me.FLnumber = Me.fnumber.Text.Substring(0, Me.fnumber.Text.LastIndexOf("."))
    '        sql = ""
    '        sql = "select * from t_account where fnumber= '" & Me.FLnumber.ToString & "'"
    '        Me.FLnumber = Me.fnumber.Text.Trim
    '        DBOpen = New BLuser
    '        ds = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
    '        If ds.Tables(0).Rows.Count > 0 Then
    '            faccountid = ds.Tables(0).Rows(0)("faccountid")
    '            bind(faccountid, frank)
    '        End If
    '        Me.fnumber.Text = Me.FLnumber
    '        Me.C1TextBox1.Text = ""
    '        Me.C1TextBox26.Text = ""
    '    ElseIf Me.Text = "会计科目-修改" Then

    '    End If
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub fnumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fnumber.TextChanged
    '    Me.Cursor = Cursors.WaitCursor

    '    DBOpen = New BLuser
    '    If Me.fnumber.Text.Contains(".") = True And Me.Text = "会计科目-新增" Then
    '        Me.FLnumber = Me.fnumber.Text.Substring(0, Me.fnumber.Text.LastIndexOf("."))
    '        sql = ""
    '        sql = "select * from t_account where fnumber= '" & Me.FLnumber.ToString & "'"
    '        Me.FLnumber = Me.fnumber.Text.Trim
    '        DBOpen = New BLuser
    '        ds = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
    '        If ds.Tables(0).Rows.Count > 0 Then
    '            faccountid = ds.Tables(0).Rows(0)("faccountid")
    '            bind(faccountid, frank)
    '        End If
    '        'Me.fnumber.Text = Me.FLnumber
    '        'Me.C1TextBox1.Text = ""
    '        'Me.C1TextBox26.Text = ""
    '    ElseIf Me.Text = "会计科目-修改" Then

    '    End If
    '    Me.Cursor = Cursors.Default
    'End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Me.Cursor = Cursors.WaitCursor
        dstable = Loaditamdate("9")
        If dstable Is Nothing = False Then
            C1TextBox3.Text = dstable.Rows(0)("FNumber")
            C1TextBox3.Value = dstable.Rows(0)("fitemid")
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.Cursor = Cursors.WaitCursor
        dstable = Loaditamdate("9")
        If dstable Is Nothing = False Then
            C1TextBox4.Text = dstable.Rows(0)("FNumber")
            C1TextBox4.Value = dstable.Rows(0)("fitemid")
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save.Click

        Me.Cursor = Cursors.WaitCursor
        If Me.Text = "会计科目-新增" Then
            Try
                SaveAccount()

            Catch ex As Exception
                Throw ex
            End Try
        Else
            '权限
            'If _WSFuncRight.IsHaveFuncRight(Me.CYUserInfo.FID, Me.CYUserInfo.FUGroupID, Me.CYSysInfo.DBID, "BD0101005", FuncType.修改) = True Then
            Try
                ModifyAccount()
            Catch ex As Exception
                Throw ex
            End Try
            '    Else
            '    MsgBox("没有修改的权限，不能进行修改！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            'End If

        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles copy.Click
        Me.Text = "会计科目-新增"
        toolBarControlStatus(Status.新增)
        Me.CheckBox2.Enabled = True
        Me.C1TextBox9.Enabled = True
        Me.C1TextBox10.Enabled = True
        Me.CheckBox1.Enabled = True
        Me.CheckBox3.Enabled = True
        Me.CheckBox4.Enabled = True
        Me.CheckBox7.Enabled = True
        Me.btnSearch.Enabled = True
        Me.Button13.Enabled = True
    End Sub

    Private Sub C1Combo1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1Combo1.TextChanged
        Me.Cursor = Cursors.WaitCursor
        If Me.Text = "会计科目-修改" Then
            BindAccountBudget(Me.C1Combo1.SelectedValue, Me.FDC)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub C1TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles C1TextBox1.KeyDown, fname.KeyDown, CurrencyItem.KeyDown, C1TextBox9.KeyDown, C1TextBox8.KeyDown, C1TextBox7.KeyDown, C1TextBox6.KeyDown, C1TextBox26.KeyDown, C1TextBox25.KeyDown, C1TextBox2.KeyDown, C1TextBox10.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{TAB} ")
        End If
    End Sub

    Private Sub fnumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles fnumber.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{TAB} ")
        End If
    End Sub

    Private Sub fnumber_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles fnumber.Validated
        Me.Cursor = Cursors.WaitCursor

        DBOpen = New BLuser
        If Me.fnumber.Text.Contains(".") = True And Me.Text = "会计科目-新增" Then
            Me.FLnumber = Me.fnumber.Text.Substring(0, Me.fnumber.Text.LastIndexOf("."))
            sql = ""
            sql = "select * from t_account where fnumber= '" & Me.FLnumber.ToString & "'"
            Me.FLnumber = Me.fnumber.Text.Trim
            DBOpen = New BLuser
            ds = DBOpen.GetDataset(sql, Me.CYSysInfo.ConnStrValue)
            If ds.Tables(0).Rows.Count > 0 Then
                faccountid = ds.Tables(0).Rows(0)("faccountid")
                bind(faccountid, frank)
            End If
            Me.fnumber.Text = Me.FLnumber
            Me.C1TextBox1.Text = ""
            Me.C1TextBox26.Text = ""
        ElseIf Me.Text = "会计科目-修改" Then

        End If
        Me.Cursor = Cursors.Default
    End Sub
End Class