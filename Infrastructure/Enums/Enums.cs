using System.ComponentModel;

namespace Infrastructure.Enums
{
    public enum OrderStatus
    {
        [Description("Đang trong giỏ hàng")]
        ORDERING = 0,
        [Description("Đã đặt hàng")]
        ORDERED = 1,
        [Description("Duyệt đơn")]
        APPROVED = 2,
        [Description("Shipper đã nhận hàng")]
        SHIPMENT_PICKED_UP = 3,
        [Description("Đang giao hàng")]
        SHIPPING = 4,
        [Description("Đã giao")]
        DELIVERRED = 5
    }

    public enum OrderPaymentStatus
    {
        PAID,
        UNPAID_PAID,
    }

    public enum DeliveryCompany
    {
        [Description("Giao Hàng Nhanh")]
        GIAO_HANG_NHANH = 0,
        [Description("Giao Hàng Tiết Kiệm")]
        GIAO_HANG_TIET_KIEM = 1,
        [Description("Viettel Post")]
        VIETTEL_POST = 2,
        [Description("Vietnam Post")]
        VN_POST = 3,
        [Description("DHL Express")]
        DHL_EXPRESS = 4
    }

    public enum UserType
    {
        [Description("Khách Hàng")]
        CUSTOMER_TYPE = 0,
        [Description("Nhân Viên")]
        EMPLOYEE_TYPE = 1,
    }

    public enum Gender
    {
        [Description("Tất cả")]
        ALL = 0,
        [Description("Nữ")]
        GIRL = 1,
        [Description("Nam")]
        BOY = 2,
    }
}
