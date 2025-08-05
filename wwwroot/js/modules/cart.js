// cart.js - Xử lý logic giỏ hàng
export function tinhThanhTienDong() {
    $(".thanh-tien-dong").each(function () {
        var row = $(this).closest('tr');
        var giaGoc = parseInt(row.data('gia-goc')) || 0;
        var giaSauGiam = parseInt(row.data('gia-sau-giam')) || 0;
        var soLuong = parseInt(row.data('so-luong')) || 1;
        var isTang = row.data('tangkem') == 1;
        var html = '';
        if (isTang) {
            html = '<span class="badge bg-success ms-2" style="font-size: 0.95em;">🎁 Tặng</span> <span class="text-danger fw-bold">0 VNĐ</span>';
        } else if (giaSauGiam < giaGoc) {
            var tongGoc = giaGoc * soLuong;
            var tongSauGiam = giaSauGiam * soLuong;
            html = '<span style="color:#888; font-size:0.95em; text-decoration:line-through;">' + tongGoc.toLocaleString('vi-VN') + '</span>';
            html += '<span class="fw-bold text-danger" style="font-size:1em;"> ' + tongSauGiam.toLocaleString('vi-VN') + ' VNĐ</span>';
        } else {
            var tong = giaGoc * soLuong;
            html = '<span class="fw-bold text-danger">' + tong.toLocaleString('vi-VN') + ' VNĐ</span>';
        }
        $(this).html(html);
    });
}

export function tinhTongTienGioHang() {
    var tongGoc = 0;
    var tongSauGiam = 0;
    var coGiamGia = false;
    $(".thanh-tien-dong").each(function () {
        var row = $(this).closest('tr');
        var isTang = row.data('tangkem') == 1;
        if (isTang) return;
        var giaGoc = parseInt(row.data('gia-goc')) || 0;
        var giaSauGiam = parseInt(row.data('gia-sau-giam')) || 0;
        var soLuong = parseInt(row.data('so-luong')) || 1;
        tongGoc += giaGoc * soLuong;
        tongSauGiam += (giaSauGiam < giaGoc ? giaSauGiam : giaGoc) * soLuong;
        if (giaSauGiam < giaGoc) coGiamGia = true;
    });
    var html = '';
    if (coGiamGia && tongSauGiam < tongGoc) {
        html = '<span style="color:#888; font-size:0.95em; text-decoration:line-through;">' + tongGoc.toLocaleString('vi-VN') + '</span> ';
        html += '<span class="fw-bold text-danger" style="font-size:1em;">' + tongSauGiam.toLocaleString('vi-VN') + ' VNĐ</span>';
    } else {
        html = '<span class="fw-bold text-danger" style="font-size:1em;">' + tongGoc.toLocaleString('vi-VN') + ' VNĐ</span>';
    }
    $("#tong-tien-giohang").html(html);
}

