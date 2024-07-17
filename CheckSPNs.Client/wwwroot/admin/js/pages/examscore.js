$(function () {
    'use strict'

    

    var currentPage = 1;
    var pageSize = 10;
    var isLoading = false; // Biến kiểm soát trạng thái loading
    var htmlResult = '';

    function loadData() {
        if (isLoading) return; // Nếu đang loading, không thực hiện gì cả

        isLoading = true; // Bắt đầu loading

        $.ajax({
            url: `https://localhost:5000/odata/ExamScoreOData?$skip=${(currentPage - 1) * pageSize}&$top=${pageSize}&$count=true`,
            method: 'GET',
            success: function (data) {
                if (data.value != null) {
                    $.each(data.value, function (i) {
                        htmlResult += `
                            <tr>
                                <td>${data.value[i].StudentId}</td>
                                <td>${data.value[i].Toan}</td>
                                <td>${data.value[i].NguVan}</td>
                                <td>${data.value[i].NgoaiNgu}</td>
                                <td>${data.value[i].VatLi}</td>
                                <td>${data.value[i].HoaHoc}</td>
                                <td>${data.value[i].SinhHoc}</td>
                                <td>${data.value[i].LichSu}</td>
                                <td>${data.value[i].DiaLi}</td>
                                <td>${data.value[i].Gdcd}</td>
                                <td>${data.value[i].MaNgoaiNgu}</td>
                            </tr>`;
                    })
                } else {
                    alert('Cannot load!!!');
                }

                $("#examTBody")[0].innerHTML = htmlResult;
                $("#exam-count")[0].innerHTML = data['@odata.count']
                currentPage++;
                isLoading = false;
                if (data.value.length < pageSize) {
                    $("#loadMoreBtn").hide();
                }
            },
            error: function () {
                isLoading = false;
            }
        });
    }

    loadData(); // Load dữ liệu lần đầu

    $("#loadMoreBtn").click(function () {
        loadData(); // Gọi hàm loadData khi click nút "Load More"
    });
})