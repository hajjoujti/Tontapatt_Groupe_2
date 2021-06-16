// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var tonteparjour = 2.7;
var nmbAnimTotal = document.getElementById('nmbAnimTotal'); //input/value qui sera poster
var tailleTerain = document.getElementById('tailleTerrain').value; 
var dateOffreStart
var datteOffreEnd 
            var spannmbmouton = document.getElementById('nmbAnim');
            var nmbJour = document.getElementById('nmbJour');
            var coutPresta = document.getElementById('coutPresta');

function handlerstart(e) {
    dateOffreStart =new Date( e.target.value);
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
    var nmbanimauxmax = tailleTerrain.value / 8;
    var moutonparjour = tonteparjour * nmbanimauxmax; 
    var minjour = Math.ceil(moutonparjour / nmbanimauxmax);
    var maxtonteoffrejour = Math.ceil(nmbAnimTotal.value * tonteparjour); 
    var minjourOffre = Math.ceil(tailleTerrain.value / maxtonteoffrejour); 
    console.log("moutonparjour: " + moutonparjour);
    console.log("tonteparjour : " + tonteparjour );
    console.log("nmbanimauxmax: " + nmbanimauxmax);
    console.log("tailleTerrain: " + tailleTerrain.value);
    console.log("minjour: " + minjour);
    console.log("nmbjourselect: " + nmbjourselect);
    console.log("maxtonteoffrejour: " + maxtonteoffrejour);
    console.log("nmbAnimTotal: " + nmbAnimTotal.value);
    console.log("minjourOffre: " + minjourOffre);


        if (nmbjourselect >= minjour && nmbjourselect >= minjourOffre) {

            /*calcul cout avec choix*/
            /*nombre de mouton pour un nombre de jour et une surface*/
            var resultatnmbMouton = Math.ceil(tailleTerrain.value / (tonteparjour * nmbjourselect));
            console.log("--------------------------------------------");
            var coutmouton = resultatnmbMouton * 2.7;
            console.log("resultatnmbMouton: " + resultatnmbMouton);
            if (nmbanimauxmax >= resultatnmbMouton) {
                spannmbmouton.innerHTML = resultatnmbMouton;
                nmbJour.innerHTML = nmbjourselect;
                coutPresta.innerHTML = nmbjourselect + "€";
            } else {
            console.log("--------------------------------------------");
                spannmbmouton.innerHTML = "Pas assez de temps pour la surface";
                nmbJour.innerHTML = nmbjourselect;
                coutPresta.innerHTML = "0€";

            }

        } else {
            var resultatnmbMouton = Math.ceil(tailleTerrain.value / (tonteparjour * nmbjourselect));
            console.log("--------------------------------------------");
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



