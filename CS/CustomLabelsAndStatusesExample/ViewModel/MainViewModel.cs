#region #usings
using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
#endregion #usings

namespace CustomLabelsAndStatusesExample {
    public class MainViewModel {		
		#region #customlabelstatusviewmodel
        public virtual ObservableCollection<Doctor> Doctors { get; set; }
        public virtual ObservableCollection<MedicalAppointment> Appointments { get; set; }
        public virtual ObservableCollection<PaymentState> Statuses { get; set; }
        public virtual ObservableCollection<CustomLabel> Labels { get; set; }


        public static string[] AppointmentTypes = { "Hospital", "Office", "Phone Consultation", "Home", "Hospice" };
        public static Color[] AppointmentColorTypes = { Color.FromRgb(168, 213, 255),  Color.FromRgb(255, 194, 190),
            Color.FromRgb(255, 247, 165),  Color.FromRgb(193, 244, 156),  Color.FromRgb(244, 206, 147) };

        public static string[] PaymentStates = { "Paid", "Unpaid" };
        public static Brush[] PaymentBrushStates = { new LinearGradientBrush(Colors.Green,Colors.Yellow, 45.0), new SolidColorBrush(Colors.Red) };

        Random rand = new Random(DateTime.Now.Millisecond);

        protected MainViewModel() {
            Statuses = CreateStatuses();
            Labels = CreateLabels();
            Doctors = CreateDoctors();
            Appointments = CreateMedicalAppointments();
        }

        ObservableCollection<CustomLabel> CreateLabels() {
            ObservableCollection<CustomLabel>  result = new ObservableCollection<CustomLabel>();
            int count = AppointmentTypes.Length;
            for (int i = 0; i < count; i++) {
                CustomLabel label = CustomLabel.Create();
                label.Id = i;
                label.Color = AppointmentColorTypes[i];
                label.Caption = AppointmentTypes[i];
                result.Add(label);
            }
            return result;
        }

        ObservableCollection<PaymentState> CreateStatuses() {
            ObservableCollection<PaymentState> result = new ObservableCollection<PaymentState>();
            int count = PaymentStates.Length;
            for (int i = 0; i < count; i++) {
                PaymentState paymentState = PaymentState.Create();
                paymentState.Id = i;
                paymentState.Brush = PaymentBrushStates[i];
                paymentState.Caption = PaymentStates[i];
                result.Add(paymentState);
            }
            return result;
        }
		
		#endregion #customlabelstatusviewmodel

        ObservableCollection<Doctor> CreateDoctors() {
            ObservableCollection<Doctor> result = new ObservableCollection<Doctor>();
            result.Add(Doctor.Create(Id: 1, Name: "Stomatologist"));
            result.Add(Doctor.Create(Id: 2, Name: "Ophthalmologist"));
            result.Add(Doctor.Create(Id: 3, Name: "Surgeon"));
            return result;
        }

        ObservableCollection<MedicalAppointment> CreateMedicalAppointments() {
            ObservableCollection<MedicalAppointment> result = new ObservableCollection<MedicalAppointment>();
            DateTime today = DateTime.Today;
            result.Add(MedicalAppointment.Create(StartTime: today.AddHours(10), EndTime: today.AddHours(11), DoctorId: 1, Notes: "", Location: "101", PatientName: "Dave Murrel", InsuranceNumber: GenerateNineNumbers(), FirstVisit: true));
            result.Add(MedicalAppointment.Create(StartTime: today.AddDays(2).AddHours(15), EndTime: today.AddDays(2).AddHours(16), DoctorId: 1, Notes: "", Location: "101", PatientName: "Mike Roller", InsuranceNumber: GenerateNineNumbers(), FirstVisit: true));

            result.Add(MedicalAppointment.Create(StartTime: today.AddDays(1).AddHours(11), EndTime: today.AddDays(1).AddHours(12), DoctorId: 2, Notes: "", Location: "103", PatientName: "Bert Parkins", InsuranceNumber: GenerateNineNumbers(), FirstVisit: true));
            result.Add(MedicalAppointment.Create(StartTime: today.AddDays(2).AddHours(10), EndTime: today.AddDays(2).AddHours(12), DoctorId: 2, Notes: "", Location: "103", PatientName: "Carl Lucas", InsuranceNumber: GenerateNineNumbers(), FirstVisit: false));

            result.Add(MedicalAppointment.Create(StartTime: today.AddHours(12), EndTime: today.AddHours(13), DoctorId: 3, Notes: "Blood test results are required", Location: "104", PatientName: "Brad Barnes", InsuranceNumber: GenerateNineNumbers(), FirstVisit: false));
            result.Add(MedicalAppointment.Create(StartTime: today.AddDays(1).AddHours(14), EndTime: today.AddDays(1).AddHours(15), DoctorId: 3, Notes: "", Location: "104", PatientName: "Richard Fisher", InsuranceNumber: GenerateNineNumbers(), FirstVisit: true));
            return result;
        }
        string GenerateNineNumbers() {
            string result = String.Empty;
            int count = 9;
            for (int i = 0; i < count; i++) 
                result += rand.Next(count).ToString();
            return result;
        }
    }
}
