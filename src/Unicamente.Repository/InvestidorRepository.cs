using Dapper;
using Unicamente.Domain.Entities;
using Unicamente.Domain.Interfaces;
using Unicamente.Repository.Uteis;

namespace Unicamente.Repository
{
    public class InvestidorRepository : IInvestidorRepository
    {
        private readonly IConnectionFactory _connection;

        public InvestidorRepository(IConnectionFactory connectionFactory)
        {
            _connection = connectionFactory;
        }

        public int Add(Investidor classe)
        {
            var sql = @"INSERT INTO tbCadastroInvestidor(Nome,Celular,Email,Senha,TipoPessoa,SituacaoCadastro,HashConfirmarEmail)
                        OUTPUT INSERTED.ID
                        VALUES(@nome,@celular,@email,@senha,@tipoPessoa,@situacaoCadastro,@hash);";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var id = connection.ExecuteScalar<int>(sql, new
                {
                    nome = classe.Nome.RemoveAcentos().RemoveEspacos().ToUpper(),
                    celular = classe.Celular.RemoveAcentosTrim(),
                    email = classe.Email.Trim(),
                    senha = classe.Senha,
                    tipoPessoa = classe.TipoPessoa,
                    situacaoCadastro = 4, //Pendente Confirmacao de E-mail
                    hash = classe.HashConfirmarEmail
                });
                AddComplementoInvestidor(id);
                return id;
            }

        }

        private void AddComplementoInvestidor(int id)
        {
            var sql = "INSERT INTO tbComplementoInvestidor(IDInvestidor) VALUES(@idinvestidor);";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.ExecuteScalar(sql, new
                {
                    idinvestidor = id
                });
            }
        }

        public void AtualizarDadosPessoais(Investidor investidor)
        {
            var sql = @"UPDATE tbCadastroInvestidor SET
                        Nome=@nome,
                        Celular=@celular
                        WHERE ID=@id;
                            
                        UPDATE tbComplementoInvestidor SET
                        CPF=@cpf,
                        RG=@rg,
                        OrgaoExpedidor=@orgaoExpedidor,
                        UFRG=@ufrg,
                        Nascimento=@nascimento
                        WHERE IDInvestidor=@idInvestidor;";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.Execute(sql, new
                {
                    nome= investidor.Nome.RemoveAcentos().RemoveEspacos().ToUpper(),
                    celular= investidor.Celular,
                    id=investidor.ID,
                    cpf = investidor.Complemento.CPF.Trim(),
                    rg = investidor.Complemento.RG.Trim(),
                    orgaoExpedidor = investidor.Complemento.OrgaoExpedidor,
                    ufrg = investidor.Complemento.UFRG.Trim(),
                    nascimento = investidor.Complemento.Nascimento,
                    idInvestidor = investidor.ID
                });
            }
        }

        public void AtualizarEndereco(Investidor investidor)
        {
            var sql = @"UPDATE tbComplementoInvestidor SET
                        CEP=@cep,
                        Bairro=@bairro,
                        Cidade=@cidade,
                        Estado=@estado,
                        Logradouro=@logradouro,
                        Numero=@numero,
                        Complemento=@complemento
                        WHERE IDInvestidor=@idInvestidor";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.Execute(sql, new
                {
                    cep=investidor.Complemento.CEP.RemoveAcentos().RemoveEspacos(),
                    bairro=investidor.Complemento.Bairro.RemoveAcentos().RemoveEspacos(),
                    cidade = investidor.Complemento.Cidade.RemoveAcentos().RemoveEspacos(),
                    estado = investidor.Complemento.Estado.RemoveAcentos().RemoveEspacos(),
                    logradouro = investidor.Complemento.Logradouro.RemoveAcentos().RemoveEspacos(),
                    numero = investidor.Complemento.Numero.RemoveAcentos().RemoveEspacos(),
                    complemento = investidor.Complemento.Complemento.RemoveAcentos().RemoveEspacos(),            
                    idInvestidor = investidor.ID
                });
            }
        }

        public void AtualizarSenha(Investidor investidor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Investidor> GetAll()
        {
            var sql = @"SELECT
	                    A.ID,A.Nome,A.Email,A.CEP,A.CPFCNPJ,A.Documento,A.Logradouro,A.Numero,A.Complemento,A.Referencia,
                        A.Bairro,A.Cidade,A.UF,A.Contato1,A.Contato2,A.IDTipoPessoa as TipoPessoa,A.IDTipoDocumento,B.ID,B.Descricao,B.Sigla
                        FROM tbInvestidor as A 
                        LEFT JOIN tbTipoDocumento AS B ON B.ID=A.IDTipoDocumento";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var listaInvestidor = connection.Query<Investidor, TipoDocumento, Investidor>(
                    sql,
                    map: (investidor, tipoDocumento) =>
                    {
                        //investidor.TipoDocumento = tipoDocumento;

                        return investidor;
                    },
                    splitOn: "IDTipoDocumento");

                return listaInvestidor;
            }
        }

        public IEnumerable<TipoDocumento> GetAllTiposDocumento()
        {
            var sql = "SELECT ID,Descricao,Sigla FROM tbTipoDocumento";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var listaTipoDocumento = connection.Query<TipoDocumento>(sql);

                return listaTipoDocumento;
            }
        }

        public Investidor GetByEmail(string email)
        {
            var sql = @"SELECT ID, Nome, Celular, Email, Senha, TipoPessoa, SituacaoCadastro                    
                        FROM tbCadastroInvestidor 
                        WHERE Email=@email";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var investidor = connection.QueryFirstOrDefault<Investidor>(sql, new
                {
                    email
                }
                );
                return investidor;

            }
        }

        public Investidor GetById(int? id)
        {
            Investidor? investidor = new Investidor();
            var sql = @"SELECT A.ID, A.Nome, A.Celular, A.Email, A.Senha, A.TipoPessoa, A.SituacaoCadastro,
	                    B.IDInvestidor,
	                    B.ID,
	                    B.CPF,
	                    B.RG,
	                    B.OrgaoExpedidor,
	                    B.RazaoSocial,
	                    B.CNPJ,
	                    B.UFRG,
	                    B.Nascimento,
	                    B.CEP,
	                    B.Bairro,
	                    B.Cidade,
	                    B.Estado,
	                    B.Pais,
	                    B.Logradouro,
	                    B.Numero,
	                    B.Complemento
                    FROM tbCadastroInvestidor AS A
                    INNER JOIN tbComplementoInvestidor AS B ON B.IDInvestidor=A.ID
                    WHERE A.ID=@id";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                investidor = connection.Query<Investidor, ComplementoInvestidor, Investidor>(
                   sql,
                   map: (investidorCadastro, complemento) =>
                   {
                       investidorCadastro.Complemento = complemento;
                       return investidorCadastro;
                   },
                   new { id },
                   splitOn: "IDInvestidor").FirstOrDefault();

                return investidor!;
            }
        }

        public IEnumerable<Investidor> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var sql = "DELETE FROM tbInvestidor WHERE ID=@id";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.Execute(sql, new
                {
                    id
                });
            }
        }

        public void Update(Investidor classe)
        {
            var sql = @"UPDATE tbInvestidor
                        SET 
	                        Nome=@Nome,
	                        Email=@Email,
	                        CEP=@CEP,
	                        CPFCNPJ=@CPFCNPJ,
	                        Documento=@Documento,
	                        Logradouro=@Logradouro,
	                        Numero=@Numero,
	                        Complemento=@Complemento,
	                        Referencia=@Referencia,
	                        Bairro=@Bairro,
	                        Cidade=@Cidade,
	                        UF=@UF,
	                        Contato1=@Contato1,
	                        Contato2=@Contato2,
	                        IDTipoPessoa=@IDTipoPessoa,
	                        IDTipoDocumento=@IDTipoDocumento
	                        WHERE ID=@id";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.Execute(sql, new
                {
                    //id= classe.ID,
                    //nome=classe.Nome,
                    //email=classe.Email,
                    //cep=classe.CEP,
                    //cpfcnpj=classe.CPFCNPJ,
                    //documento=classe.Documento,
                    //logradouro=classe.Logradouro,
                    //numero=classe.Numero,
                    //complemento=classe.Complemento,
                    //referencia=classe.Referencia,
                    //bairro=classe.Bairro,
                    //cidade=classe.Cidade,
                    //uf=classe.UF,
                    //contato1=classe.Contato1,
                    //contato2=classe.Contato2,
                    //idTipoPessoa=classe.TipoPessoa,
                    //idTipoDocumento=classe.TipoDocumento.ID
                });
            }
        }

        public bool VerificarSeExisteEmailInvestidor()
        {
            var sql = @"SELECT *                    
                        FROM tbCadastroInvestidor 
                        WHERE Email=@email";


            using (var connection = _connection.Connection())
            {
                connection.Open();
                var listaInvestidor = connection.QueryFirst<Investidor>(sql);
                return listaInvestidor == null;
            }
        }

        public void ConfirmarEmail(string hash)
        {
            var sql = @"UPDATE tbCadastroInvestidor SET
                        SituacaoCadastro=1
                        WHERE HashConfirmarEmail=@hash";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.Execute(sql, new
                {
                  hash
                });
            }
        }
    }
}
