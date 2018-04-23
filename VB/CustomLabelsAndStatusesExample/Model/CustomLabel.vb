#Region "#customlabelusings"
Imports DevExpress.Mvvm.POCO
Imports System.Windows.Media
#End Region ' #customlabelusings

Namespace CustomLabelsAndStatusesExample
    #Region "#customlabel"
    Public Class CustomLabel
        Public Shared Function Create() As CustomLabel
            Return ViewModelSource.Create(Function() New CustomLabel())
        End Function
        Protected Sub New()
        End Sub
        Public Overridable Property Id() As Integer
        Public Overridable Property Caption() As String
        Public Overridable Property Color() As Color
    End Class
    #End Region ' #customlabel
End Namespace
