document.querySelector('#morelink').onclick = function () { textmanipulator() };
function textmanipulator() {

    document.querySelector('#topmovie-plottext').innerHTML = getLongPlot();

}





function getLongPlot() {
    return longPlot;
}

function getShortPlot() {
    return shortPlot;
}