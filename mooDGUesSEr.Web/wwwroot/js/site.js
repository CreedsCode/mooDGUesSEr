// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

const card = document.getElementsByClassName("card")[0];
const textarea = document.getElementsByTagName("textarea")[0];
const cardText = document.getElementsByClassName("card-header-title")[0];

function updateMood() {
   var input = textarea.value;
   if(input == "") return;
   getMood(input).then((mood) =>{
       switch (mood) {
           case "Bad":
               displayMood("has-background-danger", mood);             
               break;
           case "Good":
               displayMood("has-background-success", mood);             
           default:
               break;
       }
   });
};

function displayMood(style ,mood) {
    cardText.innerText = mood;
}

function getMood(string) {
   return fetch(`Index?handler=Mood&text=${string}`)
           .then((response) => { return response.text();});
}


$(".card-header-icon").on('click', updateMood)