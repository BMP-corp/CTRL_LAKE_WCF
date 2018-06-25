function dataFormNoleggio(element, date){
    element.value = date;
};

function aggiungiBarca(persone, riepilogoDiv) {
    var num = myGetElementById('totali').value;
    riepilogoDiv.innerHTML += '<label>Tipo: </label><input type="text" name="attr' + num + '" value="barca" readonly/>';
    riepilogoDiv.innerHTML += '<label>Persone: </label><input type="number" name="pers' + num + '" value="' + persone + '" readonly/><br/>';
    myGetElementById('totali').value = parseInt(num) + 1;
};

function aggiungiCanoa(persone, riepilogoDiv) {
    var num = myGetElementById('totali').value;
    riepilogoDiv.innerHTML += '<label>Tipo: </label><input type="text" name="attr' + num + '" value="canoa" readonly/>';
    riepilogoDiv.innerHTML += '<label>Persone: </label><input type="number" name="pers' + num + '" value="' + persone + '" readonly/><br/>';
    myGetElementById('totali').value = parseInt(num) + 1;
};

function aggiungiWindsurf(persone, riepilogoDiv) {
    var num = myGetElementById('totali').value;
    riepilogoDiv.innerHTML += '<label>Tipo: </label><input type="text" name="attr' + num + '" value="windsurf" readonly/>';
    riepilogoDiv.innerHTML += '<label>Persone: </label><input type="number" name="pers' + num + '" value="' + persone + '" readonly/><br/>';
    myGetElementById('totali').value = parseInt(num) + 1;
};

function aggiungiSup(persone, riepilogoDiv) {
    var num = myGetElementById('totali').value;
    riepilogoDiv.innerHTML += '<label>Tipo: </label><input type="text" name="attr' + num + '" value="sup" readonly/>';
    riepilogoDiv.innerHTML += '<label>Persone: </label><input type="number" name="pers' + num + '" value="' + persone + '" readonly/><br/>';
    myGetElementById('totali').value = parseInt(num) + 1;
};