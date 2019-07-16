;$(function () {
    getList();
});

$("#add").click(function () {
    add();
    return false;
});
$("#completed").click(function () {
    completed();
    return false;
});
$("#active").click(function () {
    active();
    return false;
});
$("#all").click(function () {
    getList();
    return false;
});

$("#clean").click(function () {
    clean();
    return false;
});

$(document).on('click', '.change', function () {
    let statusId = $(this).attr('data-id');
    change(statusId);
    return false;
});

$(document).on('click', '.cancel', function () {
    let cancelId = $(this).attr('data-id');
    cancel(cancelId);
    return false;
});


function getList() {
    $.ajax
        ({
            url: '/JQueryToDo/GetList/',
            type: 'get',
            success: function (data) {
                var c = JSON.parse(data);
                $('#todolist table').empty();
                $('#message_table').append('<tr><td><font color="blue">Status</font></td>' + '<td><font color="blue">Subject</font></td>' + '<td><font color="blue">Action</font></td></tr>');
                $.each(c, function (id, item) {
                    if (item.status == true) {
                        $('#message_table').append('<tr><td>' + '<input type=checkbox checked/>' + '</td><td><STRIKE>' + item.subject + "</STRIKE></td>" + '<td><button class="change" data-id="' + item.id + '"> Change Status </button><button class="cancel" data-id = "' + item.id + '"> Delete</button > </td></tr>');
                    }
                    else {
                        $('#message_table').append('<tr><td>' + '<input type=checkbox />' + '</td><td>' + item.subject + '</td><td><button class="change" data-id="' + item.id + '"> Change Status </button><button class="cancel" data-id ="' + item.id + '"> Delete</button > </td></tr>');
                    }
                })
            }
        });
}
function add() {
    var subject = $("#input").val();
    $.ajax({
        url: '/JQueryToDo/Add/',
        type: 'post',
        data: { "input": subject },
        success: function () {
            getList();
        }
    });
}
function completed() {
    $.ajax({
        url: '/JQueryToDo/Completed/',
        type: 'get',
        success: function (data) {
            var c = JSON.parse(data);
            $('#todolist tr').empty();
            $('#message_table').append('<tr><td><font color="blue">Status</font></td>' + '<td><font color="blue">Subject</font></td>' + '<td><font color="blue">Action</font></td></tr>');
            $.each(c, function (id, item) {
                if (item.status == true) {
                    $('#message_table').append('<tr><td>' + '<input type=checkbox checked/>' + '</td><td><STRIKE>' + item.subject + '</STRIKE></td><td><button data-id="' + item.id + '"> Change Status </button><button class="cancel" data-id = "' + item.id + '"> Delete</button > </td></tr>');
                }
            })
        }
    });
}
function active() {
    $.ajax
        ({
            url: '/JQueryToDo/Active/',
            type: 'get',
            success: function (data) {
                var c = JSON.parse(data);
                $('#todolist tr').empty();
                $('#message_table').append('<tr><td><font color="blue">Status</font></td>' + '<td><font color="blue">Subject</font></td>' + '<td><font color="blue">Action</font></td></tr>');
                $.each(c, function (id, item) {
                    if (item.status == false) {
                        $('#message_table').append('<tr><td>' + '<input type=checkbox />' + '</td><td>' + item.subject + '</td><td><button  data-id="' + item.id + '">  Change Status </button><button class="cancel" data-id = "' + item.id + '"> Delete</button > </td></tr>');
                    }
                })
            }
        });
}
function clean() {
    $.ajax({
        url: '/JQueryToDo/Clean/',
        type: 'get',
        success: function () {
            getList();
        }
    });
}
function change(statusId) {
    $.ajax({
        url: '/JQueryToDo/Change/',
        type: 'post',
        data: { "Id": statusId },
        success: function () {
            getList();
        }
    });
}
function cancel(cancelId) {
    $.ajax
        ({
            url: '/JQueryToDo/Cancel/',
            type: 'post',
            data: { "Id": cancelId },
            success: function () {
                getList();
            }
        });
}


