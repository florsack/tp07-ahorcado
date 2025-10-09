// --- VARIABLES ---
const palabra = document.getElementById('Palabra').innerText.trim().toUpperCase();
const letrasMostradas = document.querySelectorAll('.letra-oculta');
const input = document.getElementById('inputLetraPalabra');
const intentosHidden = document.getElementById('intentos');
const letrasUsadasContainer = document.getElementById('contenedor-letras');
const btnLetra = document.getElementById('btnArriesgarLetra');
const btnPalabra = document.getElementById('btnArriesgarPalabra');
const seccionFinal = document.getElementById('botones-final');
const btnVolver = document.getElementById('btnVolver');
const intentosFinalInput = document.getElementById('intentosFinal');

let letrasUsadas = new Set();
let intentos = 0;

// --- ARRIESGAR LETRA ---
btnLetra.addEventListener('click', () => {
    const letraIngresada = input.value.trim().toUpperCase();

    if (letraIngresada.length !== 1 || !/[A-ZÑÁÉÍÓÚ]/.test(letraIngresada)) {
        alert("Ingresá una sola letra válida.");
        input.value = "";
        return;
    }

    if (letrasUsadas.has(letraIngresada)) {
        alert("Ya arriesgaste esa letra.");
        input.value = "";
        return;
    }

    letrasUsadas.add(letraIngresada);
    letrasUsadasContainer.textContent = Array.from(letrasUsadas).join(' ');

    let acierto = false;

    for (let i = 0; i < palabra.length; i++) {
        if (palabra[i] === letraIngresada) {
            letrasMostradas[i].textContent = letraIngresada;
            acierto = true;
        }
    }

    if (!acierto) {
        intentos++;
        intentosHidden.value = intentos;
    }

    input.value = "";
    verificarEstado();
});

// --- ARRIESGAR PALABRA ---
btnPalabra.addEventListener('click', () => {
    const palabraIngresada = input.value.trim().toUpperCase();
    if (palabraIngresada.length === 0) {
        alert("Ingresá una palabra para arriesgar.");
        return;
    }

    intentos++;
    intentosHidden.value = intentos;

    if (palabraIngresada === palabra) {
        for (let i = 0; i < palabra.length; i++) {
            letrasMostradas[i].textContent = palabra[i];
        }
        ganar();
    } else {
        alert("❌ Incorrecto. Sumaste un intento. Seguí intentando.");
        input.value = "";
    }
});

// --- VERIFICAR ESTADO ---
function verificarEstado() {
    let completo = true;
    for (let i = 0; i < palabra.length; i++) {
        if (letrasMostradas[i].textContent === "_") {
            completo = false;
            break;
        }
    }
    if (completo) ganar();
}

// --- GANAR ---
function ganar() {
    alert("🎉 ¡Felicitaciones! Completaste la palabra en " + intentos + " intentos.");
    finalizar();
}

// --- FINALIZAR ---
function finalizar() {
    seccionFinal.style.display = "block";
    intentosFinalInput.value = intentos;

    btnLetra.disabled = true;
    btnPalabra.disabled = true;
    input.disabled = true;

    // mostrás el botón de volver por si quiere reiniciar manualmente
    btnVolver.style.display = "inline-block";
}
