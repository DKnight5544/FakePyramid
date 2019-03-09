
let L0, L1, L2, L3, L4, L5;
let base = 5;

function body_onload() {
    L0 = document.getElementById("L0");
    L1 = document.getElementById("L1");
    L2 = document.getElementById("L2");
    L3 = document.getElementById("L3");
    L4 = document.getElementById("L4");
    L5 = document.getElementById("L5");
    incrementbase(0);
}

function incrementbase(offset) {

    base += offset;
    if (base < 1) base = 1;
    if (base > 30) base = 30;

    L0.innerHTML = base + " x 5";

    L1.innerHTML = Math.pow(base, 1).toLocaleString('en');
    L2.innerHTML = Math.pow(base, 2).toLocaleString('en');
    L3.innerHTML = Math.pow(base, 3).toLocaleString('en');
    L4.innerHTML = Math.pow(base, 4).toLocaleString('en');
    L5.innerHTML = Math.pow(base, 5).toLocaleString('en');
}

function AddNewUser(sender) {
    //sender is the button, parent is the paragraph, childNode[1] is the input

    let input = sender.parentElement.childNodes[1];

    if (input.value === "") { return false; }

    let href = "/" + userID + "|" + input.value;

    window.location.href = href;

}
