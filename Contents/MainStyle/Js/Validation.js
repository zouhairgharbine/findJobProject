// validate Nom Box //

function Validation() {
    // parte vide input //
    let boll = true;
    let Nom = document.getElementById("Nom");
    let Email = document.getElementById("Email");
    let Téléphone = document.getElementById("Téléphone");
    let Adresse = document.getElementById("Adresse");
    let Password = document.getElementById("Password");
    let siteWeb = document.getElementById("siteWeb");
    let Spécialité = document.getElementById("Spécialité");
    let NomUtilisateur = document.getElementById("NomUtilisateur");
    let list = [Nom, Email, Téléphone, Adresse, Password, siteWeb, Spécialité, NomUtilisateur];

    list.forEach((ele) => {
        if (ele.value == "") {
            ele.classList.add("is-invalid");
            boll = false;
        } else {
            ele.classList.remove("is-invalid");
        }
    });
    return boll;
}