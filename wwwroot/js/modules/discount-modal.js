// discount-modal.js - Xử lý modal giảm giá/tặng sản phẩm trong giỏ hàng
export function openDiscountModal() {
    var modal = new bootstrap.Modal(document.getElementById('discountModal'));
    $('#discount-value').val(0);
    $('#discount-reason').val('');
    $('#discount-tangkem').prop('checked', false);
    setDiscountType('percent');
    setTimeout(() => { $('#discount-value').focus(); }, 300);
    modal.show();
}

export function setDiscountType(type) {
    if (type === 'percent') {
        $('.btn-toggle-type[data-type="percent"]').addClass('btn-primary').removeClass('btn-outline-primary');
        $('.btn-toggle-type[data-type="amount"]').addClass('btn-outline-primary').removeClass('btn-primary');
        $('#discount-value').attr('max', 100).attr('step', '0.01').attr('placeholder', '0');
        $('.btn-quick-value').show();
    } else {
        $('.btn-toggle-type[data-type="amount"]').addClass('btn-primary').removeClass('btn-outline-primary');
        $('.btn-toggle-type[data-type="percent"]').addClass('btn-outline-primary').removeClass('btn-primary');
        $('#discount-value').removeAttr('max').attr('step', '1000').attr('placeholder', '0');
        $('.btn-quick-value').hide();
    }
}

export function handleDiscountSave(callback) {
    $('#btn-save-discount').on('click', function () {
        const value = parseFloat($('#discount-value').val()) || 0;
        const reason = $('#discount-reason').val().trim();
        const isTang = $('#discount-tangkem').is(':checked');
        let chietKhauPhanTram = null, chietKhauTienMat = null;
        if ($('.btn-toggle-type[data-type="percent"]').hasClass('btn-primary')) chietKhauPhanTram = value;
        else chietKhauTienMat = value;
        if (typeof callback === 'function') {
            callback({ chietKhauPhanTram, chietKhauTienMat, isTang, reason });
        }
    });
}

// Khi tích vào checkbox tặng sản phẩm, disable các input giảm giá và nút đề xuất
export function handleTangKemCheckbox() {
    $('#discount-tangkem').on('change', function () {
        var checked = $(this).is(':checked');
        $('#discount-value').prop('disabled', checked);
        $('.btn-toggle-type').prop('disabled', checked);
        $('.btn-quick-value').prop('disabled', checked);
    });
}

export function handleQuickValue() {
    $(document).on('click', '.btn-quick-value', function () {
        const value = $(this).data('value');
        $('#discount-value').val(value).focus();
    });
} 