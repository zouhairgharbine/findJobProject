let AddNewBtn = document.querySelector(".Add-new-job ");
let boxCard = document.querySelector(".boxJobs");
let cancelBtn = document.querySelector(".Cancel-Jobs-btn");

AddNewBtn.addEventListener("click", () => {
    boxCard.style.display = "block";
});

cancelBtn.addEventListener("click", () => {
    boxCard.style.display = "none";
});

/* start number of navigator icon */

let contentMesaage = document.querySelectorAll(".contentMesaage");
let iconNotif = document.querySelector(".icon-notif");

if (contentMesaage.length == 0) {
    iconNotif.remove();
} else {
    iconNotif.innerHTML = contentMesaage.length;
}

/* end number of navigator icon */