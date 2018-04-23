#Region "#customstatususings"
Imports DevExpress.Mvvm.POCO
Imports System.Windows.Media
#End Region ' #customstatususings

Namespace CustomLabelsAndStatusesExample
    #Region "#customstatus"
    Public Class PaymentState
        Public Shared Function Create() As PaymentState
            Return ViewModelSource.Create(Function() New PaymentState())
        End Function

        Protected Sub New()
        End Sub
        Public Overridable Property Id() As Integer
        Public Overridable Property Caption() As String
        Public Overridable Property Brush() As Brush
    End Class
    #End Region ' #customstatus
End Namespace
