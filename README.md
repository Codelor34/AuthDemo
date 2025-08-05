# DATN Lor

## Giới thiệu dự án

**DATN Lor** là hệ thống quản lý bán hàng thời trang, hỗ trợ quản lý sản phẩm, hóa đơn, người dùng, báo cáo và nhiều chức năng khác dành cho quản trị viên và người dùng cuối. Dự án được phát triển trên nền tảng ASP.NET Core MVC, sử dụng Entity Framework Core để quản lý dữ liệu.

---

## Các chức năng nổi bật

### 1. Quản lý sản phẩm
- Thêm, sửa, xóa, xem danh sách sản phẩm
- Quản lý chi tiết sản phẩm: màu sắc, kích thước, chất liệu, hãng sản xuất, hình ảnh sản phẩm
- Quản lý tồn kho, cập nhật số lượng

### 2. Quản lý hóa đơn
- Tạo hóa đơn bán hàng
- Xem, chỉnh sửa, cập nhật trạng thái hóa đơn
- Quản lý chi tiết hóa đơn (sản phẩm, số lượng, giá...)

### 3. Quản lý người dùng
- Đăng ký, đăng nhập, phân quyền người dùng (Admin, Nhân viên, Khách hàng)
- Quản lý thông tin tài khoản, trạng thái hoạt động

### 4. Quản lý báo cáo
- Thống kê doanh thu, sản phẩm bán chạy, tồn kho
- Xuất báo cáo theo thời gian, theo sản phẩm

### 5. Giao diện quản trị viên (Admin)
- Giao diện riêng cho admin với các chức năng quản lý nâng cao
- Quản lý danh mục: Chất liệu, Màu sắc, Hãng sản xuất, Size, Sản phẩm, Người dùng, Hóa đơn

### 6. Giao diện người dùng
- Giao diện thân thiện, dễ sử dụng cho cả admin và người dùng cuối
- Đăng nhập, đăng ký, xem sản phẩm, đặt hàng

---

## Hướng dẫn cài đặt & sử dụng

### 1. Yêu cầu hệ thống
- .NET 6.0 SDK trở lên
- SQL Server (hoặc SQL Express)
- Visual Studio 2022 hoặc IDE hỗ trợ .NET

### 2. Cài đặt

#### Bước 1: Clone dự án
```bash
git clone <link-repo>
```

#### Bước 2: Cấu hình chuỗi kết nối
- Mở file `appsettings.json` hoặc `appsettings.Development.json`
- Sửa lại chuỗi kết nối cho phù hợp với SQL Server của bạn:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=DATNLor;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

#### Bước 3: Khởi tạo database
- Mở terminal tại thư mục dự án, chạy:
```bash
dotnet ef migrations add TenMigration
```

```bash
dotnet ef database update
```

#### Bước 4: Chạy ứng dụng
- Sử dụng Visual Studio: Nhấn F5 hoặc chọn "Start"
- Hoặc dùng terminal:
```bash
dotnet run
```

#### Bước 5: Truy cập ứng dụng
- Mở trình duyệt và truy cập: `http://localhost:5000` (hoặc cổng được chỉ định trong cấu hình)

### 3. Tài khoản mặc định
- Tài khoản admin mặc định :
  - Username: `admin`
  - Password: `123456`
  *(Có thể thay đổi trong database hoặc khi seed dữ liệu)*

---

## Cấu trúc thư mục chính

- `Areas/Admin/` : Chức năng quản trị viên (Controllers, Services, Views)
- `Controllers/` : Controller cho các chức năng chung
- `Models/` : Định nghĩa các entity, model dữ liệu, cấu hình entity
- `Views/` : Giao diện người dùng (Admin, User)
- `wwwroot/` : Tài nguyên tĩnh (CSS, JS, hình ảnh)
- `Data/` : Cấu hình DbContext
- `Migrations/` : Lưu trữ các migration của Entity Framework

---

## Đóng góp

Nếu bạn muốn đóng góp cho dự án, hãy tạo pull request hoặc liên hệ trực tiếp với quản trị viên dự án.

1. Fork repository
2. Tạo branch mới cho tính năng/sửa lỗi
3. Commit và push lên branch của bạn
4. Tạo pull request để được review

---

## Liên hệ

- Email: [your-email@example.com]
- Facebook: [link-facebook]

---

Cảm ơn bạn đã quan tâm và sử dụng hệ thống DATN Lor! 