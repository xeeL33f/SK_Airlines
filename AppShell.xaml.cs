namespace SK_Airlines_App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(FlightBookingSelection), typeof(FlightBookingSelection));
        }
    }
}