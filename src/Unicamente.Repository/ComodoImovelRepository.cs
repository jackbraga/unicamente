using Dapper;
using Unicamente.Domain.Entities;
using Unicamente.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicamente.Repository
{
    public class ComodoImovelRepository : IComodoImovelRepository
    {

        private readonly IConnectionFactory _connection;

        public ComodoImovelRepository(IConnectionFactory connection)
        {
            _connection = connection;
        }

        public int Add(ComodoImovel classe)
        {
            var sql = "INSERT INTO tbComodoImovel (IDImovel,IDComodo,Quantidade) VALUES(@idImovel, @idComodo,@quantidade)";

            using (var connection = _connection.Connection())
            {
                connection.Open();

                var id = connection.ExecuteScalar<int>(sql, new
                {
                    idImovel = classe.Imovel.ID,
                    idComodo = classe.Comodo.ID,
                    quantidade = classe.Quantidade
                });
                return id;
            }

        }

        public IEnumerable<ComodoImovel> GetAll()
        {
            var sql = @"SELECT A.ID, A.Quantidade,A.IDComodo,B.ID,B.DESCRICAO,A.IDImovel,C.ID,C.DESCRICAO, C.Metragem,C.IDTipoImovel,D.ID, D.Descricao 
                        FROM tbComodoImovel AS A LEFT JOIN tbComodo AS B ON B.ID=A.IDComodo
                        LEFT JOIN tbImovel AS C ON C.ID=A.IDImovel
                        LEFT JOIN tbTipoImovel AS D ON D.ID=C.IDTipoImovel";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var listaComodoImovel = connection.Query<ComodoImovel, Comodo, Imovel,TipoImovel,ComodoImovel>(
                    sql,
                    map: (comodoImovel, comodo,imovel, tipoImovel) =>
                    {
                        comodoImovel.Comodo = comodo;
                        imovel.TipoImovel = tipoImovel;
                        comodoImovel.Imovel = imovel;
                        return comodoImovel;
                    },
                    splitOn: "IDComodo,IDImovel,IDTipoImovel");


                return listaComodoImovel;
            }
        }

        public ComodoImovel GetById(int? id)
        {
            var sql = @"SELECT A.ID, A.Quantidade,A.IDComodo,B.ID,B.DESCRICAO,A.IDImovel,C.ID,C.DESCRICAO, C.Metragem,C.IDTipoImovel,D.ID, D.Descricao 
                        FROM tbComodoImovel AS A LEFT JOIN tbComodo AS B ON B.ID=A.IDComodo
                        LEFT JOIN tbImovel AS C ON C.ID=A.IDImovel
                        LEFT JOIN tbTipoImovel AS D ON D.ID=C.IDTipoImovel WHERE A.ID=@id";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var listaComodoImovel = connection.Query<ComodoImovel, Comodo, Imovel, TipoImovel, ComodoImovel>(
                    sql,
                    map: (comodoImovel, comodo, imovel, tipoImovel) =>
                    {
                        comodoImovel.Comodo = comodo;
                        imovel.TipoImovel = tipoImovel;
                        comodoImovel.Imovel = imovel;
                        return comodoImovel;
                    },
                    new { id = id },
                    splitOn: "IDComodo,IDImovel,IDTipoImovel");


                return listaComodoImovel.FirstOrDefault();
            }
        }

        public IEnumerable<ComodoImovel> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var sql = "DELETE FROM tbComodoImovel WHERE ID=@id";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.Execute(sql, new
                {
                    id
                });
            }
        }

        public void Update(ComodoImovel classe)
        {
            var sql = "UPDATE tbComodoImovel SET IDImovel=@idImovel, IDComodo=@idComodo, Quantidade=@quantidade WHERE ID=@id";
            using (var connection = _connection.Connection())
            {
                connection.Open();
                connection.Execute(sql, new
                {
                    id = classe.ID,
                    quantidade = classe.Quantidade,
                    idImovel = classe.Imovel.ID,
                    idComodo = classe.Comodo.ID

                });
            }
        }
    }
}
