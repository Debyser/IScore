namespace IScore
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.AddTournamentPage), typeof(Views.AddTournamentPage));
        }
    }
}
