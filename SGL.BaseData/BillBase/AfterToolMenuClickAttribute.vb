Public Class AfterToolMenuClickAttribute
    Inherits Attribute

    Public MenuName As String

    Public Sub New(ByVal name As String)
        MenuName = name
    End Sub
End Class
