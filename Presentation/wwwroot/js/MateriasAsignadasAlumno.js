$(document).ready(function () {
    SelectAlumnoMateria();
});

function SelectAlumnoMateria() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5034/api/alumno/GetAll',
        success: function (result) {
            $('#SelectAlumnoMateria tbody').empty();
            $.each(result, function (i, alumno) {
                var filas =
                    '<tr>'
                    + '<td class="text-center"> <button class="btn btn-warning" onclick="ObtenerMateriasAsignadasAlumno(' + alumno.idAlumno + ')"><i class="fa-solid fa-pencil"></button></td>' //Editar Boton
                    + '</td>' + "<td id='id' class='d-none'>"
                    + alumno.idAlumno + "</td>" + "<td class='text-center'>"
                    + alumno.nombre + " " + alumno.apellidoPaterno + " " + alumno.apellidoMaterno + "</td>"
                    + "</tr>";
                $("#SelectAlumnoMateria tbody").append(filas);
               
            });
            $("#btnAdd").hide();
            $("#column3").hide();
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
};

function ObtenerMateriasAsignadasAlumno(idAlumno) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5034/api/alumnomateria/GetById' + idAlumno,
        success: function (result) {
            $('#SelectAlumnoMateria tbody').empty();
            $.each(result, function (i, materia) {
                var filas = '<tr>' + "<td style='display: none;'>"
                    + '<a href="#" onclick="(' + idAlumno + ')">'
                    + '</a> ' + '</td>' + "<td  id='id' style='display:none;'>"
                    + idAlumno + "</td>" + "<td class='text-center'>"
                    + materia.materia.nombre + "</td>" + "<td class='text-center'>"
                    + materia.materia.costo + "</td>"
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + idAlumno + ',' + materia.materia.idMateria + ')"><i class="fa-solid fa-eraser"></i></button></td>'

                    + "</tr>";
                $("#SelectAlumnoMateria tbody").append(filas);

            });
            $("#column3").show();
            $("#btnAdd").show();
            $("#btnAdd").attr('onclick', 'ObtenerMateriasNoAsignadasAlumno( ' + idAlumno + ')');
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
};

function Eliminar(idMateria, idAlumno) {

    if (confirm("¿Estas seguro de eliminar la materia seleccionada?")) {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:5034/api/alumnomateria/Delete' + idMateria + '/' + idAlumno,
            success: function (result) {
                $('#myModal').modal();
                SelectAlumnoMateria();
            },
            error: function (result) {
                alert('Error en la consulta.');
            }
        });
    };
};

function Add(idAlumno, idMateria) {
    var alumnoMateria = {
        IdAlumno: idAlumno,
        IdMateria: idMateria,

    }
    $.ajax({
        type: 'POST',
        url: 'http://localhost:5034/api/alumnomateria/Add/' + idAlumno + '/' + idMateria,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            SelectAlumnoMateria();
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
};

function ObtenerMateriasNoAsignadasAlumno(idAlumno) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5034/api/alumnomateria/ObtenerMateriasNoAsignadasAlumno' + idAlumno,
        success: function (result) { //200 OK
            $('#SelectAlumnoMateria tbody').empty();
            $.each(result, function (i, materia) {
                var filas = '<tr>' + '<td class="text-center" id ="find-table">'
                    + '<label><input type="checkbox" name="cbox1" id="cbox1" value="' + materia.materia.idMateria + '"></label>'
                    + '</a> ' + '</td>' + "<td  id='id' class='d-none'>"
                    + idAlumno + "</td>" + "<td class='text-center'>"
                    + materia.materia.nombre + "</td>" + "<td class='text-center'>"
                    + materia.materia.costo + "</td>"
                    //+ '<td class="text-center">  <a href="#" onclick="return Eliminar(' + subCategoria.IdSubCategoria + ')">' + '<img  style="height: 25px; width: 25px;" src="../img/delete.png" />' + '</a>    </td>'
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + idAlumno + ',' + materia.idMateria + ')"><span class="bi bi-trash-fill" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";
                $("#SelectAlumnoMateria tbody").append(filas);
            });
            $("#btnAdd").attr('onclick', 'ListaMaterias( ' + idAlumno + ')');
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
};

function ListaMaterias(idAlumno) {
    var listIdMaterias = new Array(10); // Inicializo mi arreglo 
    var inputElements = document.getElementById('SelectAlumnoMateria');
    for (var i = 0; inputElements.childNodes[3].childNodes; ++i) {
        var result = inputElements.childNodes[3].childNodes[i].childNodes[0].childNodes[0].childNodes[0].checked
        var idMateria = inputElements.childNodes[3].childNodes[i].childNodes[0].childNodes[0].childNodes[0].value

        if (inputElements.childNodes[3].childNodes[i].childNodes[0].childNodes[0].childNodes[0].checked) {
            listIdMaterias[i] = idMateria;

            Add(idAlumno, idMateria)
        }
    }
};