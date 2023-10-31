using RestaurantReservation.Db.Entities;
using System.Security.Cryptography;

namespace RestaurantReservation.Db.IRepositories
{
    public interface ITableRepository : IEntityRepository<Table, int>

    {
    }
}