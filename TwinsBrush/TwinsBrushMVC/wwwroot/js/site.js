// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//Sweet Alerts
function displayAlertSuccess() {
    Swal.fire(
        'Good job!',
        'Data send at the dataBase',
        'success'
    )
}
function displayAlertError() {
    Swal.fire(
        'Eror',
        'There has been an error',
        'Error, Check the fields or console'
    )
}
function displayAlertWarning() {
    Swal.fire(
        'Warning',
        'Do your really want to do it ?',
        'warning'
    )
}
//Swal Forms
// sendFomr => Ask before sed the data , that can will be used to update or specials dates emails,phones,etc..
function sendForm(e, id) {

    e.preventDefault();

    Swal.fire(
        {
            title: 'Do you want to save the changes ?',
            icon: 'question',
            showCancelButton: true

        }).then(result => {
            if (result.isConfirmed) {
                const myForm = document.getElementById(id);
                myForm.submit();

            }
        })
}
// sendDelete => AskBefore delete the date on in db :p
function sendDelete(e, id) {
    e.preventDefault();

    Swal.fire(
        {
            title: 'Do you want to Delete this date ?',
            icon: 'warning',
            showCancelButton: true

        }).then(result => {
            if (result.isConfirmed) {
                const myForm = document.getElementById(id);
                myForm.submit();

            }
        })
}

//Swal InputsType

//Input Text
function inputTextData(file) {
    await Swal.fire(
        {
            title: 'Enter ur :' + file,
            input: 'text',
            inputLabel: 'Your data text input is : ' + file,
            inputValue,
            showCancelButton: true,
            inputValidator: (value) => {
                if (!value) {
                    return "Your need to write something!";
                }
            }
        });
    if (file) {
        Swal.fire('File input is : ${file}');
    }
}