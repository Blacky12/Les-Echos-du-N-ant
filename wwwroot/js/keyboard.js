console.log("Fichier js chargée");

window.registerInstance = (dotnetObjectRef) => {
    console.log("Instance Blazor enregistré:", dotnetObjectRef)
    window.blazorInstance = dotnetObjectRef;
}

window.addKeyboardEventListener = () => {
    console.log("Clavier config");
    // alert("addKeyboardEventListener appelé depuis Blazor");
    document.addEventListener("keydown", (event) => {
        let directions = null;

        switch (event.key.toLowerCase()) {
            case "z":
                directions = "up";
                break;
            case "s":
                directions = "down";
                break;
            case "q":
                directions = "left";
                break;
            case "d":
                directions = "right";
                break;
        }

        if (directions) {
            event.preventDefault();
            console.log(`Touche détectée : ${event.key}, direction : ${directions}`);
            window.blazorInstance.invokeMethodAsync("MovePlayer", directions)
                .then(() => console.log(`Direction envoyée à Blazor : ${directions}`))
                .catch((err) => console.error(`Erreur lors de l'appel : ${err}`));
        }

    });
};
