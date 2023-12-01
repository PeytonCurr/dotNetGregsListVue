


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

  internal List<Car> GetAllCars()
  {
    List<Car> cars = _repo.GetAllCars();
    return cars;
  }

  internal Car GetCarById(int carId)
  {
    Car car = _repo.GetCarById(carId);
    if (car == null) throw new Exception($"The Car you are trying to get, with the ID: {carId}, does not exist!");
    return car;
  }
}
