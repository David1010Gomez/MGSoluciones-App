
document.getElementById('C2').classList.add('current-page-item');
document.getElementById('C1').classList.remove('current-page-item');
document.getElementById('C3').classList.remove('current-page-item');
document.getElementById('C4').classList.remove('current-page-item');

function mensaje1() {
    alert('Solicitud Guardada Exitosamente');
}

function mensaje2() {
    alert('Solicitud No Guardada. Existe Algun Error');
}

function mensaje3() {
    alert('Seleccione un Técnico disponible');
}

function mensaje4() {
    alert('Digite un Caso EXP.');
}

function mensaje5() {
    alert('Existe un error al seleccionar este registro');
}

function mensaje6() {
    alert('No se puede guardar, no hay una solicitud asociada');
}

function mensaje7() {
    alert('Material Agregado');
}

function mensaje8() {
    alert('Elija un Material Antes de Guardar');
}

function mensaje9() {
    alert('Digite una Cantidad');
}
function mensaje10() {
    alert('La Cantidad Supera lo que Existe en Inventario. Digite un Numero Menor');
}
function mensaje11() {
    alert('Ya no existe este Material en el inventario');
}
function mensaje12() {
    alert('Consulte primero la Disponibilidad de la Cantidad');
}