using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    ObservableCollection<Produto> lista = new ObservableCollection<Produto>();
	public ListaProduto()
	{
		InitializeComponent();
        lst_produtos.ItemsSource = lista;
	}
    protected async override void OnAppearing()
    {
        List<Produto> tmp = await App.Db.getAll();
        tmp.ForEach(i => lista.Add(i));
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new Views.NovoProduto());
        }
        catch (Exception ex)
        {

            DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void txt_search_TextChaged(object sender, TextChangedEventArgs e)
    {
        string q = e.NewTextValue;
        lista.Clear();
        List<Produto> tmp = await App.Db.Search(q);
        tmp.ForEach(i => lista.Add(i));
    }

    private void ToolbarItem_Clicked1(object sender, EventArgs e)
    {
        double soma = lista.Sum(i => i.Quantidade);
        string msg = $"O total {soma:C}";
        DisplayAlert("Total dos Produtos", msg, "OK");
    }

    private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {

    }
}