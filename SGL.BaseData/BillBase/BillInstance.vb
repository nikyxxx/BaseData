Imports PublicSharedResource

Public Class BillInstance
    Private Shared GetDataSet As New SGL.BLL.BLuser

    Public Shared Function AuditBill(ByVal _FInterIDName As String, ByVal _FCheckerName As String, ByVal _FCheckDate As String, ByVal _tableName As String, ByVal m_InterID As Integer, ByVal connString As String, ByVal _userID As Integer) As Boolean
        Dim Sql As String
        Dim dt As DataSet
        Try
            'Sql = "select isnull(FStatus,0) as FStatus from " + _tableName + " where " + _FInterIDName + "=" + m_InterID.ToString()
            'dt = GetDataSet.GetDataset(Sql, connString)
            'If dt.Tables(0).Rows.Count > 0 Then
            '    If dt.Tables(0).Rows(0)("FStatus") > 0 Then
            '        MsgBox("已审核单据不能再次审核！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            '        Return False
            '    End If
            'Else
            '    Return False
            'End If
            Sql = "update " + _tableName + " set FStatus=1," + _FCheckerName + "=" + _userID.ToString() + "," + _FCheckDate + "=CONVERT(VARCHAR(20),GETDATE(),111) where " + _FInterIDName + "=" + m_InterID.ToString()
            GetDataSet.GetDataset(Sql, connString)

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function AuditStatusCheck(ByVal _FInterIDName As String, ByVal _tableName As String, ByVal m_InterID As Integer, ByVal connString As String) As Boolean
        Dim Sql As String
        Dim dt As DataSet
        If m_InterID <= 0 Then
            MsgBox("请先保存单据！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Return False
        End If
        Try
            Sql = "select isnull(FStatus,0) as FStatus from " + _tableName + " where " + _FInterIDName + "=" + m_InterID.ToString()
            dt = GetDataSet.GetDataset(Sql, connString)
            If dt.Tables(0).Rows.Count > 0 Then
                If dt.Tables(0).Rows(0)("FStatus") > 0 Then
                    MsgBox("已审核单据不能再次审核！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
                    Return False
                Else
                    Return True
                End If
            Else
                Return False
            End If
            
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function RejectBill(ByVal _FInterIDName As String, ByVal _FCheckerName As String, ByVal _FCheckDate As String, ByVal _tableName As String, ByVal m_InterID As Integer, ByVal connString As String) As Boolean
        Dim Sql As String
        Dim dt As DataSet
        Try
            Sql = "update " + _tableName + " set FStatus=0," + _FCheckerName + "=NULL," + _FCheckDate + "=NULL where " + _FInterIDName + "=" + m_InterID.ToString()
            GetDataSet.GetDataset(Sql, connString)
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function RejectStatusCheck(ByVal _FInterIDName As String, ByVal _tableName As String, ByVal m_InterID As Integer, ByVal connString As String) As Boolean
        Dim Sql As String
        Dim dt As DataSet
        If m_InterID <= 0 Then
            MsgBox("请先保存单据！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Return False
        End If
        Try
            Sql = "select isnull(FStatus,0) as FStatus from " + _tableName + " where " + _FInterIDName + "=" + m_InterID.ToString()
            dt = GetDataSet.GetDataset(Sql, connString)
            If dt.Tables(0).Rows.Count > 0 Then
                If dt.Tables(0).Rows(0)("FStatus") > 0 Then
                    Return True
                Else
                    MsgBox("未审核单据不能反审核！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
                    Return False
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DeleteCheck(ByVal _FInterIDName As String, ByVal _tableName As String, ByVal m_InterID As Integer, ByVal connString As String) As Boolean
        Dim Sql As String
        Dim dt As DataSet
        If m_InterID <= 0 Then
            MsgBox("请先保存单据！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
            Return False
        End If
        Try
            Sql = "select isnull(FStatus,0) as FStatus from " + _tableName + " where " + _FInterIDName + "=" + m_InterID.ToString()
            dt = GetDataSet.GetDataset(Sql, connString)
            If dt.Tables(0).Rows.Count > 0 Then
                If dt.Tables(0).Rows(0)("FStatus") > 0 Then
                    MsgBox("已审核单据不能删除！", MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
                    Return False
                Else
                    Return True
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DeleteBill(ByVal _FInterIDName As String, ByVal _tableName As String, ByVal _EntryTable As String, ByVal m_InterID As Integer, ByVal connString As String) As Boolean
        Dim Sql As String
        Dim dt As DataSet
        Try
            Sql = "DELETE " + _tableName + " where " + _FInterIDName + "=" + m_InterID.ToString()
            Sql += " DELETE " + _EntryTable + " where " + _FInterIDName + "=" + m_InterID.ToString()
            GetDataSet.GetDataset(Sql, connString)

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function isHaveSameBillNumber(ByVal _tableName As String, ByVal _TranTypeName As String, ByVal _FNumberName As String, ByVal _billNo As String, ByVal _TranType As Integer, ByVal connString As String) As Boolean
        Dim Sql As String
        Dim dt As DataSet
        Try
            Sql = "SELECT 1 FROM " + _tableName + " WHERE " + _TranTypeName + "=" + _TranType.ToString() + " and " + _FNumberName + " = '" + _billNo + "'"
            dt = GetDataSet.GetDataset(Sql, connString)
            If dt.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
            Return False
        Catch ex As Exception
            myShowMsg(ex.Message.ToString())
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 自定义弹出框
    ''' </summary>
    ''' <param name="_msg">弹出内容</param>
    ''' <remarks></remarks>
    Public Shared Sub myShowMsg(ByVal _msg As String)
        MsgBox(_msg, MsgBoxStyle.Information, clsGlobal.M_STR_HINT)
    End Sub

    Public Shared Sub MenuBar_SetEnable_True(ByVal toolbar As System.Windows.Forms.ToolStrip, ByVal _menuList As String)
        Try
            For Each _str As String In _menuList.Split(",")
                Dim finds() As ToolStripItem = toolbar.Items.Find(_str, True)
                If finds.Length > 0 Then
                    finds(0).Enabled = True
                End If
            Next
        Catch ex As Exception
            myShowMsg(ex.Message.ToString())
        End Try
    End Sub

    Public Shared Sub MenuBar_SetEnable_True(ByVal toolbar As System.Windows.Forms.ToolStrip, ByVal _menuList As String, ByVal _menuInRightsList As DataTable, ByVal _isAdmin As Integer)
        MenuBar_SetEnable_True(toolbar, _menuList)

        If _isAdmin = 1 Then Exit Sub

        For Each dr As DataRow In _menuInRightsList.Rows
            MenuBar_SetEnable_False(toolbar, dr("FMenuID").ToString())
        Next
    End Sub


    Public Shared Sub MenuBar_SetEnable_False(ByVal toolbar As System.Windows.Forms.ToolStrip, ByVal _menuList As String)
        Try
            For Each _str As String In _menuList.Split(",")
                Dim finds() As ToolStripItem = toolbar.Items.Find(_str, True)
                If finds.Length > 0 Then
                    finds(0).Enabled = False
                End If
            Next
        Catch ex As Exception
            myShowMsg(ex.Message.ToString())
        End Try
    End Sub

    Public Shared Sub CallFom(ByVal _CYUserInfo As clsUserInfo, ByVal _CYSysInfo As clsSysInfo, ByVal strAllName As String, ByVal _objFormPara As Hashtable)
        Dim strLocation As String = ""
        Dim strType As String               ' 窗体类名
        Dim strNamespace As String
        Dim intLen As Integer
        intLen = strAllName.Split(".").Length
        strNamespace = PublicSharedResource.PublicSharedFunctions.GetSubString(strAllName, 1, ".") & "." & PublicSharedResource.PublicSharedFunctions.GetSubString(strAllName, 2, ".")
        strType = strNamespace & "." & PublicSharedResource.PublicSharedFunctions.GetSubString(strAllName, intLen, ".")

#If DEBUG Then
        Dim strPath As String = System.IO.Directory.GetParent(Windows.Forms.Application.StartupPath).FullName
        strPath = System.IO.Directory.GetParent(strPath).FullName
        strPath = System.IO.Directory.GetParent(strPath).FullName
        strLocation = strPath & "\" & strNamespace & "\bin\Debug\" & strNamespace & ".dll"
#Else
        strLocation = Windows.Forms.Application.StartupPath & "\" & strNamespace & ".dll"
#End If
        'Dim objRun As New clsDynamic(strLocation, strFormID, strType)
        Dim asmContainingForm As System.Reflection.Assembly = System.Reflection.Assembly.LoadFrom(strLocation)
        Dim typToLoad As Type = asmContainingForm.GetType(strType)

        Dim objGenericInstance As frmBase
        objGenericInstance = Activator.CreateInstance(typToLoad)

        Dim objFrm As frmBase = CType(objGenericInstance, frmBase)
        objFrm.CYUserInfo = _CYUserInfo
        objFrm.CYSysInfo = _CYSysInfo
        objFrm.objFormPara = _objFormPara
        objFrm.ShowDialog()
    End Sub

    Public Shared Function BilledDictionary(ByVal _trantype As Integer, ByVal _connstr As String) As Dictionary(Of String, String)
        Dim Sql As String
        Dim dt As DataSet
        Dim _dic = New Dictionary(Of String, String)

        Sql = "select * from t_cs_Main where fid=" + _trantype.ToString()
        dt = GetDataSet.GetDataset(Sql, _connstr)

        If dt.Tables(0).Rows.Count > 0 Then
            _dic.Add(FieldsEnum.内码, dt.Tables(0).Rows(0)(FieldsEnum.内码))
            _dic.Add(FieldsEnum.单据编号, dt.Tables(0).Rows(0)(FieldsEnum.单据编号))
            _dic.Add(FieldsEnum.单据类型, dt.Tables(0).Rows(0)(FieldsEnum.单据类型))
            _dic.Add(FieldsEnum.单据日期, dt.Tables(0).Rows(0)(FieldsEnum.单据日期))
            _dic.Add(FieldsEnum.审核人, dt.Tables(0).Rows(0)(FieldsEnum.审核人))
            _dic.Add(FieldsEnum.审核日期, dt.Tables(0).Rows(0)(FieldsEnum.审核日期))
            _dic.Add(FieldsEnum.制单人, dt.Tables(0).Rows(0)(FieldsEnum.制单人))
            _dic.Add(FieldsEnum.制单日期, dt.Tables(0).Rows(0)(FieldsEnum.制单日期))
            _dic.Add(FieldsEnum.红蓝字, dt.Tables(0).Rows(0)(FieldsEnum.红蓝字))
        End If

        Sql = "select * from t_sgl_billtable where fid=" + _trantype.ToString()
        dt = Nothing
        dt = GetDataSet.GetDataset(Sql, PublicSharedResource.PublicSharedFunctions.consglstr)
        If dt.Tables(0).Rows.Count > 0 Then
            _dic.Add(TableEnum.主表, dt.Tables(0).Rows(0)("ft1"))
            _dic.Add(TableEnum.子表1, dt.Tables(0).Rows(0)("ft2"))
        End If

        Return _dic
    End Function

    Public Enum BillStatusEnum As Integer
        新增 = 1
        审核 = 2
        复制 = 3
        关闭 = 4
        查看 = 5
        编辑 = 6
        变更 = 7
        确认 = 8
        启用 = 9
    End Enum
End Class


