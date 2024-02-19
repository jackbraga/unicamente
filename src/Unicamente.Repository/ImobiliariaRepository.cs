using Dapper;
using Unicamente.Domain.Entities;
using Unicamente.Domain.Interfaces;
using Unicamente.Repository.Uteis;
using System.Runtime.CompilerServices;

namespace Unicamente.Repository
{
    public class ImobiliariaRepository : IImobiliariaRepository
    {
        private readonly IConnectionFactory _connection;

        public ImobiliariaRepository(IConnectionFactory connectionFactory)
        {
            _connection = connectionFactory;
        }

        public int Add(Imobiliaria classe)
        {
            var sql = @"INSERT INTO tbImobiliaria(RazaoSocial,CNPJ,Email,NomeResponsavel,Contato)
                        OUTPUT INSERTED.ID
                        VALUES(@razaoSocial,@cnpj,@email,@responsavel,@contato);";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var id = connection.ExecuteScalar<int>(sql, new
                {
                    razaoSocial = classe.RazaoSocial.RemoveAcentos().RemoveEspacos().ToUpper(),
                    cnpj = classe.CNPJ.RemoveAcentosTrim(),
                    email = classe.Email.Trim(),
                    responsavel = classe.NomeResponsavel,
                    contato = classe.Contato,
     
                });
                return id;
            }
        }

        public IEnumerable<Imobiliaria> GetAll()
        {
            var sql = @"SELECT ID, RazaoSocial, CNPJ, Email, NomeResponsavel, Contato
                        FROM tbImobiliaria";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var imobiliarias = connection.Query<Imobiliaria>(sql);

                return imobiliarias;
            }
        }

        public Imobiliaria GetById(int? id)
        {
            var sql = @"SELECT ID, RazaoSocial, CNPJ, Email, NomeResponsavel, Contato
                        FROM tbImobiliaria WHERE ID=@id";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var imob = connection.QueryFirstOrDefault<Imobiliaria>(sql, 
                    new 
                    { 
                        id
                });

                return imob;
            }
        }

        public IEnumerable<Imobiliaria> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Imobiliaria classe)
        {
            var sql = @"UPDATE tbImobiliaria
                        SET 
	                        RazaoSocial=@razao,
	                        CNPJ=@cnpj,
	                        NomeResponsavel=@responsavel,
	                        Contato=@contato
	                        WHERE ID=@id";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.Execute(sql, new
                {
                    razao = classe.RazaoSocial.RemoveAcentos().RemoveEspacos().ToUpper(),
                    cnpj = classe.CNPJ.RemoveAcentosTrim(),
                    responsavel = classe.NomeResponsavel.RemoveAcentos().RemoveEspacos().ToUpper(),
                    contato = classe.Contato,
                    id=classe.ID
                });
            }
        }

        public Imobiliaria GetByEmail(string email)
        {
            var sql = @"SELECT ID, RazaoSocial,Email, NomeResponsavel, Contato
                        FROM tbImobiliaria 
                        WHERE Email=@email";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var imob = connection.QueryFirstOrDefault<Imobiliaria>(sql, new
                {
                    email
                }
                );
                return imob;

            }
        }
    }
}
