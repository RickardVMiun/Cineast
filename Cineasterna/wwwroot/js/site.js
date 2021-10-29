var likeresponse = {};

document.querySelector('#upvoteButton').onclick = function () { like() };



function like() {
    var imdbID = getMyValue();
    
    fetch("https://grupp9.dsvkurs.miun.se/api/" + imdbID + "/like")
        .then(response => response.json())
        .then(data => {
                document.querySelector('#cMDBvalueup').innerHTML = data.numberOfLikes
                });

    document.querySelector('#upvoteButton').disabled = true;
    document.querySelector('#downvoteButton').disabled = true;

    let div = document.createElement('div');
    div.className = "alert";
    div.innerHTML = "<strong>Tack</strong> för din röst";

    document.querySelector('#movie-information').append(div);
   
}


function getMyValue() {
    return jsImdbID;
}



console.log('js loaded!')

