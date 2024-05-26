$("#buttonID").click(function () {
    let table = document.querySelector('#productos');
    let data = [];
    let headers = [...table.rows[0].cells].map(th => th.innerText.trim());

    for (let row of [...table.rows].slice(1)) {
        let product = {};
        let selected = row.querySelector("input[type='checkbox']").checked;        
        if (selected) {
            [...row.cells].forEach((cell, i) => {
                let input = cell.querySelector("input[type='hidden']");
                if (input) {
                    product[input.name] = input.value;
                } else if (headers[i] !== "Agregar al Carrito") {
                    product[headers[i]] = cell.innerText.trim();
                }
            });
            product["Selected"] = selected;
            product["Agricultor"] = { "Id": product["item.Agricultor.Id"] }; // Construir objeto Agricultor
            delete product["AgricultorId"]; // Eliminar el campo temporal
            data.push(product);
        }
    }

    if (data.length === 0) {
        alert("No se ha seleccionado ningún producto.");
        return;
    }

    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: '/Pedido/Create',
        data: JSON.stringify({ productos: data, client: '1' }),
        success: function (response) {
            alert("Se creó el pedido con id " + response.id);
        },
        error: function (response) {
            alert("Inconveniente al crear el pedido");
        }
    });
});

