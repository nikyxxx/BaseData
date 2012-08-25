Imports SGL.BLL
Imports PublicSharedResource
Public Class FrmMoreItem
    Inherits frmBase
#Region "成员变量声明"
    Dim getdate As New SGL.BLL.BLuser
    Dim BillDate As New SGL.BLL.BLManagerOldBillData
    Dim Getformat As New SGL.BLL.BLformat
    Dim GetDataSet As New SGL.BLL.BLuser
    Public RtnDataTable As New DataSet
    Public constr As String
    Private MCLdanhao As String
    Private MCLneima As String
    Public Property danhao() As String
        Get
            Return MCLdanhao
        End Get
        Set(ByVal value As String)
            MCLdanhao = value
        End Set
    End Property
    Public Property neima() As String
        Get
            Return MCLneima
        End Get
        Set(ByVal value As String)
            MCLneima = value
        End Set
    End Property
#End Region
    Private Sub FAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim strSql As String = ""
            'Dim vItem As ValueItem
            strSql = "select fitemid,fname from t_Stock"
            RtnDataTable = getdate.GetDataset(strSql, constr)
            Me.CheckedListBox1.Items.Clear()
            For i As Integer = 0 To RtnDataTable.Tables(0).Rows.Count - 1
                'vItem = New ValueItem(ds.Tables(0).Rows(i)("finterid"), ds.Tables(0).Rows(i)("fname"))
                'vItem = New TextBox()
                'vItem.Tag = ds.Tables(0).Rows(i)("finterid")
                'vItem.Text = ds.Tables(0).Rows(i)("fname")
                Me.CheckedListBox1.Items.Add(RtnDataTable.Tables(0).Rows(i)("fname"))
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MCLdanhao = ""
        MCLneima = ""
        For i As Integer = 0 To CheckedListBox1.CheckedItems.Count - 1
            If i = 0 Then
                'FSCHJ.Text = FSCHJ.Text & CType(CheckedListBox1.CheckedItems(i), TextBox).Text
                'FSCHJ.Value = FSCHJ.Value & CType(CheckedListBox1.CheckedItems(i), TextBox).Tag
                MCLdanhao = MCLdanhao & CheckedListBox1.CheckedItems(i)
                Values(i)
            Else
                'FSCHJ.Text = FSCHJ.Text & "," & CType(CheckedListBox1.CheckedItems(i), TextBox).Text
                'FSCHJ.Value = FSCHJ.Value & "," & CType(CheckedListBox1.CheckedItems(i), TextBox).Tag
                MCLdanhao = MCLdanhao & "," & CheckedListBox1.CheckedItems(i)
                Values(i)
            End If
        Next
        Me.Close()
    End Sub
    Private Sub Values(ByVal i As Integer)
        Try
            Dim strSql As String = ""
            'Dim vItem As ValueItem
            strSql = "select fitemid,fname from t_Stock"
            RtnDataTable = getdate.GetDataset(strSql, constr)

            For j As Integer = 0 To RtnDataTable.Tables(0).Rows.Count - 1
                If CheckedListBox1.CheckedItems(i) = RtnDataTable.Tables(0).Rows(j)("fname") Then
                    If i = 0 Then
                        MCLneima = MCLneima & RtnDataTable.Tables(0).Rows(j)("fitemid")
                    Else
                        MCLneima = MCLneima & "," & RtnDataTable.Tables(0).Rows(j)("fitemid")
                    End If
                End If
            Next


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Dim strSql As String = ""
            'Dim vItem As ValueItem
            strSql = "select fitemid,fname from t_Stock where fname like '%" & txtSearchText.Text.Trim() & "%'"
            RtnDataTable = getdate.GetDataset(strSql, constr)
            Me.CheckedListBox1.Items.Clear()
            For i As Integer = 0 To RtnDataTable.Tables(0).Rows.Count - 1
                'vItem = New ValueItem(ds.Tables(0).Rows(i)("finterid"), ds.Tables(0).Rows(i)("fname"))
                'vItem = New TextBox()
                'vItem.Tag = ds.Tables(0).Rows(i)("finterid")
                'vItem.Text = ds.Tables(0).Rows(i)("fname")
                Me.CheckedListBox1.Items.Add(RtnDataTable.Tables(0).Rows(i)("fname"))
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class