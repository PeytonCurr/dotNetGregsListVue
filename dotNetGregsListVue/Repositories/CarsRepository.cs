
namespace dotNetGregsListVue.Repositories;

public class CarsRepository
{
  private readonly IDbConnection _db;

  public CarsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal List<Car> GetAll()
  {
    string sql = @"
SELECT
c.*,
acct.*
FROM cars c
JOIN accounts acct ON acct.id = c.creatorId
;";
    List<Car> cars = _db.Query<Car, Profile, Car>(sql, (c, acct) =>
    {
      c.Seller = acct;
      return c;
    }).ToList();
    return cars;
  }
}
