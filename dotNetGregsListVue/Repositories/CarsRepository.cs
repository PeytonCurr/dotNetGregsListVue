

namespace dotNetGregsListVue.Repositories;

public class CarsRepository
{
  private readonly IDbConnection _db;

  public CarsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Car CreateCar(Car carData)
  {
    string sql = @"
  INSERT INTO cars
    (make, model, imgUrl, body, price, description, creatorId)
  values
    (@make, @model, @imgUrl, @body, @price, @description, @creatorId);
  SELECT LAST_INSERT_ID()
  ;";
    int id = _db.ExecuteScalar<int>(sql, carData);
    carData.Id = id;
    return carData;
  }

  internal List<Car> GetAllCars()
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
