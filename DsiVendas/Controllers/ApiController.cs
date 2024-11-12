using Microsoft.AspNetCore.Mvc;
using DsiVendas.Models;

namespace DsiVendas.Controllers;

public class ApiController(ApplicationDbContext context) : Controller
{

      public List<Cliente> GetClientes()
      {
        var listaClientes = context.Clientes.ToList();
        return listaClientes;
      }

      [HttpPost]
      public IActionResult CreateCliente([FromBody] Cliente cliente)
      {
        var clientedb = context.Clientes.Add(cliente);
        context.SaveChanges();  
        return CreatedAtAction(nameof(CreateCliente), new { id = clientedb.Entity.Id }, clientedb.Entity);
      }

    [HttpPut]
    public IActionResult TestePut()
    {
        // Apenas retorna uma mensagem de sucesso para teste
        return Ok("Rota PUT funcionando corretamente!");
    }

    [HttpPut]
    public IActionResult UpdateCliente(int id, [FromBody] Cliente cliente)
    {

        // Verifica se o ID passado na URL � o mesmo do cliente no corpo
        if (id != cliente.Id)
        {
            return BadRequest("ID do cliente na URL e no corpo n�o coincidem.");
        }

        var clientedb = context.Clientes.Find(id);
        if (clientedb == null)
        {
            return NotFound();
        }

        clientedb.Nome = cliente.Nome;
        clientedb.Email = cliente.Email;
        clientedb.Telefone = cliente.Telefone;

        context.Clientes.Update(clientedb);
        context.SaveChanges();
        return NoContent();
    }
    public List<Fornecedor> GetFornecedores()
      {
        var listaFornecedores = context.Fornecedores.ToList();
        return listaFornecedores;
      }

      [HttpPost]
      public IActionResult CreateFornecedor([FromBody] Fornecedor fornecedor)
      {
        var fornecedordb = context.Fornecedores.Add(fornecedor);
        context.SaveChanges();  
        return CreatedAtAction(nameof(CreateFornecedor), new { id = fornecedordb.Entity.Id }, fornecedordb.Entity);
      }
    [HttpPut]
    public IActionResult UpdateFornecedor(int id, [FromBody] Fornecedor fornecedor)
    {

        // Verifica se o ID passado na URL � o mesmo do cliente no corpo
        if (id != fornecedor.Id)
        {
            return BadRequest("ID do fornecedor na URL e no corpo n�o coincidem.");
        }

        var fornecedordb = context.Fornecedores.Find(id);
        if (fornecedordb == null)
        {
            return NotFound();
        }

        fornecedordb.Nome = fornecedor.Nome;
        fornecedordb.Cidade = fornecedor.Cidade;
        fornecedordb.Telefone = fornecedor.Telefone;

        context.Fornecedores.Update(fornecedordb);
        context.SaveChanges();
        return NoContent();
    }
    //produtos
    public List<Produto> GetProdutos()
      {
        var listaProdutos = context.Produtos.ToList();
        return listaProdutos;
      }

      [HttpPost]
      public IActionResult CreateProduto([FromBody] Produto produto)
      {
        var produtodb = context.Produtos.Add(produto);
        context.SaveChanges();  
        return CreatedAtAction(nameof(CreateProduto), new { id = produtodb.Entity.Id }, produtodb.Entity);
      }
    [HttpPut]
    public IActionResult UpdateProduto(int id, [FromBody] Produto produto)
    {

        // Verifica se o ID passado na URL � o mesmo do cliente no corpo
        if (id != produto.Id)
        {
            return BadRequest("ID do produto na URL e no corpo n�o coincidem.");
        }

        var produtodb = context.Produtos.Find(id);
        if (produtodb == null)
        {
            return NotFound();
        }

        produtodb.Id = produto.Id;
        produtodb.Nome = produto.Nome;
        produtodb.Preco = produto.Preco;
        produtodb.FornecedorId = produto.FornecedorId;
        produtodb.Fornecedor = produto.Fornecedor;

        context.Produtos.Update(produtodb);
        context.SaveChanges();
        return NoContent();
    }
}
