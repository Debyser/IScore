using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IScore.Models;
using IScore.Services;

namespace IScore.ViewModels
{
    //[QueryProperty("Text","Text")]
    public partial class AddTournamentViewModel(TournamentService service) : ObservableObject
    {
        private readonly TournamentService _service = service;
        [ObservableProperty]
        public partial string Name { get; set; }

        [ObservableProperty]
        public partial string Format { get; set; }

        [ObservableProperty]
        public partial string SportType { get; set; }


        [RelayCommand]
        public async Task AddAsync()
        {

            var tournament = new Tournament
            {
                Name = Name,
                Format = Format,
                SportType = SportType,
                StartDate = DateTime.Now.ToString("yyyy-MM-dd")
            };
            await _service.CreateAsync(tournament);
            // add a alert
            await Shell.Current.DisplayAlert("Success", "Tournament added successfully", "OK");
            //test navigation
            //await Shell.Current.GoToAsync("..");
            Clear();
        }
        private void Clear()
        {
            Name = string.Empty;
            Format = string.Empty;
            SportType = string.Empty;
        }
    }
}
