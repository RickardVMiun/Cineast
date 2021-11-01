let decider = 0;

document.querySelector('#morelink').onclick = function () { textmanipulator() };
function textmanipulator() {

    if (decider === 0) {
        document.querySelector('#topmovie-plottext').innerHTML = getLongPlot();
        decider = 1;
        document.querySelector('#morelink').textContent = "Less.."
        
    }
    else {
        document.querySelector('#topmovie-plottext').innerHTML = getShortPlot();
        decider = 0;
        document.querySelector('#morelink').textContent = "More.."
    }

}

function getLongPlot() {
    return longPlot;
}

function getShortPlot() {
    return shortPlot;
}