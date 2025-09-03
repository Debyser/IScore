using CommunityToolkit.Mvvm.ComponentModel;

namespace IScore.ViewModels
{
    public partial class TournamentViewModel : ObservableObject
    {

        [ObservableProperty]
        private string Name;
        [ObservableProperty]
        private DateTime date;
        [ObservableProperty]
        private string location;
        [ObservableProperty]
        private string description;

    }
}
