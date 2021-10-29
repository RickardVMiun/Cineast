var likeresponse = {};

// Logik för att hantera likes av en specifik film.

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

// Logik för att hantera dislikes av en specifik film.

document.querySelector('#downvoteButton').onclick = function () { dislike() };
function dislike() {
    var imdbID = getMyValue();

    fetch("https://grupp9.dsvkurs.miun.se/api/" + imdbID + "/dislike")
        .then(response => response.json())
        .then(data => {
            document.querySelector('#cMDBvaluedown').innerHTML = data.numberOfDislikes
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

