using MauiAppMinhasCompras.Models;
using SQLite;
using System.Security.Cryptography.X509Certificates;

namespace MauiAppMinhasCompras.Helpers
{
    public class SqLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SqLiteDatabaseHelper(string path)
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
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE iD=?";
            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id);

        }

        public Task<int> Delete(int id)
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Produto>> getAll()
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT * FROM Produto WHERE descricao LIKE '%" + q + "%'";

            return _conn.QueryAsync<Produto>(sql);
        }

            // Apaga dados do banco (trucante) testes
            public Task ClearProdutos()
        {
                return _conn.DeleteAllAsync<Produto>();
        }

        }
    }

