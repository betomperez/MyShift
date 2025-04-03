using MyShift.Services;

namespace MyShift
{
    public partial class App : Application
    {
        public static NoteRepository NoteRepo { get; private set; }
        public App(NoteRepository repo)
        {
            InitializeComponent();
            NoteRepo = repo;
            MainPage = new AppShell();
        }
    }
}
