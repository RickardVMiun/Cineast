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
    document.querySelector('#upvoteButton').style.backgroundColor = "grey";
    document.querySelector('#downvoteButton').style.backgroundColor = "grey";
    document.querySelector('#upvoteButton').style.boxShadow = "0px 0px 0px 0px";
    document.querySelector('#downvoteButton').style.boxShadow = "0px 0px 0px 0px";

    let div = document.createElement('div');
    div.className = "alert";
    div.innerHTML = "<strong>Thanks</strong> for your vote, it has been registered.";

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
    document.querySelector('#upvoteButton').style.backgroundColor = "grey";
    document.querySelector('#downvoteButton').style.backgroundColor = "grey";
    document.querySelector('#upvoteButton').style.boxShadow = "0px 0px 0px 0px";
    document.querySelector('#downvoteButton').style.boxShadow = "0px 0px 0px 0px";

    let div = document.createElement('div');
    div.className = "alert";
    div.innerHTML = "<strong>Thanks</strong> for your vote, it has been registered.";

    document.querySelector('#movie-information').append(div);
}




function getMyValue() {
    return jsImdbID;
}



console.log('js loaded!')