namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new AppShell();

            //- Define a MainPage do aplicativo como uma página de navegação contendo ListaProduto (uma outra view do app).
            //- Troca de Tela Inciial
            MainPage = new NavigationPage(new Views.ListaProduto());                  
        }
    }
}


