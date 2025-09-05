using IScore.ViewModels;

namespace IScore.Views;

public partial class AddTournamentPage : ContentPage
{
    public AddTournamentPage(AddTournamentViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}