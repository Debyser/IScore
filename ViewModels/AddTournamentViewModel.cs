using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IScore.Data;
using IScore.Models;

namespace IScore.ViewModels
{
    //[QueryProperty("Text","Text")]
    public partial class AddTournamentViewModel(DatabaseContext context) : ObservableObject
    {
        private readonly DatabaseContext _context = context;
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
            await _context.AddItemAsync<Tournament>(tournament);
            // add a alert
            await Shell.Current.DisplayAlert("Success", "Tournament added successfully", "OK");

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
