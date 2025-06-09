using MauiAppMinhasCompras.Models; // Vamos utilizar a nossa model Produto criada anteriormente
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    //Aqui alteramos de internal para public
    public class SQLiteDataBaseHelper
    {
        //Essa linha de código declara um campo somente leitura (readonly) chamado _connection, do tipo SQLiteAsyncConnection.

        readonly SQLiteAsyncConnection _conn;
        //Declaração do construtor
        public SQLiteDataBaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }

        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPDATE Produto SET Descricao = ?, Quantidade = ?, Preco = ? WHERE Id = ?";
            return  _conn.QueryAsync<Produto>(sql,p.Descricao,p.Quantidade,p.Preco,p.Id);
        }

        public Task<int> Delete(int id)
        {
          return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT * Produto WHERE Descricao like '%" + q + "%'";
           return _conn.QueryAsync<Produto>(sql);
        }
    }
}

