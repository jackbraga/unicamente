using Dapper;
using Unicamente.Domain.Entities;
using Unicamente.Domain.Interfaces;
using System.Data.Common;

namespace Unicamente.Repository
{
    public class EmpreendimentoRepository : IEmpreendimentoRepository
    {
        private readonly IConnectionFactory _connection;
        public EmpreendimentoRepository(IConnectionFactory connection)
        {
            _connection = connection;
        }

        public int Add(Empreendimento classe)
        {
            var sql = @"INSERT INTO tbEmpreendimento(Descricao,Matricula,CEP,Logradouro,Numero,Complemento,Referencia,Bairro,Cidade,UF)
                        OUTPUT INSERTED.ID
                        VALUES(@descricao,@matricula,@cep,@logradouro,@numero,@complemento,@referencia,@bairro,@cidade,@uf)"
            ;

            using (var connection = _connection.Connection())
            {
                connection.Open();
                int id = connection.ExecuteScalar<int>(sql, new
                {
                    descricao = classe.Descricao,
                    matricula = classe.Matricula,
                    cep = classe.CEP,
                    logradouro = classe.Logradouro,
                    numero = classe.Numero,
                    complemento = classe.Complemento,
                    referencia = classe.Referencia,
                    bairro = classe.Bairro,
                    cidade = classe.Cidade,
                    uf = classe.UF,
                });
                return id;
            }
        }

        public IEnumerable<Empreendimento> GetAll()
        {
            var sql = @"SELECT ID,
                        Descricao,
                        Matricula,
                        CEP,
                        Logradouro,
                        Numero,
                        Complemento,
                        Referencia,
                        Bairro,
                        Cidade,
                        UF
                        FROM tbEmpreendimento"
            ;

            using (var connection = _connection.Connection())
            {
                connection.Open();
                return connection.Query<Empreendimento>(sql);
            }

        }


        public Empreendimento GetById(int? id)
        {
            var sql = @"SELECT ID,
                        Descricao,
                        Matricula,
                        CEP,
                        Logradouro,
                        Numero,
                        Complemento,
                        Referencia,
                        Bairro,
                        Cidade,
                        UF
                        FROM tbEmpreendimento WHERE ID=@id";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                return connection.Query<Empreendimento>(sql, new { id }).FirstOrDefault();
            }
        }


        public IEnumerable<Empreendimento> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var sql = "DELETE FROM tbEmpreendimento WHERE ID=@id";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.Execute(sql, new
                {
                    id
                });
            }
        }

        public void Update(Empreendimento classe)
        {
            var sql = @"UPDATE tbEmpreendimento
                        SET 
	                        Descricao=@descricao,
	                        matricula=@matricula,
	                        CEP=@cep,
	                        Logradouro=@logradouro,
	                        Numero=@numero,
	                        Complemento=@complemento,
	                        Referencia=@referencia,
	                        Bairro=@bairro,
	                        Cidade=@cidade,
	                        UF=@uf
	                        WHERE ID=@id";
            using (var connection = _connection.Connection())
            {
                try
                {

                    connection.Open();
                    connection.Execute(sql, new
                    {
                        descricao = classe.Descricao,
                        matricula = classe.Matricula,
                        cep = classe.CEP,
                        logradouro = classe.Logradouro,
                        numero = classe.Numero,
                        complemento = classe.Complemento,
                        referencia = classe.Referencia,
                        bairro = classe.Bairro,
                        cidade = classe.Cidade,
                        uf = classe.UF,
                        id = classe.ID
                    });
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
