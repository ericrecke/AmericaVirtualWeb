showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
        }
    })
}

jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view-all').html(res.html)
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                }
                else
                    $('#form-modal .modal-body').html(res.html);
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}

function ShowSweetAlert(title, text, icon, cancelButton) {
    return new Promise((resolve) => {
        if (title === undefined) title = "Title";
        if (text === undefined) text = "Content";
        if (icon === undefined) title = "warning";
        if (cancelButton === undefined) cancelButton = false;
        Swal.fire({
            title: title,
            text: text,
            icon: icon,
            showCancelButton: cancelButton,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            cancelButtonText: 'No',
            confirmButtonText: 'Si'
        }).then((result) => {
            if (result.isConfirmed) {
                resolve(true);

            } else {
                resolve(false);
            }
        });
    });

//.then((result) => {
//        if (result.isConfirmed) {
//            Swal.fire(
//                'Deleted!',
//                'Your file has been deleted.',
//                'success'
//            )
//        }
//    })
}