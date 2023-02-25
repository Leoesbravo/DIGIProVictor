$(document).ready(function () { //click
    SelectMaterias();
});

function SelectMaterias() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5034/api/materia/GetAll',
        success: function (result) { //200 OK
            $('#SelectMaterias tbody').empty();
            $.each(result, function (i, materia) {
                var filas =
                    '<tr>'
                    + '<td class="text-center">'
                    + '<button onclick="GetById(' + materia.idMateria + ')" class="btn btn-warning"><i class="fa-solid fa-pencil"></i> </button>'
                    + '</td>'
                    + "<td  id='id' style='display:none;'>"+ materia.idMateria + "</td>"
                    + "<td class='text-center'>"
                    + materia.nombre + "</td>" + "<td class='text-center'>" +
                    "$"+ materia.costo + "</ td>"
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + materia.idMateria + ')"><i class="fa-solid fa-eraser"></i></button></td>'

                    + "</tr>";
                $("#SelectMaterias tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
};

function GetById(idMateria) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5034/api/materia/GetById' + idMateria,
        success: function (result) {
            $('#txtIdMateria').val(result.idMateria);
            $('#txtNombre').val(result.nombre);
            $('#Costo').val(result.costo);

            $('#btnGuardar').text('Actualizar')
            $('#ModalUpdate').modal('show');

        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
};

function Add(materia) {

    $.ajax({
        type: 'POST',
        url: 'http://localhost:5034/api/materia/Add',
        dataType: 'json',
        data: JSON.stringify(materia),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            SelectMaterias();
        }
    });
};

function Update(materia) {

    $.ajax({
        type: 'POST',
        url: 'http://localhost:5034/api/materia/Update',
        datatype: 'json',
        data: JSON.stringify(materia),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            SelectMaterias();
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });

};

function Modal() {
    IniciarMateria();
    $('#ModalUpdate').modal('show');
    var test = $('#btnGuardar').text();
    $('#btnGuardar').text('Agregar')
}

function IniciarMateria() {
    var materia = {
        idMateria: $('#txtIdMateria').val(''),
        nombre: $('#txtNombre').val(''),
        costo: $('#Costo').val(''),
    }
}

function Eliminar(idMateria) {

    if (confirm("¿Estas seguro de eliminar la materia seleccionada?")) {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:5034/api/materia/Delete' + idMateria,
            success: function (result) {
                $('#myModal').modal();
                SelectMaterias();
            },
            error: function (result) {
                alert('Error en la consulta.');
            }
        });

    };
};

function Guardar() {
    var materia = {
        IdMateria: $('#txtIdMateria').val(),
        Nombre: $('#txtNombre').val(),
        Costo: $('#Costo').val(),
    }

    if (materia.IdMateria == '') {
        materia.IdMateria = 0;
            Add(materia);

    }
    else {
        Update(materia);
    }
}
