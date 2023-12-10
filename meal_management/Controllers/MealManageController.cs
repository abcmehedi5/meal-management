using meal_management.Data;
using meal_management.Model;
using meal_management.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace meal_management.Controllers
{
    [Route("api/meal")]
    [ApiController]
    public class MealManageController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _responseDto;

        public MealManageController(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _responseDto = new ResponseDto();
        }
        [HttpGet]
        public ResponseDto Get()
        {

            try
            {
                //get all user items
                IEnumerable<MealManageModel> MealList = _db.meals.ToList();
                // calculation total meal and total sum from market database
                IEnumerable<MarketModel> MarketList = _db.market.ToList();
                double totalDailyMarketSum = MarketList.Sum(item => item.dailyMarket);
                int totalDailyMealSum = MarketList.Sum(item => item.dailyMeal);
                double totalMealRate = totalDailyMarketSum / totalDailyMealSum;
                var mealItemList = new List<MealDto>();
                foreach (var item in MealList)
                {
                    var data = new MealDto
                    {
                        id = item.id,
                        name = item.name,
                        email = item.email,
                        diposit = item.diposit,
                        meal = item.meal,
                        mealRate = Math.Round(totalMealRate),
                        totalCost = Math.Round(item.meal * totalMealRate),
                        due = Math.Round(item.diposit < (item.meal * totalMealRate) ? (item.meal * totalMealRate) - item.diposit : 0),
                        Refund = Math.Round(item.diposit > (item.meal * totalMealRate) ? item.diposit - (item.meal * totalMealRate) : 0)

                    };

                    mealItemList.Add(data);

                }

                _responseDto.Result = mealItemList;



            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;

            }

            return _responseDto;

        }



        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                // get single meal data
                MealManageModel meal = _db.meals.First(_ => _.id == id);

                // calculation total meal and total sum from market database
                IEnumerable<MarketModel> MarketList = _db.market.ToList();
                double totalDailyMarketSum = MarketList.Sum(item => item.dailyMarket);
                int totalDailyMealSum = MarketList.Sum(item => item.dailyMeal);
                double totalMealRate = totalDailyMarketSum / totalDailyMealSum;

                //meal dto object
                MealDto mealDto = new MealDto()
                {
                    id = meal.id,
                    name = meal.name,
                    email = meal.email,
                    diposit = meal.diposit,
                    meal = meal.meal,
                    mealRate = Math.Round(totalMealRate),
                    totalCost = Math.Round(meal.meal * totalMealRate),
                    due = Math.Round(meal.diposit < (meal.meal * totalMealRate) ? (meal.meal * totalMealRate) - meal.diposit : 0),
                    Refund = Math.Round(meal.diposit > (meal.meal * totalMealRate) ? meal.diposit - (meal.meal * totalMealRate) : 0)

                };


                _responseDto.Result = mealDto;

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] MealDto meal)
        {
            try
            {
                MealManageModel MealObject = new MealManageModel() // make a object for meal data
                {
                    email = meal.email,
                    name = meal.name,
                    meal = meal.meal,
                    diposit = meal.diposit,
                };

                _db.meals.Add(MealObject); //meals table name 
                _db.SaveChanges();
                _responseDto.Result = MealObject;
                _responseDto.Message = "Meal Added Successfull";

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;
        }


        // delete market and meal data
        [HttpDelete]
        [Route("{id:int}")]
        public object Delete(int id)
        {
            try
            {
                // Retrieve the existing market record from the database
                MealManageModel existingUser = _db.meals.First(_ => _.id == id);

                if (existingUser == null)
                {
                    // If the record with the given marketId is not found, return an error
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "User not found";
                    return _responseDto;
                }

                // Remove the existing market record from the database
                _db.meals.Remove(existingUser);
                _db.SaveChanges();

                _responseDto.Result = existingUser;
                _responseDto.Message = "User deleted successfully";
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;
        }



    }
}
