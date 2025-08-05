// order-discount-modal.js - Xử lý modal giảm giá hóa đơn
export function openOrderDiscountModal() {
    var modal = new bootstrap.Modal(document.getElementById('giamgiaModal'));
    $('#modal-giamgia-value').val(0);
    $('#modal-lydo-giamgia').val('');
    setOrderDiscountType('percent');
    setTimeout(() => { $('#modal-giamgia-value').focus(); }, 300);
    modal.show();
}

export function setOrderDiscountType(type) {
    if (type === 'percent') {
        $('.btn-toggle-type-giamgia[data-type="percent"]').addClass('btn-primary').removeClass('btn-outline-primary');
        $('.btn-toggle-type-giamgia[data-type="amount"]').addClass('btn-outline-primary').removeClass('btn-primary');
        $('#modal-giamgia-value').attr('max', 100).attr('step', '0.01').attr('placeholder', '0');
        $('.btn-quick-value-giamgia').show();
    } else {
        $('.btn-toggle-type-giamgia[data-type="amount"]').addClass('btn-primary').removeClass('btn-outline-primary');
        $('.btn-toggle-type-giamgia[data-type="percent"]').addClass('btn-outline-primary').removeClass('btn-primary');
        $('#modal-giamgia-value').removeAttr('max').attr('step', '1000').attr('placeholder', '0');
        $('.btn-quick-value-giamgia').hide();
    }
}

export function handleOrderDiscountSave(callback) {
    $('#btn-save-giamgia').on('click', function () {
        let phanTram = 0, tienMat = 0;
        const value = parseFloat($('#modal-giamgia-value').val()) || 0;
        if ($('.btn-toggle-type-giamgia[data-type="percent"]').hasClass('btn-primary')) phanTram = value;
        else tienMat = value;
        const lyDo = $('#modal-lydo-giamgia').val().trim();
        if (typeof callback === 'function') {
            callback({ phanTram, tienMat, lyDo });
        }
    });
}
// Đề xuất nhanh cho giảm giá hóa đơn
export function handleOrderDiscountQuickValue() {
    $(document).on('click', '.btn-quick-value-giamgia', function () {
        $('#modal-giamgia-value').val($(this).data('value'));
    });
} 