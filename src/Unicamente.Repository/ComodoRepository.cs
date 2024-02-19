using Dapper;
using Unicamente.Domain.Entities;
using Unicamente.Domain.Interfaces;
using System.Data;
using System.Data.Common;

namespace Unicamente.Repository
{
    public class ComodoRepository : IComodoRepository
    {

        private readonly IConnectionFactory _connection;

        public ComodoRepository(IConnectionFactory connection)
        {
            _connection = connection;
        }

        public int Add(Comodo classe)
        {
            var sql =
                @"INSERT INTO tbComodo
                  OUTPUT INSERTED.ID
                  VALUES(@descricao)";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                int id = connection.ExecuteScalar<int>(sql, new
                {
                    descricao = classe.Descricao
                });
                return id;
            }


        }

        public IEnumerable<Comodo> GetAll()
        {
            var sql = "SELECT * FROM tbComodo";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                var listaComodo = connection.Query<Comodo>(sql);
                return listaComodo;
            }

        }

        public Comodo GetById(int? id)
        {
            var sql = "SELECT * FROM tbComodo WHERE ID=@id";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                var comodo = connection.Query<Comodo>(sql, new
                {
                    id = id
                }).FirstOrDefault();
                return comodo;
            }
        }

        public IEnumerable<Comodo> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var sql = "DELETE FROM tbComodo WHERE ID=@id";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.Execute(sql, new
                {
                    id = id
                });
            }

        }

        public void Update(Comodo classe)
        {
            var sql = "UPDATE tbComodo SET DESCRICAO=@descricao WHERE ID=@id";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.Execute(sql, new
                {
                    id = classe.ID,
                    descricao = classe.Descricao
                });
            }

        }
    }
}
