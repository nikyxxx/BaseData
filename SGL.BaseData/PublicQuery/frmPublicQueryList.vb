Imports PublicSharedResource

Public Class frmPublicQueryList
    Inherits frmQueryBase

#Region "成员变量声明"

    Private m_dsPublicDataInfo As New DataSet
    Private getDataSet As BLL.BLuser = New BLL.BLuser

    Public m_title As String = "公共资料"
#End Region

#Region "用户自定义函数"

    Private Sub GetPublicDataList(ByVal strSql As String)
        Try

            m_dsPublicDataInfo = getDataSet.GetDataset(strSql, DBConnValue)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub grdPublicDataBind(ByVal strSql As String)
        Try
            GetPublicDataList(strSql)
            If m_dsPublicDataInfo.Tables.Count > 0 Then
                Me.CtgrdSubMessage.DataSource = m_dsPublicDataInfo.Tables(0)
                Me.CtgrdSubMessage.Columns(0).DataField = "FItemID"
                Me.CtgrdSubMessage.Columns(1).DataField = "FNumber"
                Me.CtgrdSubMessage.Columns(2).DataField = "FName"
                Me.CtgrdSubMessage.Columns(0).Caption = "公共资料内码"
                Me.CtgrdSubMessage.Columns(1).Caption = "公共资料代码"
                Me.CtgrdSubMessage.Columns(2).Caption = "公共资料名称"
                Me.CtgrdSubMessage.Splits(0).DisplayColumns(0).Visible = False
                Me.CtgrdSubMessage.Splits(0).DisplayColumns(1).Visible = True
                Me.CtgrdSubMessage.Splits(0).DisplayColumns(2).Visible = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function CreateTable() As DataTable
        Try
            Dim colname(3) As String
            Dim coltype(3) As String
            colname.SetValue("FItemID", 0)
            colname.SetValue("FNumber", 1)
            colname.SetValue("FName", 2)

            coltype.SetValue("System.String", 0)
            coltype.SetValue("System.String", 1)
            coltype.SetValue("System.String", 2)
            Return PublicSharedFunctions.CreateDataTable(colname, coltype)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function CreateQuerySql() As String
        Try
            'Dim strSql As String = "select "
            'strSql += Me.hasTable.Item("FItemID").ToString() & " FItemID," & Me.hasTable.Item("FNumber").ToString() & _
            '            " FNumber," & Me.hasTable.Item("FName").ToString() & " FName" & " from " & _
            '            Me.hasTable.Item("FTableName").ToString() & " where 1=1 " & Me.QuerySql
            'Return strSql

            Dim strSql As String
            strSql = Me.QuerySql
            Dim _query As String = "where 1=1"
            If txtNumber.Text.Trim() <> "" Then
                _query = _query + " and " + Me.hasTable.Item("FNumber").ToString() + " like '%" + txtNumber.Text.Trim() + "%'"
            End If
            If txtName.Text.Trim() <> "" Then
                _query = _query + " and " + Me.hasTable.Item("FName").ToString() + " like '%" + txtName.Text.Trim() + "%'"
            End If
            strSql = Replace(strSql, "where 1=1", _query)
            Return strSql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region


    Private Sub frmQuerySubMes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Dim dt As DataTable
            Dim dr As DataRow
            If Me.RtnDataTable Is Nothing Then
                dt = CreateTable()
                dr = dt.NewRow()
                dr(0) = ""
                dr(1) = ""
                dr(2) = ""
                dt.Rows.Add(dr)
                Me.RtnDataTable = dt
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub frmQuerySubMes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor

        Try
            If Me.AllowMultiLine = True Then
                Me.CtgrdSubMessage.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Extended
            Else
                Me.CtgrdSubMessage.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            End If

            Me.lblTitle.Text = m_title

            grdPublicDataBind(CreateQuerySql())
        Catch ex As Exception
            Throw ex
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CtgrdSubMessage_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtgrdSubMessage.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        Dim intRow As Integer
        Dim dt As New DataTable
        Try
            intRow = Me.CtgrdSubMessage.Row
            If Me.m_dsPublicDataInfo.Tables.Count > 0 Then
                dt = Me.m_dsPublicDataInfo.Tables(0).Clone()
                If Me.m_dsPublicDataInfo.Tables(0).Rows.Count > 0 Then
                    dt.BeginLoadData()
                    dt.LoadDataRow(Me.m_dsPublicDataInfo.Tables(0).Rows.Item(intRow).ItemArray(), True)
                    dt.EndLoadData()
                    If dt.Rows.Count > 0 Then
                        Me.RtnDataTable = dt
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CtgrdSubMessage_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CtgrdSubMessage.KeyDown
        Me.Cursor = Cursors.WaitCursor

        Dim dt As New DataTable
        Dim intRow As Integer
        Dim i As Integer
        Try
            If e.KeyData = Keys.Enter Then
                If m_dsPublicDataInfo.Tables.Count > 0 Then
                    dt = Me.m_dsPublicDataInfo.Tables(0).Clone()
                    dt.BeginLoadData()
                    For i = 0 To Me.CtgrdSubMessage.SelectedRows.Count - 1
                        intRow = Me.CtgrdSubMessage.SelectedRows.Item(i)
                        dt.LoadDataRow(Me.m_dsPublicDataInfo.Tables(0).Rows.Item(intRow).ItemArray(), True)
                    Next
                    dt.EndLoadData()
                    If dt.Rows.Count > 0 Then
                        Me.RtnDataTable = dt
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If
                End If
            End If

            '按下ＥＳＣ
            If e.KeyData = Keys.Escape Then
                Me.Close()
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        grdPublicDataBind(CreateQuerySql())
    End Sub

    Private Sub txtNumber_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumber.KeyDown, txtName.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdPublicDataBind(CreateQuerySql())
        End If

    End Sub
End Class