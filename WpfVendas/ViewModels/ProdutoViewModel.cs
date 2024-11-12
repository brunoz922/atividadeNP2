using DsiVendas.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfVendas.ViewModels
{
    public class ProdutoViewModel : INotifyPropertyChanged
    {
        private readonly HttpClient _httpClient;

        public ObservableCollection<Produto> Produtos { get; set; }

        public ProdutoViewModel()
        {
            _httpClient = new HttpClient();
            Produtos = new ObservableCollection<Produto>();
            //CarregarClientesDaAPI();
        }

        public async Task CarregarProdutosDaAPI()
        {
            try
            {
                var apiUrl = "http://localhost:5299/Api/GetProdutos";
                var produtosDaApi = await _httpClient.GetFromJsonAsync<Produto[]>(apiUrl);

                if (produtosDaApi != null)
                {
                    foreach (var produto in produtosDaApi)
                    {
                        Produtos.Add(produto);
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erro ao buscar produtos: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
