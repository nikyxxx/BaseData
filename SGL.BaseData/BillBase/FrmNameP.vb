Imports System.Windows.Forms
Public Class FrmNameP
    Public newname As String
    Public ok1 As Boolean = False
    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        newname = Me.newwayname.Text
        If newname = "" Then
            MessageBox.Show("请录入方案,没有保存成功", "创源提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else
            ok1 = True
            Me.Close()
        End If
    End Sub

    Private Sub cmdChanel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdChanel.Click
        ok1 = False
        Me.Close()
    End Sub

    Private Sub FrmNameP_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
    End Sub
End Class