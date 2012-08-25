Public Class BeforeToolMenuClickAttribute
    Inherits Attribute

    Public MenuName As String

    Public Sub New(ByVal name As String)
        MenuName = name
    End Sub
End Class
