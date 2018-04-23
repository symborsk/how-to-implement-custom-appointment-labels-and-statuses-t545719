#Region "#usings"
Imports DevExpress.Mvvm.POCO
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Windows.Media
#End Region ' #usings

Namespace CustomLabelsAndStatusesExample
    Public Class MainViewModel
	#Region "#customlabelstatusviewmodel"
        Public Overridable Property Doctors() As ObservableCollection(Of Doctor)
        Public Overridable Property Appointments() As ObservableCollection(Of MedicalAppointment)
        Public Overridable Property Statuses() As ObservableCollection(Of PaymentState)
        Public Overridable Property Labels() As ObservableCollection(Of CustomLabel)


        Public Shared AppointmentTypes() As String = { "Hospital", "Office", "Phone Consultation", "Home", "Hospice" }
        Public Shared AppointmentColorTypes() As Color = { Color.FromRgb(168, 213, 255), Color.FromRgb(255, 194, 190), Color.FromRgb(255, 247, 165), Color.FromRgb(193, 244, 156), Color.FromRgb(244, 206, 147) }

        Public Shared PaymentStates() As String = { "Paid", "Unpaid" }
        Public Shared PaymentBrushStates() As Brush = { _
            New LinearGradientBrush(Colors.Green,Colors.Yellow, 45.0), _
            New SolidColorBrush(Colors.Red) _
        }

        Private rand As New Random(Date.Now.Millisecond)

        Protected Sub New()
            Statuses = CreateStatuses()
            Labels = CreateLabels()
            Doctors = CreateDoctors()
            Appointments = CreateMedicalAppointments()
        End Sub

        Private Function CreateLabels() As ObservableCollection(Of CustomLabel)
            Dim result As New ObservableCollection(Of CustomLabel)()
            Dim count As Integer = AppointmentTypes.Length
            For i As Integer = 0 To count - 1
                Dim label As CustomLabel = CustomLabel.Create()
                label.Id = i
                label.Color = AppointmentColorTypes(i)
                label.Caption = AppointmentTypes(i)
                result.Add(label)
            Next i
            Return result
        End Function

        Private Function CreateStatuses() As ObservableCollection(Of PaymentState)
            Dim result As New ObservableCollection(Of PaymentState)()
            Dim count As Integer = PaymentStates.Length
            For i As Integer = 0 To count - 1

                Dim paymentState_Renamed As PaymentState = CustomLabelsAndStatusesExample.PaymentState.Create()
                paymentState_Renamed.Id = i
                paymentState_Renamed.Brush = PaymentBrushStates(i)
                paymentState_Renamed.Caption = PaymentStates(i)
                result.Add(paymentState_Renamed)
            Next i
            Return result
        End Function
		
	#End Region

        Private Function CreateDoctors() As ObservableCollection(Of Doctor)
            Dim result As New ObservableCollection(Of Doctor)()
            result.Add(Doctor.Create(Id:= 1, Name:= "Stomatologist"))
            result.Add(Doctor.Create(Id:= 2, Name:= "Ophthalmologist"))
            result.Add(Doctor.Create(Id:= 3, Name:= "Surgeon"))
            Return result
        End Function

        Private Function CreateMedicalAppointments() As ObservableCollection(Of MedicalAppointment)
            Dim result As New ObservableCollection(Of MedicalAppointment)()
            Dim today As Date = Date.Today
            result.Add(MedicalAppointment.Create(StartTime:= today.AddHours(10), EndTime:= today.AddHours(11), DoctorId:= 1, Notes:= "", Location:= "101", PatientName:= "Dave Murrel", InsuranceNumber:= GenerateNineNumbers(), FirstVisit:= True))
            result.Add(MedicalAppointment.Create(StartTime:= today.AddDays(2).AddHours(15), EndTime:= today.AddDays(2).AddHours(16), DoctorId:= 1, Notes:= "", Location:= "101", PatientName:= "Mike Roller", InsuranceNumber:= GenerateNineNumbers(), FirstVisit:= True))

            result.Add(MedicalAppointment.Create(StartTime:= today.AddDays(1).AddHours(11), EndTime:= today.AddDays(1).AddHours(12), DoctorId:= 2, Notes:= "", Location:= "103", PatientName:= "Bert Parkins", InsuranceNumber:= GenerateNineNumbers(), FirstVisit:= True))
            result.Add(MedicalAppointment.Create(StartTime:= today.AddDays(2).AddHours(10), EndTime:= today.AddDays(2).AddHours(12), DoctorId:= 2, Notes:= "", Location:= "103", PatientName:= "Carl Lucas", InsuranceNumber:= GenerateNineNumbers(), FirstVisit:= False))

            result.Add(MedicalAppointment.Create(StartTime:= today.AddHours(12), EndTime:= today.AddHours(13), DoctorId:= 3, Notes:= "Blood test results are required", Location:= "104", PatientName:= "Brad Barnes", InsuranceNumber:= GenerateNineNumbers(), FirstVisit:= False))
            result.Add(MedicalAppointment.Create(StartTime:= today.AddDays(1).AddHours(14), EndTime:= today.AddDays(1).AddHours(15), DoctorId:= 3, Notes:= "", Location:= "104", PatientName:= "Richard Fisher", InsuranceNumber:= GenerateNineNumbers(), FirstVisit:= True))
            Return result
        End Function
        Private Function GenerateNineNumbers() As String
            Dim result As String = String.Empty
            Dim count As Integer = 9
            Dim i As Integer = 0
            Do While i < count
                result &= rand.Next(count).ToString()
                i += 1
            Loop
            Return result
        End Function
    End Class
End Namespace
