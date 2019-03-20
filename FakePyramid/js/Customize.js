

let background_image;
let button_text;

function body_onload() {
    background_image = document.getElementById("background_image");
    button_text = document.getElementById("button_text");

}

function Customize() {
    //sender is the button, parent is the paragraph, childNode[1] is the input

    if (background_image.value === "") { return false; }
    if (button_text.value === "") { return false; }

    let href = encodeURI("/Customize/" + UserName
        + "|" + background_image.value
        + "|" + button_text.value);

    window.location.href = href;

}
