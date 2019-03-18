

let input;

function body_onload() {
    // Execute a function when the user releases a key on the keyboard
    input = document.getElementById("ppinput");
}

function Preview() {

    if (input.value === "") { return false; }

    let href = "https://paypal.me/" + input.value;

    window.location.href = href;

}

function UpdateUserName() {

    if (input.value === "") { return false; }

    let href = "/UpdateName/" + TransID + "|" + input.value;

    window.location.href = href;

}