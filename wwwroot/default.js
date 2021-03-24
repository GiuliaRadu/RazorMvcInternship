function addNewComer() {
    const node = document.createElement("li");
    if (newcomer.value != "") {
        node.innerText = newcomer.value;
        list.appendChild(node);
        newcomer.value = "";
    }
}

function onInit() {
    //const button = document.getElementById("add");
    add.addEventListener("click", addNewComer);
}

onInit();