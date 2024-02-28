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
    public class VegetalRepository : IVegetalRepository
    {
        private readonly IConnectionFactory _connection;

        public VegetalRepository(IConnectionFactory connection)
        {
            _connection = connection;
        }
        public int Add(Vegetal classe)
        {
            var sql = @"INSERT INTO tbVegetal(Descricao,MestrePreparo,DataPreparo,Imagem,IDMariri,IDChacrona)
                        OUTPUT INSERTED.ID
                        VALUES(@descricao,@mpreparo,@datapreparo,@imagem,@idMariri,@idChacrona);"
            ;

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var id = connection.ExecuteScalar<int>(sql, new
                {
                    descricao = classe.Descricao.RemoveAcentos().RemoveEspacos().ToUpper(),
                    mpreparo = classe.MestrePreparo.RemoveAcentos().RemoveEspacos().ToUpper(),
                    datapreparo = classe.DataPreparo,
                    imagem = classe.Imagem,
                    idMariri = classe.Mariri.ID,
                    idChacrona = classe.Chacrona.ID,
                });
                return id;
            }
        }

        public IEnumerable<Vegetal> GetAll()
        {
            //var sql = @"SELECT ID, Descricao, MestrePreparo, Imagem,IDMariri, ,IDChacrona
            //            FROM tbVegetal"
            var sql =
            @"SELECT 
            A.ID,A.Descricao,A.MestrePreparo,A.DataPreparo,A.Observacao,A.Imagem,
            B.ID AS IDMariri, B.ID,B.Descricao,
            C.ID as IDChacrona,C.ID,C.Descricao
            FROM tbVegetal AS A
            INNER JOIN tbMariri AS B ON B.ID=A.IDMariri
            LEFT JOIN tbChacrona AS C ON C.ID=A.IDChacrona"
            ;

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var lista = connection.Query<Vegetal, Mariri, Chacrona, Vegetal>(
                    sql,
                    map: (vegetal, mariri, chacrona) =>
                    {
                        vegetal.Mariri = mariri;
                        vegetal.Mariri = mariri;
                        vegetal.Chacrona = chacrona;
                        vegetal.Chacrona = chacrona;
                        return vegetal;
                    },
                    splitOn: "IDMariri,IDChacrona"
                    );

                return lista;
            }
        }

        public Vegetal GetById(int? id)
        {
            //var sql = @"SELECT ID, Descricao, MestrePreparo, Imagem,IDMariri, ,IDChacrona
            //            FROM tbVegetal"
            var sql =
            @"SELECT 
            A.ID,A.Descricao,A.MestrePreparo,A.DataPreparo,A.Observacao,A.Imagem,
            B.ID AS IDMariri, B.ID,B.Descricao,
            C.ID as IDChacrona,C.ID,C.Descricao
            FROM tbVegetal AS A
            INNER JOIN tbMariri AS B ON B.ID=A.IDMariri
            LEFT JOIN tbChacrona AS C ON C.ID=A.IDChacrona WHERE A.ID=@id"
            ;

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var vegetal = connection.Query<Vegetal, Mariri, Chacrona, Vegetal>(
                    sql, 
                    map: (vegetal, mariri, chacrona) =>
                    {
                        vegetal.Mariri = mariri;
                        vegetal.Mariri = mariri;
                        vegetal.Chacrona = chacrona;
                        vegetal.Chacrona = chacrona;
                        return vegetal;
                    },
                    new { id},
                    splitOn: "IDMariri,IDChacrona"
                    ).FirstOrDefault();

                return vegetal;
            }
        }

        public IEnumerable<Vegetal> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var sql = @"DELETE FROM tbVegetal WHERE ID=@id";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.ExecuteScalar(sql, new
                {
                    id
                });
            }
        }

        public void Update(Vegetal classe)
        {
            var sql = @"UPDATE tbVegetal
                        SET 
	                        Descricao=@descricao,
	                        MestrePreparo=@mpreparo,
	                        DataPreparo=@data,
	                        Imagem=@imagem,
	                        IDMariri=@idMariri,
	                        IDChacrona=@idChacrona,
	                        WHERE ID=@id";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.Execute(sql, new
                {
                    descricao = classe.Descricao.RemoveAcentos().RemoveEspacos().ToUpper(),
                    mpreparo = classe.MestrePreparo.RemoveAcentos().RemoveEspacos().ToUpper(),
                    data = classe.DataPreparo,
                    imagem = classe.Imagem,
                    idMariri = classe.Mariri.ID,
                    idChacrona = classe.Chacrona.ID,
                    id = classe.ID
                });
            }
        }
    }
}
