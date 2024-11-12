using DsiVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfVendas.ViewModels;
using WpfVendas.Views;

namespace WpfVendas.Pages
{
    /// <summary>
    /// Interação lógica para pageClientes.xam
    /// </summary>
    public partial class pageProdutos : Page
    {
        private ProdutoViewModel _viewModel;

        public pageProdutos()
        {
            InitializeComponent();
            _viewModel = new ProdutoViewModel();
            DataContext = _viewModel;
        }

        private async void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Produtos.Clear();
            await _viewModel.CarregarProdutosDaAPI();
        }

        private void btnAddProduto_Click(object sender, RoutedEventArgs e)
        {
          var novoProduto = new Produto();

            var janelaCadastro = new cadProduto
            {
                Owner = Window.GetWindow(this)  
            };

            var viewModel = new ProdutoCadastroViewModel(janelaCadastro.Close, novoProduto);
            
            janelaCadastro.DataContext = viewModel;

            janelaCadastro.ShowDialog();
        }

        private void ProdutosDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Verifica se algum Produto está selecionado
            if (ProdutosDataGrid.SelectedItem is Produto produtoSelecionado)
            {
                // Cria a janela de edição
                var janelaCadastro = new cadProduto
                {
                    Owner = Window.GetWindow(this)  // Define o dono como a janela principal (MainWindow)
                };

                // Cria o ViewModel para a janela de edição, passando o cliente selecionado e a ação de fechar a janela
                var viewModel = new ProdutoCadastroViewModel(janelaCadastro.Close, produtoSelecionado);
                // Define o DataContext da janela
                janelaCadastro.DataContext = viewModel;
                // Mostra a janela de edição modal (abre por cima da MainWindow)
                janelaCadastro.ShowDialog();
            }
        }
    }
}
