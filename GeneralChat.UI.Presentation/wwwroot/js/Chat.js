// Este script se ejecuta cuando se carga completamente el DOM
document.addEventListener('DOMContentLoaded', function () {
    loadMessages(); // Cargar mensajes inicialmente

    // Cargar mensajes cada 3 segundos
    setInterval(loadMessages, 3000);

    // Manejar el envío del formulario de chat
    document.getElementById('chat-form').addEventListener('submit', function (event) {
        event.preventDefault(); // Prevenir la acción por defecto del formulario
        sendMessage(); // Enviar mensaje
    });
});

// Función para cargar mensajes del servidor
function loadMessages() {
    fetch('/Chat/GetMessages') // Petición GET a la ruta '/Chat/GetMessages'
        .then(response => response.json()) // Convertir la respuesta a JSON
        .then(data => {
            const chatBox = document.getElementById('chat-box'); // Obtener el contenedor del chat
            chatBox.innerHTML = ''; // Limpiar contenido actual
            // Iterar sobre los mensajes recibidos
            data.forEach(msg => {
                const msgDiv = document.createElement('div'); // Crear elemento div para cada mensaje
                msgDiv.textContent = `${msg.FechaHora} - ${msg.Usuario}: ${msg.Mensaje}`; // Texto del mensaje
                chatBox.appendChild(msgDiv); // Agregar el div al contenedor del chat
            });
        });
}

// Función para enviar mensajes al servidor
function sendMessage() {
    const messageInput = document.getElementById('message'); // Obtener el input del mensaje
    const message = messageInput.value; // Obtener el texto del mensaje
    messageInput.value = ''; // Limpiar el input

    // Enviar mensaje al servidor
    fetch('/Chat/SendMessage', {
        method: 'POST', // Método POST
        headers: {
            'Content-Type': 'application/json' // Encabezado para indicar tipo de contenido JSON
        },
        body: JSON.stringify({ mensaje: message }) // Cuerpo de la solicitud: mensaje en formato JSON
    }).then(response => response.json()) // Convertir la respuesta a JSON
        .then(data => {
            if (data.status === 'Message sent') {
                loadMessages(); // Recargar mensajes después de enviar el mensaje
            }
        });
}

