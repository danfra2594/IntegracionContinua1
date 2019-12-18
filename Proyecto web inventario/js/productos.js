function guardarProducto() {

  var decripcion = document.getElementById("descripcion").value;
  var estado = document.getElementById("estado").value;
  var fecha = new Date();
  var foto = document.getElementById("foto").value;
  var costocompra = parseFloat(document.getElementById("costocompra").value);
  var costoventa = parseFloat(document.getElementById("costoventa").value);
  var cantidad = parseInt(document.getElementById("cantidad").value);

  var filter = {
    IdProducto: 0,
    Descripcion: decripcion,
    Estado: estado == 1 ? true : false,
    Fecha : fecha,
    Foto: foto,
    CostoCompra: costocompra,
    CostoVenta: costoventa,
    CantidadDisponible: cantidad
  }

  $.ajax({
    data: filter,//JSON.stringify(filter),
    type: "POST",
    dataType: 'application/json; charset=utf-8',
    url: "https://localhost:44362/api/Productoes",
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
