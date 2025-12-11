$(document).ready(function () {
    carregarCirurgias();

    $("#formAgendamento").submit(function (e) {
        e.preventDefault();

        // Bloqueia botão para evitar duplo clique
        var btn = $(this).find("button[type=submit]");
        btn.prop('disabled', true).text('Agendando...');

        var dados = {
            pacienteId: parseInt($("#pacienteId").val()),
            salaId: parseInt($("#salaId").val()),
            inicio: $("#dataInicio").val(),
            fim: $("#dataFim").val()
        };

        $.ajax({
            url: '/api/agendamento',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(dados),
            success: function (response) {
                mostrarAlerta("success", response.mensagem);
                carregarCirurgias();
                $("#formAgendamento")[0].reset();
            },
            error: function (xhr) {
                var erro = xhr.responseText || "Erro ao processar.";
                mostrarAlerta("danger", erro);
            },
            complete: function () {
                btn.prop('disabled', false).text('Confirmar Agendamento');
            }
        });
    });
});

function carregarCirurgias() {
    $.ajax({
        url: '/api/agendamento',
        type: 'GET',
        success: function (lista) {
            var html = "";
            $.each(lista, function (i, item) {
                html += `<tr>
                            <td>
                                <div class="fw-bold">${item.paciente}</div>
                            </td>
                            <td>
                                <span class="badge bg-primary rounded-pill">${item.sala}</span>
                            </td>
                            <td>
                                <div class="small text-muted">Início: ${item.inicio}</div>
                                <div class="small text-muted">Fim: ${item.fim}</div>
                            </td>
                         </tr>`;
            });
            $("#tabelaCirurgias").html(html);
        }
    });
}

function mostrarAlerta(tipo, msg) {
    $("#msgResult")
        .removeClass("d-none alert-success alert-danger")
        .addClass("alert-" + tipo)
        .text(msg)
        .show();

    setTimeout(function () { $("#msgResult").fadeOut(); }, 5000);
}