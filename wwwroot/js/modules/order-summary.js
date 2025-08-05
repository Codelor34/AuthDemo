// order-summary.js - Tính toán tổng tiền, thành tiền sau giảm giá, cập nhật UI tổng kết hóa đơn
export function formatNumber(n) {
    return n.toLocaleString('vi-VN');
}

export function tinhThanhTienSauGiam(giamGiaHoaDon) {
    var tongTien = 0;
    $(".thanh-tien-dong").each(function () {
        var row = $(this).closest('tr');
        var isTang = row.data('tangkem') == 1;
        if (isTang) return;
        var giaGoc = parseInt(row.data('gia-goc')) || 0;
        var giaSauGiam = parseInt(row.data('gia-sau-giam')) || 0;
        var soLuong = parseInt(row.data('so-luong')) || 1;
        var thanhTien = (giaSauGiam < giaGoc ? giaSauGiam : giaGoc) * soLuong;
        tongTien += thanhTien;
    });
    // Áp dụng giảm giá hóa đơn
    var giamGia = 0;
    if (giamGiaHoaDon && giamGiaHoaDon.phanTram > 0) giamGia += tongTien * giamGiaHoaDon.phanTram / 100;
    if (giamGiaHoaDon && giamGiaHoaDon.tienMat > 0) giamGia += giamGiaHoaDon.tienMat;
    if (giamGia > tongTien) giamGia = tongTien;
    var thanhTienSauGiam = tongTien - giamGia;
    $("#tong-tien-hd").text(formatNumber(tongTien) + ' VNĐ');
    $("#giam-gia-info").text(giamGia > 0 ? `Giảm giá: -${formatNumber(Math.round(giamGia))} VNĐ` : '');
    $("#thanh-tien-sau-giam").text(formatNumber(Math.round(thanhTienSauGiam)) + ' VNĐ');
    return { tongTien, giamGia, thanhTienSauGiam };
}

// Hàm fill bảng phép tính trực quan hóa đơn
export function fillInvoiceSummary(giamGiaHoaDon, phiVanChuyen = 0) {
    let tongGiaGoc = 0;
    let tongGiamGiaSP = 0;
    let tongSoLuong = 0;
    $(".thanh-tien-dong").each(function () {
        var row = $(this).closest('tr');
        var isTang = row.data('tangkem') == 1;
        var giaGoc = parseInt(row.data('gia-goc')) || 0;
        var giaSauGiam = parseInt(row.data('gia-sau-giam')) || 0;
        var soLuong = parseInt(row.data('so-luong')) || 1;
        if (isTang) return;
        tongGiaGoc += giaGoc * soLuong;
        tongSoLuong += soLuong;
        if (giaSauGiam < giaGoc) {
            tongGiamGiaSP += (giaGoc - giaSauGiam) * soLuong;
        }
    });
    // Giảm giá hóa đơn
    let giamGiaHD = 0;
    let tongSauGiamSP = tongGiaGoc - tongGiamGiaSP;
    if (giamGiaHoaDon && giamGiaHoaDon.phanTram > 0) giamGiaHD += tongSauGiamSP * giamGiaHoaDon.phanTram / 100;
    if (giamGiaHoaDon && giamGiaHoaDon.tienMat > 0) giamGiaHD += giamGiaHoaDon.tienMat;
    if (giamGiaHD > tongSauGiamSP) giamGiaHD = tongSauGiamSP;
    // Thành tiền cuối cùng
    let thanhTien = tongSauGiamSP - giamGiaHD + (phiVanChuyen || 0);
    // Fill UI
    $("#hd-tong-gia-goc").text(formatNumber(tongGiaGoc));
    $("#hd-tong-giam-gia-sp").text(formatNumber(tongGiamGiaSP));
    $("#hd-giam-gia-hoa-don").text(formatNumber(Math.round(giamGiaHD)));
    $("#hd-phi-van-chuyen").text(formatNumber(phiVanChuyen));
    $("#hd-thanh-tien").text(formatNumber(Math.round(thanhTien)));
    return { tongGiaGoc, tongGiamGiaSP, giamGiaHD, phiVanChuyen, thanhTien };
} 