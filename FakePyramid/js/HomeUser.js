
let base;
let doubler;
let total;


let baseValue;
let doublerValue;
let totalValue;

let input; 

function body_onload() {
    input = document.getElementById("transid_input");
    base = document.getElementById("base");
    doubler = document.getElementById("doubler");
    total = document.getElementById("total");

    resetDemoValues();
    setInterval(doubleDemoValue, 2000);

    // Execute a function when the user releases a key on the keyboard
    input.addEventListener("keyup", function (event) {
        // Number 13 is the "Enter" key on the keyboard
        if (event.keyCode === 13) {
            // Cancel the default action, if needed
            event.preventDefault();
            // Trigger the button element with a click
            AddNewUser();
        }
    });

}

function AddNewUser() {
    //sender is the button, parent is the paragraph, childNode[1] is the input
    
    if (input.value === "") { return false; }

    let href = "/Validate/" + UserName + "|" + PayeeName + "|" + input.value;

    window.location.href = href;

}


function resetDemoValues() {
    baseValue = 10;
    doublerValue = 20;
    totalValue = 30;
    displayDemoValues();
}


function doubleDemoValue() {
    baseValue = totalValue;
    doublerValue = doublerValue * 2;
    totalValue = baseValue + doublerValue;
    if (totalValue > 1000000) resetDemoValues();
    displayDemoValues();
}

function displayDemoValues() {
    base.innerHTML = baseValue;
    doubler.innerHTML = doublerValue;
    total.innerHTML = totalValue;
}