using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IScore.Data;
using IScore.Models;

namespace IScore.ViewModels
{
    public partial class TournamentDetailViewModel(DatabaseContext context) : ObservableObject, IQueryAttributable
    {
        private readonly DatabaseContext _context = context;
        private Tournament _tournament;
        [ObservableProperty]
        public partial string Name { get; set; }

        [ObservableProperty]
        public partial string Format { get; set; }

        [ObservableProperty]
        public partial string SportType { get; set; }


        [RelayCommand]
        public async Task UpdateAsync()
        {
            _tournament.Name = Name;
            _tournament.Format = Format;
            _tournament.SportType = SportType;
            _tournament.StartDate = DateTime.Now.ToString("yyyy-MM-dd");
            await _context.UpdateItemAsync<Tournament>(_tournament);
            await Shell.Current.DisplayAlert("Success", "Tournament updated successfully", "OK");
            Clear();
            await Shell.Current.GoToAsync("..");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var tournament = query["tournament"] as Tournament;
            if (tournament is null) return;
            _tournament = tournament;
            Name = tournament.Name;
            Format = tournament.Format;
            SportType = tournament.SportType;
        }

        private void Clear()
        {
            Name = string.Empty;
            Format = string.Empty;
            SportType = string.Empty;
        }
    }
}
