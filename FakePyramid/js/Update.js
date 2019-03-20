

let input;
let preview_anchor;

function body_onload() {
    // Execute a function when the user releases a key on the keyboard
    input = document.getElementById("ppinput");
    preview_anchor = document.getElementById("preview-anchor");
}


function preview() {

    if (input.value === "") { return false; }

    preview_anchor.href = "https://paypal.me/" + input.value;
    preview_anchor.click();


}

function update() {

    if (input.value === "") { return false; }

    let href = "/home/update/" + UserID + "|" + input.value;

    window.location.href = href;

}