function toggle() {
    let spanElement = document.getElementsByClassName("button")[0];
    
    let divElement = document.getElementById("extra");

    if (divElement.style.display === "none"){
        divElement.style.display = "block";
        spanElement.innerHTML = "Less";
    } else {
        divElement.style.display = "none";
        spanElement.innerHTML = "More";
    }
}