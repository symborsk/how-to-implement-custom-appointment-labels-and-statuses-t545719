#region #customstatususings
using DevExpress.Mvvm.POCO;
using System.Windows.Media;
#endregion #customstatususings

namespace CustomLabelsAndStatusesExample {
    #region #customstatus
    public class PaymentState {
        public static PaymentState Create() {
            return ViewModelSource.Create(() => new PaymentState());
        }

        protected PaymentState() { }
        public virtual int Id { get; set; }
        public virtual string Caption { get; set; }
        public virtual Brush Brush { get; set; }
    }
    #endregion #customstatus
}
