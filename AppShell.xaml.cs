using IScore.Views;

namespace IScore
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddTournamentPage), typeof(AddTournamentPage));
            Routing.RegisterRoute(nameof(TournamentDetailPage), typeof(TournamentDetailPage));
        }
    }
}
