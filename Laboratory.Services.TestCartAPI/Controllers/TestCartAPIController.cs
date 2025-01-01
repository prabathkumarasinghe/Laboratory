using AutoMapper;
using Laboratory.Services.TestCartAPI.Data;
using Laboratory.Services.TestCartAPI.Models;
using Laboratory.Services.TestCartAPI.Models.Dto;
using Laboratory.Services.TestCartAPI.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laboratory.Services.TestCartAPI.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class TestCartAPIController : ControllerBase
    {
        private ResponseDto _response;
        private IMapper _mapper;
        private readonly AppDbContext _db;
        private ITestService _testService;
      //  private ICouponService _couponService;
      //  private IMessageBus _messageBus;
      //  private IConfiguration _configuration;

        public TestCartAPIController(IMapper mapper, AppDbContext db, ITestService testService)
        {
            _mapper = mapper;
            this._response = new ResponseDto();
            _db = db;
         //   _messageBus = messageBus;
         //   _configuration = configuration;
            _testService = testService;
         //   _couponService = couponService;
        }

        [HttpGet("GetCart/{userId}")]
        public async Task<ResponseDto> GetCart(string userId)
        {
            try
            {
                CartDto cart = new()
                {
                    CartHeader = _mapper.Map<CartHeaderDto>(_db.CartHeaders.First(u => u.UserId == userId))
                };
                cart.CartDetails = _mapper.Map<IEnumerable<CartDetailsDto>>(_db.CartDetails
                    .Where(u => u.CartHeaderId == cart.CartHeader.CartHeaderId));

                IEnumerable<TestDto> testDtos = await _testService.GetTests();

                foreach (var item in cart.CartDetails)
                {
                    item.Test = testDtos.FirstOrDefault(u => u.TestId == item.TestId);
                    cart.CartHeader.CartTotal += (item.Count * item.Test.Price);
                }

                //apply coupon if any
                //if (!string.IsNullOrEmpty(cart.CartHeader.CouponCode))
                //{
                //    CouponDto coupon = await _couponService.GetCoupon(cart.CartHeader.CouponCode);
                //    if (coupon != null && cart.CartHeader.CartTotal > coupon.MinAMount)
                //    {
                //        cart.CartHeader.CartTotal -= coupon.DiscountAmount;
                //        cart.CartHeader.Discount = coupon.DiscountAmount;
                //    }
                //}

                _response.Result = cart;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        //[HttpPost("ApplyCoupon")]
        //public async Task<object> ApplyCoupon([FromBody] CartDto cartDto)
        //{
        //    try
        //    {
        //        var cartFromDb = await _db.CartHeaders.FirstAsync(u => u.UserId == cartDto.CartHeader.UserId);
        //        cartFromDb.CouponCode = cartDto.CartHeader.CouponCode;
        //        _db.CartHeaders.Update(cartFromDb);
        //        await _db.SaveChangesAsync();
        //        _response.Result = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.Message = ex.ToString();
        //    }
        //    return _response;
        //}

        //[HttpPost("RemoveCoupon")]
        //public async Task<object> RemoveCoupon([FromBody] CartDto cartDto)
        //{
        //    try
        //    {
        //        var cartFromDb = await _db.CartHeaders.FirstAsync(u => u.UserId == cartDto.CartHeader.UserId);
        //        cartFromDb.CouponCode = "";
        //        _db.CartHeaders.Update(cartFromDb);
        //        await _db.SaveChangesAsync();
        //        _response.Result = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.Message = ex.ToString();
        //    }
        //    return _response;
        //}

        //[HttpPost("EmailCartRequest")]
        //public async Task<object> EmailCartRequest([FromBody] CartDto cartDto)
        //{
        //    try
        //    {
        //        await _messageBus.PublishMessage(cartDto, _configuration.GetValue<string>("TopicAndQueueNames:EmailShoppingCartQueue"));
        //        _response.Result = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.Message = ex.ToString();
        //    }
        //    return _response;
        //}



        [HttpPost("CartUpsert")]
        public async Task<ResponseDto> CartUpsert(CartDto cartDto)
        {
            try
            {
                var cartHeaderFromDb = await _db.CartHeaders.AsNoTracking().FirstOrDefaultAsync(u => u.UserId == cartDto.CartHeader.UserId);
                if (cartHeaderFromDb == null)
                {
                    //create header and details
                    CartHeader cartHeader = _mapper.Map<CartHeader>(cartDto.CartHeader);
                    _db.CartHeaders.Add(cartHeader);
                    await _db.SaveChangesAsync();
                    cartDto.CartDetails.First().CartHeaderId = cartHeader.CartHeaderId;
                    _db.CartDetails.Add(_mapper.Map<CartDetails>(cartDto.CartDetails.First()));
                    await _db.SaveChangesAsync();

                }
                else
                {
                    var cartDetailsFromDb = await _db.CartDetails.AsNoTracking().FirstOrDefaultAsync(
                       u => u.TestId == cartDto.CartDetails.First().TestId &&
                       u.CartHeaderId == cartHeaderFromDb.CartHeaderId);

                    if (cartDetailsFromDb == null)
                    {
                        //create cartdetails
                        cartDto.CartDetails.First().CartHeaderId = cartHeaderFromDb.CartHeaderId;
                        _db.CartDetails.Add(_mapper.Map<CartDetails>(cartDto.CartDetails.First()));
                        await _db.SaveChangesAsync();
                    }
                    else
                    {
                        //update count in cart details
                        cartDto.CartDetails.First().Count += cartDetailsFromDb.Count;
                        cartDto.CartDetails.First().CartHeaderId = cartDetailsFromDb.CartHeaderId;
                        cartDto.CartDetails.First().CartDetailsId = cartDetailsFromDb.CartDetailsId;
                        _db.CartDetails.Update(_mapper.Map<CartDetails>(cartDto.CartDetails.First()));
                        await _db.SaveChangesAsync();
                    }
                    _response.Result = cartDto;
                }
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message.ToString();
                _response.IsSuccess = false;
            }
            return _response;
        }
        [HttpPost("RemoveCart")]
        public async Task<ResponseDto> RemoveCart([FromBody] int cartDetailsId)
        {
            try
            {
                CartDetails cartDetails = _db.CartDetails
                   .First(u => u.CartDetailsId == cartDetailsId);

                int totalCountofCartItem = _db.CartDetails.Where(u => u.CartHeaderId == cartDetails.CartHeaderId).Count();
                _db.CartDetails.Remove(cartDetails);
                if (totalCountofCartItem == 1)
                {
                    var cartHeaderToRemove = await _db.CartHeaders
                       .FirstOrDefaultAsync(u => u.CartHeaderId == cartDetails.CartHeaderId);

                    _db.CartHeaders.Remove(cartHeaderToRemove);
                }
                await _db.SaveChangesAsync();

                _response.Result = true;
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message.ToString();
                _response.IsSuccess = false;
            }
            return _response;
        }
    }
}
