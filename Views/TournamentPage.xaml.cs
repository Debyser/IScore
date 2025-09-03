using IScore.ViewModels;

namespace IScore.Views;

public partial class TournamentPage : ContentPage
{
    public TournamentPage(TournamentViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}