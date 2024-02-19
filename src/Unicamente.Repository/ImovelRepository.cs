using Unicamente.Domain.Entities;
using Unicamente.Domain.Interfaces;
using Dapper;

namespace Unicamente.Repository
{
    public class ImovelRepository : IImovelRepository
    {
        private readonly IConnectionFactory _connection;

        public ImovelRepository(IConnectionFactory connection)
        {
            _connection = connection;
        }

        public int Add(Imovel classe)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Imovel> GetAll()
        {
            var sql = @"SELECT A.ID,A.Descricao,A.Metragem,A.IDTipoImovel,B.ID,B.Descricao
                    FROM tbImovel AS A LEFT JOIN tbTipoImovel AS B ON B.ID=A.IDTipoImovel";

            using (var connection = _connection.Connection())
            {
                connection.Open();
                var listaImovel = connection.Query<Imovel, TipoImovel, Imovel>(
                    sql,
                    map: (imovel, tipoImovel) =>
                    {
                        imovel.TipoImovel = tipoImovel;
                        return imovel;
                    },
                    splitOn: "IDTipoImovel");


                return listaImovel;
            }
        }

        public Imovel GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Imovel> GetByName(string texto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Imovel classe)
        {
            throw new NotImplementedException();
        }
    }

}
