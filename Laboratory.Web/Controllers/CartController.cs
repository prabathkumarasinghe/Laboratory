using Laboratory.Web.Models;
using Laboratory.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace Laboratory.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly ITestParameterService _testParameterService;

        public CartController(ICartService cartService, IOrderService orderService, ITestParameterService testParameterService)
        {
            _cartService = cartService;
            _orderService = orderService;
            _testParameterService = testParameterService;
        }


        [Authorize]
        public async Task<IActionResult> CartIndex()
        {
            return View(await LoadCartDtoBasedOnLoggedInUser());
        }
        public async Task<IActionResult> CartEdit()
        {
			List<CartDto>? list = new();

			ResponseDto? response = await _orderService.GetAllOrder(null);

			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<CartDto>>(Convert.ToString(response.Result));
			}

			return View(list);
		}
        //  [Authorize]
        [Authorize]
        public async Task<IActionResult> OrderDetail()
        {
            return View(await LoadCartDtoBasedOnLoggedInUser());
        }

        public async Task<IActionResult> OrderUpdate(int orderId)
        {
            ResponseDto? response = await _orderService.GetOrder(orderId);

            if (response != null && response.IsSuccess)
            {
                CartHeaderDto? model = JsonConvert.DeserializeObject<CartHeaderDto>(Convert.ToString(response.Result));
				
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> OrderUpdate(CartDto testDto)
        {
            ResponseDto? response = await _orderService.UpdateOrder(testDto);

            if (response != null && response.IsSuccess)
            {

                //return RedirectToAction(nameof(TestIndex));
            }

            return View(testDto);
        }

        [Authorize]
        public async Task<IActionResult> Result()
        {
            return View(await LoadCartDtoBasedOnLoggedInUser());
        }

        [HttpPost]
        public async Task<IActionResult> Result(CartDto cartDto)
        {
            CartDto cart = await LoadCartDtoBasedOnLoggedInUser();
            cart.CartHeader.Phone = cartDto.CartHeader.Phone;
            cart.CartHeader.Email = cartDto.CartHeader.Email;
            cart.CartHeader.Name = cartDto.CartHeader.Name;
            cart.CartHeader.RefNumber = cartDto.CartHeader.RefNumber;
            cart.CartHeader.LabNumber = cartDto.CartHeader.LabNumber;
            cart.CartHeader.TotalCholesterol = cartDto.CartHeader.TotalCholesterol;
            cart.CartHeader.Triglycerides = cartDto.CartHeader.Triglycerides;
            cart.CartHeader.HDL = cartDto.CartHeader.HDL;
            cart.CartHeader.LDL = cartDto.CartHeader.LDL;
            cart.CartHeader.NonHDLChol = cartDto.CartHeader.NonHDLChol;
            cart.CartHeader.CholHDLRatio = cartDto.CartHeader.CholHDLRatio;

            var response = await _orderService.CreateOrder(cart);
            OrderHeaderDto orderHeaderDto = JsonConvert.DeserializeObject<OrderHeaderDto>(Convert.ToString(response.Result));

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Test created successfully";
                //   return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(await LoadCartDtoBasedOnLoggedInUser());
        }

        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            return View(await LoadCartDtoBasedOnLoggedInUser());
        }


        [HttpPost]
        [ActionName("Checkout")]
        public async Task<IActionResult> Checkout(CartDto cartDto)
        {
            CartDto cart = await LoadCartDtoBasedOnLoggedInUser();
            cart.CartHeader.Phone = cartDto.CartHeader.Phone;
            cart.CartHeader.Email = cartDto.CartHeader.Email;
            cart.CartHeader.Name = cartDto.CartHeader.Name;
            cart.CartHeader.RefNumber = cartDto.CartHeader.RefNumber;
            cart.CartHeader.LabNumber = cartDto.CartHeader.LabNumber;

            var response = await _orderService.CreateOrder(cart);
            OrderHeaderDto orderHeaderDto = JsonConvert.DeserializeObject<OrderHeaderDto>(Convert.ToString(response.Result));

            if (response != null && response.IsSuccess) 
            {
                TempData["success"] = "Test created successfully";
             //   return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            //{
            //    // get stripe session and redirect to stripe to place order


            //    var domain = Request.Scheme + "://" + Request.Host.Value + "/";

            //    StripeRequestDto stripeRequestDto = new()
            //    {
            //        ApprovedUrl = domain + "cart/Confirmation?orderId=" + orderHeaderDto.OrderHeaderId,
            //        CancelUrl = domain + "cart/checkout",
            //        OrderHeader = orderHeaderDto
            //    };

            //    var stripeResponse = await _orderService.CreateStripeSession(stripeRequestDto);
            //    StripeRequestDto stripeResponseResult = JsonConvert.DeserializeObject<StripeRequestDto>
            //                                (Convert.ToString(stripeResponse.Result));
            //    Response.Headers.Add("Location", stripeResponseResult.StripeSessionUrl);
            //    return new StatusCodeResult(303);

            //}
            return View(await LoadCartDtoBasedOnLoggedInUser());
        }

        //[Authorize]
        //public async Task<IActionResult> Comfirmation()
        //{
        //    return View(await LoadCartDtoBasedOnLoggedInUser());
        //}
        //[Authorize]
        //public async Task<IActionResult> TestEdit()
        //{
        //    return View(await LoadCartDtoBasedOnLoggedInUser());
        //}
        //public async Task<IActionResult> TestEdit(ParameterDto parameterDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ResponseDto? response = await _testParameterService.CreateTestParameterAsync(parameterDto);

        //        if (response != null && response.IsSuccess)
        //        {
        //            TempData["success"] = "Test created successfully";
        //            return RedirectToAction(nameof(Checkout));
        //        }
        //        else
        //        {
        //            TempData["error"] = response?.Message;
        //        }
        //    }
        //  //  return View(model);
        //    return View(await LoadCartDtoBasedOnLoggedInUser());
        //}
        //public async Task<IActionResult> Confirmation(int orderId)
        //{
        //    ResponseDto? response = await _orderService.ValidateStripeSession(orderId);
        //    if (response != null & response.IsSuccess)
        //    {

        //        OrderHeaderDto orderHeader = JsonConvert.DeserializeObject<OrderHeaderDto>(Convert.ToString(response.Result));
        //        if (orderHeader.Status == SD.Status_Approved)
        //        {
        //            return View(orderId);
        //        }
        //    }
        //    //redirect to some error page based on status
        //    return View(orderId);
        //}

        public async Task<IActionResult> Remove(int cartDetailsId)
        {
            var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            ResponseDto? response = await _cartService.RemoveFromCartAsync(cartDetailsId);
            if (response != null & response.IsSuccess)
            {
                TempData["success"] = "Cart updated successfully";
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> EmailCart(CartDto cartDto)
        //{
        //    CartDto cart = await LoadCartDtoBasedOnLoggedInUser();
        //    cart.CartHeader.Email = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Email)?.FirstOrDefault()?.Value;
        //    ResponseDto? response = await _cartService.EmailCart(cart);
        //    if (response != null & response.IsSuccess)
        //    {
        //        TempData["success"] = "Email will be processed and sent shortly.";
        //        return RedirectToAction(nameof(CartIndex));
        //    }
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> ApplyCoupon(CartDto cartDto)
        //{

        //    ResponseDto? response = await _cartService.ApplyCouponAsync(cartDto);
        //    if (response != null & response.IsSuccess)
        //    {
        //        TempData["success"] = "Cart updated successfully";
        //        return RedirectToAction(nameof(CartIndex));
        //    }
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> RemoveCoupon(CartDto cartDto)
        //{
        //    cartDto.CartHeader.CouponCode = "";
        //    ResponseDto? response = await _cartService.ApplyCouponAsync(cartDto);
        //    if (response != null & response.IsSuccess)
        //    {
        //        TempData["success"] = "Cart updated successfully";
        //        return RedirectToAction(nameof(CartIndex));
        //    }
        //    return View();
        //}


        private async Task<CartDto> LoadCartDtoBasedOnLoggedInUser()
        {
            var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            ResponseDto? response = await _cartService.GetCartByUserIdAsnyc(userId);
            if (response != null & response.IsSuccess)
            {
                CartDto cartDto = JsonConvert.DeserializeObject<CartDto>(Convert.ToString(response.Result));
                return cartDto;
            }
            return new CartDto();
        }
    }
}
