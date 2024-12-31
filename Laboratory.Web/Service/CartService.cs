using Laboratory.Web.Models;
using Laboratory.Web.Service.IService;
using Laboratory.Web.Utility;

namespace Laboratory.Web.Service
{
    public class CartService : ICartService
    {

        private readonly IBaseService _baseService;
        public CartService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        //public async Task<ResponseDto?> ApplyCouponAsync(CartDto cartDto)
        //{
        //    return await _baseService.SendAsync(new RequestDto()
        //    {
        //        ApiType = SD.ApiType.POST,
        //        Data = cartDto,
        //        Url = SD.TestCartAPIBase + "/api/cart/ApplyCoupon"
        //    });
        //}

        //public async Task<ResponseDto?> EmailCart(CartDto cartDto)
        //{
        //    return await _baseService.SendAsync(new RequestDto()
        //    {
        //        ApiType = SD.ApiType.POST,
        //        Data = cartDto,
        //        Url = SD.ShoppingCartAPIBase + "/api/cart/EmailCartRequest"
        //    });
        //}

        public async Task<ResponseDto?> GetCartByUserIdAsnyc(string userId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.TestCartAPIBase + "/api/cart/GetCart/" + userId
            });
        }


        public async Task<ResponseDto?> RemoveFromCartAsync(int cartDetailsId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDetailsId,
                Url = SD.TestCartAPIBase + "/api/cart/RemoveCart"
            });
        }


        public async Task<ResponseDto?> UpsertCartAsync(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.TestCartAPIBase + "/api/cart/CartUpsert"
            });
        }
    }
}
