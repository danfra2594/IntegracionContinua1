function guardarBodega() {

  var decripcion = document.getElementById("descripcion").value;
  var estado = document.getElementById("estado").value;
  var fecha = new Date();

  var filter = {
    IdBodega: 0,
    Descripcion: decripcion,
    Estado: estado == 1 ? true : false,
    Fecha : fecha
  }

  $.ajax({
    data: filter,//JSON.stringify(filter),
    type: "POST",
    dataType: 'application/json; charset=utf-8',
    url: "https://localhost:44362/api/bodegas",
    })
     .done(function( data, textStatus, jqXHR ) {
         if ( console && console.log ) {
             console.log( "La solicitud se ha completado correctamente." );
             alert("Registro de bodega almacenado correctamente");
         }
     })
     .fail(function( jqXHR, textStatus, errorThrown ) {
         if ( console && console.log ) {
             console.log( "La solicitud se ha completado correctamente." );
             alert("Registro de bodega almacenado correctamente");
         }
    });
}
