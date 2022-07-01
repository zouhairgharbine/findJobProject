/* start  Event upload files  */
let backImageBtn = document.querySelector(".backImage span");
let profileBtn = document.querySelector(".profile span");
let fileUploadback = document.getElementById("backImageUpload");
let fileUploadprofile = document.getElementById("profileUpload");

backImageBtn.addEventListener("click", () => {
    fileUploadback.click();
});
profileBtn.addEventListener("click", () => {
    fileUploadprofile.click();
});

/* end Event upload files*/