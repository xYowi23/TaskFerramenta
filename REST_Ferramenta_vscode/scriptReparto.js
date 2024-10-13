function stampaReparto(){
    $.ajax(
        {
            url:"http://localhost:5299/api/reparti/tutti",
            type:"GET",
            success: function(risultato){
                let contenuto="";
                for(let[idx, item]of risultato.entries()){
                  
                    contenuto+=`
                    <tr>
                        <td>${item.cod}</td>
                        <td>${item.nom}</td>
                        <td>${item.fil}</td>
                            <td>
                                <button type="button" class="btn btn-danger" onclick="elimina('${item.cod}')">Delete</button>
                            </td>
                    </tr>                    
                    
                    `;
                }
                $("#contenuto-tabella").html(contenuto);
            },
            error:function(errore){
                
                alert("sto in errore");
                console.log(errore);
            }
        }
    )
}


function elimina (varCod){
    $.ajax(
        {
            url :"http://localhost:5299/api/reparti/"+varCod,
            type: "DELETE",
            success:function(){
                alert ("Eliminato con successo");
                stampaReparto();
            },
            error:function(errore){
                alert("sto in erroe");
                console.log(errore)
            }
        }
    );
}



function salva(){

    let varNome = $("#ins-nome").val();
    let varFila = $("#ins-fila").val();

    if(varNome.trim() == ""){
        alert("Attenzione, nome vuoto");
        $("#ins-nome").focus();
        return;
    }
    
    if(varFila.trim() == ""){
        alert("Attenzione, indirizzo vuoto");
        $("#ins-fila").focus();
        return;
    }

    $.ajax({
        url: "http://localhost:5299/api/reparti",
        type: "POST",
        data: JSON.stringify(
            {
                nom: varNome,
                fil: varFila,
            }
        ),
        contentType: "application/json",
        success: function(){
            alert("Inserimento con successo");
            stampaReparto();
        },
        error: function(errore){
            alert("Sto in errore");
            console.log(errore)
        },
        complete: function(){
            
        }

    })
}


stampaReparto();
