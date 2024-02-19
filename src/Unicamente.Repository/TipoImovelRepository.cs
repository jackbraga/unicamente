using Dapper;
using Unicamente.Domain.Entities;
using Unicamente.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicamente.Repository
{
    public class TipoImovelRepository : ITipoImovelRepository
    {

        private readonly IConnectionFactory _connection;

        public TipoImovelRepository(IConnectionFactory connection)
        {
            _connection = connection;
        }


        public int Add(TipoImovel classe)
        {
            var sql =
                @"INSERT INTO tbTipoImovel
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

        public IEnumerable<TipoImovel> GetAll()
        {
            var sql = "SELECT * FROM tbTipoImovel";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var listaTipoImovel = connection.Query<TipoImovel>(sql);
                return listaTipoImovel;
            }
        }

        public TipoImovel GetById(int? id)
        {
            var sql = "SELECT * FROM tbTipoImovel WHERE ID=@id";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                var tipoimovel = connection.Query<TipoImovel>(sql, new
                {
                    id = id
                }).FirstOrDefault();
                return tipoimovel;
            }

        }

        public IEnumerable<TipoImovel> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var sql = "DELETE FROM tbTipoImovel WHERE ID=@id";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.Execute(sql, new
                {
                    id = id
                });
            }

        }

        public void Update(TipoImovel classe)
        {
            var sql = "UPDATE tbTipoImovel SET DESCRICAO=@descricao WHERE ID=@id";
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
