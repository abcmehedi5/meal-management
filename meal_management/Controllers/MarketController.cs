using meal_management.Data;
using meal_management.Model;
using meal_management.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace meal_management.Controllers
{
    [Route("api/meal/manager")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _responseDto;

        public MarketController(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _responseDto = new ResponseDto();
        }


        //get total sum for market and meal 
        [HttpGet]
        public ResponseDto Get()
        {

            try
            {
                IEnumerable<MarketModel> MarketList = _db.market.ToList();

                double totalDailyMarketSum = MarketList.Sum(item => item.dailyMarket);
                int totalDailyMealSum = MarketList.Sum(item => item.dailyMeal);
                double totalMealRate = totalDailyMarketSum / totalDailyMealSum;

                TotalDto totalDto = new TotalDto()
                {
                    totalMarket = totalDailyMarketSum,
                    totalMeal = totalDailyMealSum,
                    totalMealRate = totalMealRate
                };


                _responseDto.Result = totalDto;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;

            }

            return _responseDto;

        }


        //get all market items
        [HttpGet]
        [Route("market-list")]

        public ResponseDto GetMarketItems()
        {
            try
            {
                IEnumerable<MarketModel> marketList = _db.market.ToList(); // get all market items
                _responseDto.Result = marketList;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;

            }

            return _responseDto;

        }


        // post market and meal for manager 
        [HttpPost]

        public ResponseDto Post([FromBody] MarketDto market)
        {
            try
            {
                MarketModel MarketObject = new MarketModel() // make a object for meal data
                {
                    date = DateTime.Now,
                    dailyMarket = market.dailyMarket,
                    dailyMeal = market.dailyMeal,
 

                };

                _db.market.Add(MarketObject); //meals table name 
                _db.SaveChanges();
                _responseDto.Result = MarketObject;
                _responseDto.Message = "Market Added Successfull";

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;
        }


        // udpate market and meal data

        [HttpPut]
        public object Put([FromBody] MarketDto market)
        {

            try
            {
                MarketModel MarketObject = new MarketModel() // make a object for meal data
                {
                    marketId = market.marketId,
                    dailyMarket = market.dailyMarket,
                    dailyMeal = market.dailyMeal,

                };

                _db.market.Update(MarketObject); //meals table name 
                _db.SaveChanges();
                _responseDto.Result = MarketObject;
                _responseDto.Message = "Market Added Successfull";

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
        [Route("{marketId:int}")]
        public object Delete(int marketId)
        {
            try
            {
                // Retrieve the existing market record from the database
                MarketModel existingMarket = _db.market.First(_ => _.marketId == marketId);

                if (existingMarket == null)
                {
                    // If the record with the given marketId is not found, return an error
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "Market not found";
                    return _responseDto;
                }

                // Remove the existing market record from the database
                _db.market.Remove(existingMarket);
                _db.SaveChanges();

                _responseDto.Result = existingMarket;
                _responseDto.Message = "Market deleted successfully";
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
