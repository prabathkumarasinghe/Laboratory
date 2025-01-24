﻿

using Laboratory.Web.Models;

namespace Laboratory.Web.Service.IService
{
    public interface IOrderService
    {
        Task<ResponseDto?> CreateOrder(CartDto cartDto);
        Task<ResponseDto?> UpdateOrder(CartDto cartDto);
    //    Task<ResponseDto?> CreateStripeSession(StripeRequestDto stripeRequestDto);
    //    Task<ResponseDto?> ValidateStripeSession(int orderHeaderId);
        Task<ResponseDto?> GetOrder(int orderId);
        Task<ResponseDto?> GetAllOrder(string? userId);
        Task<ResponseDto?> UpdateOrderStatus(int orderId, string newStatus);
    }
}