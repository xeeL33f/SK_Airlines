using SK_Airlines_App.Views;

namespace SK_Airlines_App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(FlightBookingSelection), typeof(FlightBookingSelection));
            Routing.RegisterRoute(nameof(TestBookingSummary), typeof(TestBookingSummary));
            Routing.RegisterRoute(nameof(GuestDetailsPageSubTickets), typeof(GuestDetailsPageSubTickets));
            Routing.RegisterRoute(nameof(AddonsPage), typeof(AddonsPage));
            Routing.RegisterRoute(nameof(BookingSummaryPage), typeof(BookingSummaryPage));
        }
    }
}