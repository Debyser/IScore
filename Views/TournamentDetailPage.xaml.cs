using IScore.ViewModels;

namespace IScore.Views;

public partial class TournamentDetailPage : ContentPage
{
    public TournamentDetailPage(TournamentDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}