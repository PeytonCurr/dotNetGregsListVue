namespace dotNetGregsListVue.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
  private readonly Auth0Provider _auth;
  private readonly CarsService _carsService;

  public CarsController(Auth0Provider auth, CarsService carsService)
  {
    _auth = auth;
    _carsService = carsService;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Car>> CreateCar([FromBody] Car carData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      carData.CreatorId = userInfo.Id;
      Car car = _carsService.CreateCar(carData);
      car.Seller = userInfo;
      return Ok(car);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<Car>> GetAllCars()
  {
    try
    {
      List<Car> cars = _carsService.GetAllCars();
      return Ok(cars);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{carId}")]
  public ActionResult<Car> GetCarById(int carId)
  {
    try
    {
      Car car = _carsService.GetCarById(carId);
      return Ok(car);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
