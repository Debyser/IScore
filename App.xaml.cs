using IScore.Data;

namespace IScore
{
    public partial class App : Application
    {
        public App(DatabaseContext databaseService)
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

    }
}