// js code //
console.log("js code is work");

let btnAddDiplome = document.querySelector(".Add-Diplome");
let AddDiplomeCard = document.querySelector(".Add-Diplome-card");
let btnCancelDiplome = document.querySelector(".Cancel-btn");
let box = document.querySelector(".boxdip");

let btnAddEx = document.querySelector(".Add-Ex");
let AddEx = document.querySelector(".Add-Ex-card");
let btnCancelEx = document.querySelector(".Cancel-Ex-btn");
let box2 = document.querySelector(".boxEXp");

/* start add diplome */

btnAddDiplome.addEventListener("click", () => {
    box2.style.display = "none";
    box.style.display = "block";
});

btnCancelDiplome.addEventListener("click", () => {
    box.style.display = "none";
});
/* end add diplome */

/* start add experience  */

btnAddEx.addEventListener("click", () => {
    box.style.display = "none";
    box2.style.display = "block";
});

btnCancelEx.addEventListener("click", () => {
    box2.style.display = "none";
});

/* end add experience  */




