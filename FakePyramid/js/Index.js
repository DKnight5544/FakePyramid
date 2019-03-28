

function body_onload() {
    // Get the input field
    var input = document.getElementById("ppinput");

    // Execute a function when the user releases a key on the keyboard
    input.addEventListener("keyup", function (event) {
        // Number 13 is the "Enter" key on the keyboard
        if (event.keyCode === 13) {
            // Cancel the default action, if needed
            event.preventDefault();
            // Trigger the button element with a click
            findPage()
        }
    });
}

function findPage() {

    let ppinput = document.getElementById("ppinput");
    if (ppinput.value === "") { return false; }

    let href = "/home/index/" + ppinput.value;

    window.location.href = href;

}
