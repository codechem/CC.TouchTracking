using System.ComponentModel;
using Xamarin.Forms;

namespace TouchTrackingSample
{
    public class VM : INotifyPropertyChanged
    {
        private float x;
        public float X
        {
            get => x;
            set
            {
                x = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(X)));
            }
        }

        private float y;
        public float Y
        {
            get => y;
            set
            {
                y = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Y)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
    public partial class MainPage : ContentPage
    {
        readonly VM Model = new VM();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = Model;
        }


        void TouchEffect_TouchAction(System.Object sender, TouchTracking.TouchActionEventArgs args)
        {
            Model.X = args.Location.X;
            Model.Y = args.Location.Y;
        }
    }
}
