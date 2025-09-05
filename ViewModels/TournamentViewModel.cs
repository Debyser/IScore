using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        public partial Tournament Tournament { get; set; } = new();
        [ObservableProperty]
        public partial bool IsBusy { get; set; }

        [ObservableProperty]
        public partial string BusyText { get; set; }


        [RelayCommand]
        public void SetOperatingTournament(Tournament? tournament) => Tournament = tournament ?? new();

        public async Task LoadAsync()
        {
            if (IsBusy) return;
            var busyText = "Loading tournaments...";
            await ExecuteAsync(async () =>
            {
                var tournaments = await _context.GetAllAsync<Tournament>();
                if (tournaments is null) return;
                if (!tournaments.Any()) return;

                Tournaments.Clear();
                foreach (var tournament in tournaments) Tournaments.Add(tournament);

            }, busyText);
        }

        [RelayCommand]
        public async Task AddAsync()
        {

            await Shell.Current.GoToAsync(nameof(Views.AddTournamentPage));
            // if (Tournament is null) return;

            /*var busyText = Tournament.Id == 0 ? "Adding tournament..." : "Updating tournament...";
            await ExecuteAsync(async () =>
            {
                if (Tournament.Id == 0)
                {
                    await _context.AddItemAsync<Tournament>(Tournament);
                }
                else
                {
                    // update
                    await _context.UpdateItemAsync<Tournament>(Tournament);
                    var tournamentCopy = Tournament.Clone();
                    var index = Tournaments.IndexOf(Tournament);
                    Tournaments.RemoveAt(index);

                    Tournaments.Insert(index, tournamentCopy);
                }
                Tournament = new();
                setOperatingTournamentCommand?.Execute(new());
            }, busyText);
            */


        }

        [RelayCommand]
        public async Task DeleteAsync(int id)
        {
            if (id == 0) return;
            await ExecuteAsync(async () =>
            {
                if (await _context.DeleteItemByKeyAsync<Tournament>(id))
                {
                    var tournament = Tournaments.FirstOrDefault(t => t.Id == id);
                    if (tournament != null)
                    {
                        Tournaments.Remove(tournament);
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Failed to delete the tournament.", "OK");
                }
            }, "Deleting tournament...");
        }

        private async Task ExecuteAsync(Func<Task> operation, string? busyText = null)
        {
            IsBusy = true;
            var text = "Processing...";
            BusyText = busyText ?? text;
            try
            {
                await operation.Invoke();
            }
            finally
            {
                IsBusy = false;
                BusyText = text;
            }
        }
    }
}
