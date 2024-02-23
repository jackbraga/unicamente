using Dapper;
using System.Data.Common;
using Unicamente.Domain.Entities;
using Unicamente.Domain.Interfaces;
using Unicamente.Repository.Uteis;

namespace Unicamente.Repository
{
    public class RecipienteRepository : IRecipienteRepository
    {
        private readonly IConnectionFactory _connection;

        public RecipienteRepository(IConnectionFactory connectionFactory)
        {
            _connection = connectionFactory;
        }
        public int Add(Recipiente classe)
        {
            var sql = @"INSERT INTO tbRecipiente(Descricao,Volume,QuantidadeReuso,Observacao,Imagem)
                        OUTPUT INSERTED.ID
                        VALUES(@descricao,@volume,@quantidade,@observacao,@imagem);"
            ;

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var id = connection.ExecuteScalar<int>(sql, new
                {
                    descricao = classe.Descricao.RemoveAcentos().RemoveEspacos().ToUpper(),
                    volume = classe.Volume,
                    quantidade = classe.QuantidadeReuso,
                    observacao = classe.Observacao,
                    imagem = classe.Imagem
                });
                return id;
            }
        }

        public IEnumerable<Recipiente> GetAll()
        {
            var sql = @"SELECT ID, Descricao, Volume, QuantidadeReuso, Observacao, Imagem
                        FROM tbRecipiente";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var recipientes = connection.Query<Recipiente>(sql);

                return recipientes;
            }
        }

        public Recipiente GetById(int? id)
        {
            var sql = @"SELECT ID, Descricao, Volume, QuantidadeReuso, Observacao, Imagem
                        FROM tbRecipiente WHERE ID=@id";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var recipiente = connection.QueryFirstOrDefault<Recipiente>(sql,
                    new
                    {
                        id
                    });

                return recipiente;
            }
        }

        public IEnumerable<Recipiente> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var sql = @"DELETE FROM tbRecipiente WHERE ID=@id";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.ExecuteScalar(sql, new
                {
                    id
                });
            }
        }

        public void Update(Recipiente classe)
        {
            var sql = @"UPDATE tbRecipiente
                        SET 
	                        Descricao=@descricao,
	                        Volume=@volume,
	                        QuantidadeReuso=@quantidade,
	                        Observacao=@observacao,
	                        Imagem=@imagem
	                        WHERE ID=@id";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.Execute(sql, new
                {
                    descricao = classe.Descricao.RemoveAcentos().RemoveEspacos().ToUpper(),
                    volume = classe.Volume,
                    quantidade = classe.QuantidadeReuso,
                    observacao = classe.Observacao,
                    imagem = classe.Imagem,
                    id = classe.ID
                });
            }
        }
    }
}
