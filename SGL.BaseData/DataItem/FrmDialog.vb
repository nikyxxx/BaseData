Public Class FrmDialog
    Public mDialogParams As Hashtable
    Public mvalueParams As Hashtable
    Public mResultParams As Hashtable
    Private Sub FrmDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Normal
        Me.MaximizeBox = False
        Me.MinimizeBox = False

        Dim keys(mDialogParams.Count - 1) As String
        mDialogParams.Keys.CopyTo(keys, 0)

        Dim ctl As Control, ctl1 As Control
        For i As Integer = 0 To mDialogParams.Count - 1
            ctl = New Label()
            ctl.Text = keys(i) & ":"
            CType(ctl, Label).AutoSize = True
            ctl.Location = New System.Drawing.Point(60, 10 + i * 30)

            Me.Controls.Add(ctl)

            Select Case mDialogParams(keys(i))
                Case "1"
                    ctl1 = New C1.Win.C1Input.C1TextBox()
                    If Not mvalueParams Is Nothing AndAlso mvalueParams.ContainsKey(keys(i)) Then ctl1.Text = mvalueParams(keys(i))
                Case "2"
                    ctl1 = New C1.Win.C1Input.C1NumericEdit()
                    CType(ctl1, C1.Win.C1Input.C1NumericEdit).ShowDropDownButton = False
                    If Not mvalueParams Is Nothing AndAlso mvalueParams.ContainsKey(keys(i)) Then CType(ctl1, C1.Win.C1Input.C1NumericEdit).Value = mvalueParams(keys(i))
                Case "3"
                    ctl1 = New C1.Win.C1Input.C1DateEdit()
                    If Not mvalueParams Is Nothing AndAlso mvalueParams.ContainsKey(keys(i)) Then CType(ctl1, C1.Win.C1Input.C1DateEdit).Value = mvalueParams(keys(i))
            End Select

            ctl1.Name = "F" & keys(i)
            ctl1.Location = New System.Drawing.Point(65 + ctl.Width, 10 + i * 30 - 2)
            ctl1.Width = 100
            Me.Controls.Add(ctl1)
        Next

        btnOK.Location = New System.Drawing.Point(65, 10 + mDialogParams.Count * 30 - 2)
        btnCANCEL.Location = New System.Drawing.Point(65 + 100, 10 + mDialogParams.Count * 30 - 2)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim keys(mDialogParams.Count - 1) As String
        mDialogParams.Keys.CopyTo(keys, 0)

        mResultParams = New Hashtable
        For i As Integer = 0 To mDialogParams.Count - 1
            mResultParams.Add(keys(i), Me.Controls("F" & keys(i)).Text)
        Next
        Me.Close()
    End Sub

    Private Sub btnCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCANCEL.Click
        mResultParams = New Hashtable
        Me.Close()
    End Sub
End Class