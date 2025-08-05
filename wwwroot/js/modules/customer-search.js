// customer-search.js - Xử lý tìm kiếm và chọn khách hàng
export function searchCustomer(keyword, callback) {
    $.get('/Admin/BanHangTaiQuay/SearchKhachHang', { keyword: keyword }, function (data) {
        if (typeof callback === 'function') {
            callback(data);
        }
    });
}

export function renderCustomerDropdown(data) {
    if (data && data.length > 0) {
        let html = '';
        data.forEach(function (kh) {
            html += `<button type="button" class="dropdown-item" data-id="${kh.userID}" data-diachi="${kh.diaChi || ''}">
                <div><strong>${kh.hoTen || kh.tenDangNhap}</strong> <span class="text-muted ms-2">${kh.soDienThoai || ''}</span></div>
                <div class="text-muted small">${kh.email || ''}</div>
            </button>`;
        });
        $('#dropdown-khachhang').html(html).addClass('show');
    } else {
        $('#dropdown-khachhang').html('<div class="dropdown-item text-muted">Không tìm thấy khách hàng</div>').addClass('show');
    }
}

export function selectCustomer($item) {
    var userID = $item.data('id');
    var ten = $item.find('strong').text();
    var sdt = $item.find('.text-muted.ms-2').text();
    var email = $item.find('.text-muted.small').first().text();
    var diachi = $item.data('diachi') || '';
    $('#search-khachhang').val(ten);
    $('#selected-khachhang-id').val(userID);
    $('#nguoinhan-ten').val(ten);
    $('#nguoinhan-sdt').val(sdt);
    $('#nguoinhan-email').val(email);
    $('#nguoinhan-diachi').val(diachi);
    $('#dropdown-khachhang').removeClass('show').empty();
} 