namespace CalculatorMAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

#if WINDOWS
        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);
            const int newWidth = 600;
            const int newHeight = 550;
            window.Width = newWidth;
            window.Height = newHeight;
            return window;
        }
#endif

#if ANDROID
        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);
            const int newWidth = 1080;
            const int newHeight = 1920;
            window.Width = newWidth;
            window.Height = newHeight;
            return window;
        }
#endif


    }
}