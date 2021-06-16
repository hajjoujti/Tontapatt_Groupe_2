const nmbAnimTotal = document.getElementById('nmbAnimTotal');
const nmbAnimTotalOffre = document.getElementById('nmbAnimTotalOffre');
const tailleTerain = document.getElementById('tailleTerrain');
const spannmbmouton = document.getElementById('nmbAnim');
const nmbJour = document.getElementById('nmbJour');
const coutPresta = document.getElementById('coutPresta');
const prix = document.getElementById('prix');
const tonteparjour = 2.7;
var dateOffreStart;
var datteOffreEnd;
console.log("tailleTerrain: "+tailleTerrain.value)
console.log("nmbAnimTotal: " + nmbAnimTotal.value)
console.log("nmbAnimTotalOffre: " + nmbAnimTotalOffre.value)
console.log(nmbAnimTotal);
console.log("spannmbmouton: " + spannmbmouton)
console.log(spannmbmouton);
console.log(nmbJour);


function handlerstart(e) {
    dateOffreStart = new Date(e.target.value);
    calcCost();
}

function handlerend(e) {
    datteOffreEnd = new Date(e.target.value);
    calcCost();
}

function calcCost() {
    if (dateOffreStart != null && datteOffreEnd != null && datteOffreEnd > dateOffreStart) {
        var nmbjourselect = daydiff(dateOffreStart, datteOffreEnd);
        //calculer le nombre de mouton max sur la parcelle
        const nmbanimauxmax = tailleTerrain.value / 8;
        const moutonparjour = tonteparjour * nmbanimauxmax;
        const minjour = Math.ceil(moutonparjour / nmbanimauxmax);
        const maxtonteoffrejour = Math.ceil(nmbAnimTotalOffre.value * tonteparjour);
        const minjourOffre = Math.ceil(tailleTerrain.value / maxtonteoffrejour);
        console.log("moutonparjour: " + moutonparjour);
        console.log("tonteparjour : " + tonteparjour);
        console.log("nmbanimauxmax: " + nmbanimauxmax);
        console.log("tailleTerrain: " + tailleTerrain.value);
        console.log("minjour: " + minjour);
        console.log("nmbjourselect: " + nmbjourselect);
        console.log("maxtonteoffrejour: " + maxtonteoffrejour);
        console.log("nmbAnimTotal: " + nmbAnimTotal.value);
        console.log("minjourOffre: " + minjourOffre);   
        console.log("nmbAnimTotalOffre: " + nmbAnimTotalOffre.value)

        if (nmbjourselect >= minjour && nmbjourselect >= minjourOffre) {
            /*calcul cout avec choix*/
            var resultatnmbMouton = Math.ceil(tailleTerrain.value / (tonteparjour * nmbjourselect));
            console.log("-----------------------entrer dans la verif ecart de temps----------------");
            var coutmouton = Math.ceil(resultatnmbMouton * 7.5 * nmbjourselect);
            console.log("resultatnmbMouton: " + resultatnmbMouton);
            if (nmbanimauxmax >= resultatnmbMouton) {
                spannmbmouton.innerHTML = resultatnmbMouton;
                nmbJour.innerHTML = nmbjourselect;
                coutPresta.innerHTML = coutmouton + "€";
                nmbAnimTotal.value = resultatnmbMouton;
                prix.value = coutmouton;
            } else {
                console.log("--------------------------------------------");
                console.log("--------------pas assez de temps-----------------");
                spannmbmouton.innerHTML = "Pas assez de temps pour la surface";
                nmbJour.innerHTML = nmbjourselect;
                coutPresta.innerHTML = "0€";
            }
        } else {
            var resultatnmbMouton = Math.ceil(tailleTerrain.value / (tonteparjour * nmbjourselect));
            console.log("--------------------------------------------");
            console.log("-----date trop courte----------");
            console.log("resultatnmbMouton: " + resultatnmbMouton);
            spannmbmouton.innerHTML = "date trop courte";
            nmbJour.innerHTML = nmbjourselect;
            coutPresta.innerHTML = "0€";
        }
    }

}

function daydiff(d1, d2) {
    const diffTime = Math.abs(d2 - d1);
    const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
    console.log(diffTime + " milliseconds");
    console.log(diffDays + " days");
    return diffDays;
}