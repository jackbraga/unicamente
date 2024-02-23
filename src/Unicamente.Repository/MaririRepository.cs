using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicamente.Domain.Entities;
using Unicamente.Domain.Interfaces;
using Unicamente.Repository.Uteis;

namespace Unicamente.Repository
{
    public class MaririRepository : IMaririRepository
    {

        private readonly IConnectionFactory _connection;

        public MaririRepository(IConnectionFactory connection)
        {
            _connection = connection;
        }


        public int Add(Mariri classe)
        {
            var sql = @"INSERT INTO tbMariri(Descricao,Observacao,Imagem)
                        OUTPUT INSERTED.ID
                        VALUES(@descricao,@observacao,@imagem);"
            ;

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var id = connection.ExecuteScalar<int>(sql, new
                {
                    descricao = classe.Descricao.RemoveAcentos().RemoveEspacos().ToUpper(),
                    observacao = classe.Observacao,
                    imagem = classe.Imagem
                });
                return id;
            }
        }

        public IEnumerable<Mariri> GetAll()
        {
            var sql = @"SELECT ID, Descricao, Observacao, Imagem
                        FROM tbMariri";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var mariri = connection.Query<Mariri>(sql);

                return mariri;
            }
        }

        public Mariri GetById(int? id)
        {
            var sql = @"SELECT ID, Descricao, Observacao, Imagem
                        FROM tbMariri WHERE ID=@id";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var mariri = connection.QueryFirstOrDefault<Mariri>(sql,
                    new
                    {
                        id
                    });

                return mariri;
            }
        }

        public IEnumerable<Mariri> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var sql = @"DELETE FROM tbMariri WHERE ID=@id";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.ExecuteScalar(sql, new
                {
                    id
                });
            }
        }

        public void Update(Mariri classe)
        {
            var sql = @"UPDATE tbMariri
                        SET 
	                        Descricao=@descricao,
	                        Observacao=@observacao,
	                        Imagem=@imagem
	                        WHERE ID=@id";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.Execute(sql, new
                {
                    descricao = classe.Descricao.RemoveAcentos().RemoveEspacos().ToUpper(),
                    observacao = classe.Observacao,
                    imagem = classe.Imagem,
                    id = classe.ID
                });
            }
        }
    }
}
