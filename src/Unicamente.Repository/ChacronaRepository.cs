using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicamente.Domain.Entities;
using Unicamente.Domain.Interfaces;
using Unicamente.Repository.Uteis;

namespace Unicamente.Repository
{
    public class ChacronaRepository:IChacronaRepository
    {

        private readonly IConnectionFactory _connection;

        public ChacronaRepository(IConnectionFactory connection)
        {
            _connection = connection;
        }
        public int Add(Chacrona classe)
        {
            var sql = @"INSERT INTO tbChacrona(Descricao,Observacao,Imagem)
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

        public IEnumerable<Chacrona> GetAll()
        {
            var sql = @"SELECT ID, Descricao, Observacao, Imagem
                        FROM tbChacrona"
            ;

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var chacronas = connection.Query<Chacrona>(sql);

                return chacronas;
            }
        }

        public Chacrona GetById(int? id)
        {
            var sql = @"SELECT ID, Descricao, Observacao, Imagem
                        FROM tbChacrona WHERE ID=@id";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var chacrona = connection.QueryFirstOrDefault<Chacrona>(sql,
                    new
                    {
                        id
                    });

                return chacrona;
            }
        }

        public IEnumerable<Chacrona> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var sql = @"DELETE FROM tbChacrona WHERE ID=@id";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.ExecuteScalar(sql, new
                {
                    id
                });
            }
        }

        public void Update(Chacrona classe)
        {
            var sql = @"UPDATE tbChacrona
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
