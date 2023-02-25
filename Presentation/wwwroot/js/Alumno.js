$(document).ready(function () { 
    SelectAlumnos();
});

function SelectAlumnos() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5034/api/alumno/GetAll',
        success: function (result) { 
            $('#Alumnos').empty();
            $.each(result, function (i, alumno) {
                var filas =
                    '<div class="wrapper"> </div>'
                    + '<div class="clash-card giant"> </div>'
                    + '<img src = "/imagess/usuario-icono.png" alt = "giant"/> </div >'
                    + '<div class="clash-card__level clash-card__level--giant">' + alumno.idAlumno + '</div>'
                    + '<div class="clash-card__unit-name">' + alumno.nombre + ' ' + alumno.apellidoPaterno + ' ' + alumno.apellidoMaterno + ' ' + '</div>'
                    + '<div class="center">'
                    + '<button class="btn btn-primary" onclick="GetById(' + alumno.idAlumno + ')"> Editar </button> </div>'
                    + '<div class="center">'
                    + '<button class="btn btn-primary" onclick="Eliminar(' + alumno.idAlumno + ')"> Eliminar </button> </div>'

                $("#Alumnos").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
};

function GetById(idAlumno) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5034/api/alumno/GetById' + idAlumno,
        success: function (result) {
            $('#txtIdAlumno').val(result.idAlumno);
            $('#txtNombre').val(result.nombre);
            $('#txtApellidoP').val(result.apellidoPaterno);
            $('#txtApellidoM').val(result.apellidoMaterno);
            $('#Imagen').val(result.imagen);

            $('#btnGuardar').text('Actualizar')
            $('#ModalUpdate').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
}

function Add(alumno) {

    $.ajax({
        type: 'POST',
        url: 'http://localhost:5034/api/alumno/Add',
        dataType: 'json',
        data: JSON.stringify(alumno),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            SelectAlumnos();
        }
    });
};

function Update(alumno) {

    $.ajax({
        type: 'POST',
        url: 'http://localhost:5034/api/alumno/Update',
        datatype: 'json',
        data: JSON.stringify(alumno),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            SelectAlumnos();
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });

};

function Modal() {
    IniciarAlumno();
    $('#ModalUpdate').modal('show');
    var test = $('#btnGuardar').text();
    $('#btnGuardar').text('Agregar')
}

function IniciarAlumno() {
    $('#txtIdAlumno').val('')
    $('#txtNombre').val('')
    $('#txtApellidoP').val('')
    $('#txtApellidoM').val('')
    $('#Imagen').val('')
}

function Eliminar(idAlumno) {

    if (confirm("¿Estas seguro de eliminar el empleado seleccionado?")) {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:5034/api/alumno/Delete' + idAlumno,
            success: function (result) {
                $('#myModal').modal();
                SelectAlumnos();
            },
            error: function (result) {
                alert('Error en la consulta.');
            }
        });

    };
};

function Guardar() {
    var alumno = {
        IdAlumno: $('#txtIdAlumno').val(),
        Nombre: $('#txtNombre').val(),
        ApellidoPaterno: $('#txtApellidoP').val(),
        ApellidoMaterno: $('#txtApellidoM').val(),
        Imagen: $('#Imagen').val(),
    }

    if (alumno.IdAlumno == '') {
        alumno.IdAlumno = 0,
            Add(alumno);

    }
    else {
        Update(alumno);
    }
}

function validateFile() {
    var allowedExtension = ['png', 'jpg'];
    var fileExtension = document.getElementById('Imagen').value.split('.').pop().toLowerCase();
    var isValidFile = false;
    for (var index in allowedExtension) {
        if (fileExtension === allowedExtension[index]) {
            isValidFile = true;
            break;
        }
    }
    if (!isValidFile) {
        alert('Las extensiones permitidas son : *.' + allowedExtension.join(', *.'));
        document.getElementById('Imagen').value = ""
    }
    return isValidFile;
}
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#ImgPrevia')
                .attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}