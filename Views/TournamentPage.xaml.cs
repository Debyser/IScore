using IScore.ViewModels;

namespace IScore.Views;

public partial class TournamentPage : ContentPage
{
    private readonly TournamentViewModel _viewModel;

    public TournamentPage(TournamentViewModel vm)
    {
        InitializeComponent();
        _viewModel = vm;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // Optionally, you can refresh data here if needed
        await _viewModel.LoadAsync();
    }
}