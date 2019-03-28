
let MsgText;
let ButtonImage;

let input;

let ClickCounter;
let UserNameDiv;
let LastClickedDateTime;


function body_onload() {
    ClickCounter = document.getElementById("ClickCounter");
    UserNameDiv = document.getElementById("UserNameDiv");
    LastClickedDateTime = document.getElementById("LastClickedDateTime");
    input = document.getElementById("transid_input");
    MsgText = document.getElementById("MsgText");
    ButtonImage = document.getElementById("ButtonImage");

    let imageCount = LoadImages() ;
    clsIndex = getRandom(0, imageCount)
    RotateImages();
    //setInterval(RotateImages, 5000);

    updateClickStatus();

    window.setInterval(updateClickStatus, 5000);

}

function updateClickStatus() {

    let outString = (621355968e9 + (new Date()).getTime() * 1e4);
    outString += "|" + UserName
    outString = encodeURI(outString);
    outString = outString.replace("/", "*");
    const xhr = new XMLHttpRequest();
    xhr.open('GET', '/Home/GetClicks/' + outString);
    xhr.onload = function () {
        if (xhr.status === 200) {
            let obj = JSON.parse(xhr.responseText);
            ClickCounter.innerHTML = "Click Counter: " + obj.ClickCount;

            if (obj.ClickCount != lastClickCount) {
                LastClickedDateTime.innerHTML = obj.LastClickedDate;
                lastClickCount = obj.ClickCount;
            }

            let test = 1;
        }
    };

    xhr.send();

}

function validate() {
    //sender is the button, parent is the paragraph, childNode[1] is the input

    if (input.value === "") { return false; }

    let href = "/home/validate/" + UserName + "|" + input.value;

    window.location.href = href;

}

let msgIndex = -1;
let msg = [];


function RotateMessage() {
    msgIndex++;
    if (msgIndex === msg.length) msgIndex = 0;
    MsgText.innerHTML = msg[msgIndex];
}

function LoadMessages() {
    msg.push("At The");
    msg.push("VERY LEAST");
    msg.push("You Will Be Paid");
    let tmp = "$" + BaseValue +".00";
    msg.push(tmp);
    msg.push("For Every Other Sale");
    msg.push("Your Big Button Generates");
    msg.push("Starting With Your Second!");
    msg.push("And Maybe More");
    msg.push("Maybe A Lot More");
}


let clsIndex;
let cls = [];
let txt = []

function LoadImages() {
    cls.push("button-img-01");
    txt.push("button-txt-01");
    cls.push("button-img-02");
    txt.push("button-txt-02");
    cls.push("button-img-03");
    txt.push("button-txt-03");
    cls.push("button-img-04");
    txt.push("button-txt-04");
    cls.push("button-img-05");
    txt.push("button-txt-05");
    cls.push("button-img-06");
    txt.push("button-txt-06");
    cls.push("button-img-07");
    txt.push("button-txt-07");
    cls.push("button-img-08");
    txt.push("button-txt-08");
    return cls.length;

}

function RotateImages() {
    clsIndex++;
    if (clsIndex === cls.length) clsIndex = 0;
    ButtonImage.className = cls[clsIndex];
    UserNameDiv.className = txt[clsIndex];
    ClickCounter.className = txt[clsIndex];
}

function getRandom(min, max) {
    let random = Math.random() * (+max - +min) + +min;
    return Math.floor(random);
}
 