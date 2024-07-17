// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('.main-tabs-head li').click(function () {
    var tab_id = $(this).attr('data-tab');
    if ($("#" + tab_id).hasClass('current')) {
        $("#" + tab_id).removeClass('current');
        $(this).removeClass('current');
        return;
    }
    $('.main-tabs-head li').removeClass('current');
    $('.main-tabs-content li.tab-content').removeClass('current');
    $(this).addClass('current');
    $("#" + tab_id).addClass('current');
})

$('#getExamScore').submit(function (e) {
    // don't submit form yet
    e.preventDefault();
    var sbd = $('#txtSbd').val();
    if (sbd == '') {
        alert('Vui lòng nhập số báo danh');
    } else {
    $.ajax({
        url: "https://localhost:5000/api/ExamScores/" + sbd,
        type: 'get',
        contentType: "application/json",
        success: function (item) {
            console.log(item);
            var htmlResult = '';
            if (item.value != null) {
                htmlResult += `
            <div class="resultSearch_left">
                <div class="resultSearch_left-sbd">
                    <p>Số báo danh</p>
                    <p class="font-bold">${item.value.studentId}</p>
                </div>
                <div class="resultSearch_left-info">
                    <p class="edu-institution">Sở GD&amp;ĐT ${item.value.provinceCity}</p>
                </div>
            </div>
            <div class="resultSearch_right">
                <table>
                    <thead>
                        <tr>
                            <th>Môn</th>
                            <th>Điểm</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Toán</td>
                            <td>${item.value.toan}</td>
                        </tr>
                        <tr>
                            <td>Văn</td>
                            <td>${item.value.nguVan}</td>
                        </tr>
                        <tr>
                            <td>Ngoại ngữ</td>
                            <td>${item.value.ngoaiNgu}</td>
                        </tr>
                        <tr>
                            <td>Vật lí</td>
                            <td>${item.value.vatLi}</td>
                        </tr>
                        <tr>
                            <td>Hoá học</td>
                            <td>${item.value.hoaHoc}</td>
                        </tr>
                        <tr>
                            <td>Sinh học</td>
                            <td>${item.value.sinhHoc}</td>
                        </tr>
                        <tr>
                            <td>Sử</td>
                            <td>${item.value.lichSu}</td>
                        </tr>
                        <tr>
                            <td>Địa</td>
                            <td>${item.value.diaLi}</td>
                        </tr>
                        <tr>
                            <td>GDCD</td>
                            <td>${item.value.gdcd}</td>
                        </tr>
                    </tbody>
                </table>
            </div>`;
            } else {
                alert('Số báo danh không tồn tại!!!');
            }
            $('#ShowContent').html(htmlResult);
        },
        error: function (err) {
            console.log(err.responseText);
        },
    });
    }
});


$('.vote-content .btn').on('click', function () {
    var $this = $(this);
    $.ajax({
        type: 'POST',
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: { reportEnum: $(this).data('value') },
        success: function (searchPhone) {
            var value = parseInt($this.find('.report-value').text()) + 1;
            $this.find('.report-value').text(value);
            $('.vote-content .btn').addClass('disabled');
            var negative = parseInt($('.negative-value').text());
            var positive = parseInt($('.positive-value').text());
            if (negative > positive) {
                $(".result-text").html(`<span class="alert-danger rate-alert">Tiêu cực</span>`);
            } else if (negative < positive) {
                $(".result-text").html(`<span class="alert-success rate-alert">Tích cực</span>`);
            } else {
                $(".result-text").html(`<span class="alert-warning rate-alert">Không xác định</span>`);
            }
        },
        error: function (err) {
            alert('Đã có lỗi xảy ra!!!');
            console.log(err.responseText);
        }
    })
});
