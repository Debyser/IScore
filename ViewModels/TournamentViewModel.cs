using CommunityToolkit.Mvvm.ComponentModel;
using IScore.Data;
using IScore.Models;
using System.Collections.ObjectModel;

namespace IScore.ViewModels
{
    public partial class TournamentViewModel(DatabaseContext context) : ObservableObject
    {
        private readonly DatabaseContext _context = context;

        [ObservableProperty]
        public partial ObservableCollection<Tournament> Tournaments { get; set; } = new();

        [ObservableProperty]
        public partial Tournament? SelectedTournament { get; set; }
        [ObservableProperty]
        public partial bool IsBusy { get; set; }

        [ObservableProperty]
        public partial string BusyText { get; set; }
    }
}
