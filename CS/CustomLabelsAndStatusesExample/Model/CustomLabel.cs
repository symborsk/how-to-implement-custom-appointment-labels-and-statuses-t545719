#region #customlabelusings
using DevExpress.Mvvm.POCO;
using System.Windows.Media;
#endregion #customlabelusings

namespace CustomLabelsAndStatusesExample {
    #region #customlabel
    public class CustomLabel {
        public static CustomLabel Create() {
            return ViewModelSource.Create(() => new CustomLabel());
        }
        protected CustomLabel() { }
        public virtual int Id { get; set; }
        public virtual string Caption { get; set; }
        public virtual Color Color { get; set; }
    }
    #endregion #customlabel
}
