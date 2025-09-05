using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace IScore.ViewModels
{
    //[QueryProperty("Text","Text")]
    public partial class AddTournamentViewModel : ObservableObject
    {

        [ObservableProperty]
        public partial string Name { get; set; }

        public AddTournamentViewModel()
        {

        }

        [RelayCommand]
        public async Task AddAsync()
        {


            // await _context.AddItemAsync<Tournament>(Tournament);



        }


    }
}
