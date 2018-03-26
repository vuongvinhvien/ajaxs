var homeController = {
    init: function () {
        homeController.LoadData();
        homeController.registerEvent();
    },
    registerEvent: function () {
        $('.txtSalary').off('keypress').on('keypress', function (e) {
            if (e.which == 13) {
                var id = $(this).data('id');
                var value = $(this).val();
                
                homeController.updateSalary(id, value);
            }
        });
    },
    updateSalary: function (id, value) {
        var data = {
            Id: id,
            Salary: value
        };

        $.ajax({
            url:'/Home/Update',
            type: 'POST',
            dataType:'json',
            data: {model: JSON.stringify(data)},
            success: function (response) {
                if (response.status) {
                    alert('Update successed');
                }
                else {
                    alert('Update failed');
                }

            }
        })
    },

    LoadData: function () {
        $.ajax({
            url: '/Home/LoadData',
            type: 'Get',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            Id: item.Id,
                            Name: item.Name,
                            Salary: item.Salary,
                            Status: item.Status == true ? "<span class=\"label label-success\">Active</span>" : "<span class=\"label label-danger\">Locked</span>"

                        });
                    });
                    $('#tblData').html(html);
                    homeController.registerEvent();
                }
            }
        })
    }
}
homeController.init();