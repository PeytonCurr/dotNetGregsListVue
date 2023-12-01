

namespace dotNetGregsListVue.Services;

public class CarsService
{
  private readonly CarsRepository _repo;

  public CarsService(CarsRepository repo)
  {
    _repo = repo;
  }

  internal Car CreateCar(Car carData)
  {
    Car car = _repo.CreateCar(carData);
    return car;
  }

  internal List<Car> GetAll()
  {
    List<Car> cars = _repo.GetAll();
    return cars;
  }
}
