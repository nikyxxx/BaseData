
Imports SGL.BLL
Public Class FrmDD
#Region "成员变量声明"

    Private m_dsItemsInfo As New DataSet
    Private m_dsItemsInfo2 As New DataSet
    Private accountdata As New DataSet
    Private m_strItemClassName As String
    Public S_Classid As Integer = 0
    Public constr As String
    Private DBOpen As SGL.BLL.BLuser
    Public RtnDataTable As New DataSet
    Public Sglstr As String
    Dim ssssss As Integer
#End Region


    Private Sub BgW_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BgW.DoWork

        Dim worker As System.ComponentModel.BackgroundWorker = CType(sender, System.ComponentModel.BackgroundWorker)

        GetDataSKBill()

    End Sub

    Private Sub BgW_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BgW.RunWorkerCompleted

        ' First, handle the case where an exception was thrown.
        If Not (e.Error Is Nothing) Then
            MessageBox.Show(e.Error.Message)

        End If
        Me.ProgressBar1.Value = 100
        Timer1.Enabled = False
        Me.Close()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub GetDataSKBill()
        Try
            DBOpen = New BLuser
            RtnDataTable = DBOpen.GetDataset(Sglstr, constr)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitPage()
        Try

            Me.Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            BgW.RunWorkerAsync("1")

            'Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ssssss = 0 Then
            If Me.ProgressBar1.Value <> 100 Then
                If Me.ProgressBar1.Value < 20 Then
                    Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
                ElseIf Me.ProgressBar1.Value <> 92 And Me.ProgressBar1.Value >= 80 Then
                    Timer1.Interval = 7000
                    Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
                ElseIf Me.ProgressBar1.Value <> 92 And Me.ProgressBar1.Value >= 20 And Me.ProgressBar1.Value < 60 Then
                    Timer1.Interval = 3000
                    Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
                ElseIf Me.ProgressBar1.Value <> 92 And Me.ProgressBar1.Value >= 60 And Me.ProgressBar1.Value < 80 Then
                    Timer1.Interval = 5000
                    Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
                End If
            End If
        Else
            Me.ProgressBar1.Value = 100
        End If

    End Sub

    Private Sub FrmDD_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        InitPage()
    End Sub
End Class