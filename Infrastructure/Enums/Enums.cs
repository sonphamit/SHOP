using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Đã đặt hàng")]
        ORDERED = 1,
        [Display(Name = "Duyệt đơn")]
        APPROVED = 2,
        [Display(Name = "Shipper đã nhận hàng")]
        SHIPMENT_PICKED_UP = 3,
        [Display(Name = "Đang giao hàng")]
        SHIPPING = 4,
        [Display(Name = "Đã giao")]
        DELIVERRED = 5
    }

    public enum OrderPaymentStatus
    {
        PAID,
        UNPAID_PAID,
    }

    public enum DeliveryCompany
    {
        [Display(Name = "Giao Hàng Nhanh")]
        GIAO_HANG_NHANH = 1,
        [Display(Name = "Giao Hàng Tiết Kiệm")]
        GIAO_HANG_TIET_KIEM = 2,
        [Display(Name = "Viettel Post")]
        VIETTEL_POST = 3,
        [Display(Name = "VIETNAM Post")]
        VN_POST = 4,
        [Display(Name = "DHL Express")]
        DHL_EXPRESS = 5
    }
}
