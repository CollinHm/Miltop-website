$(document).ready(function () {
    const weekday = ["Zondag", "Maandag", "Dinsdag", "Woensdag", "Donderdag", "Vrijdag", "Zaterdag"];

    function updateClock() {
        const d = new Date();

        const day = weekday[d.getDay()];
        const hours = d.getHours();
        const minutes = d.getMinutes();

        const time = `${hours}:${minutes.toString().padStart(2, '0')}`;

        document.getElementById('day').textContent = day;
        document.getElementById('time').textContent = time;
    }

    updateClock();          // direct tonen
    setInterval(updateClock, 1000); // elke seconde verversen


    const tempSlider = document.getElementById("tempSlider");
    const rainSlider = document.getElementById("rainSlider");
    const water = document.getElementById("water");

    let waterLevel = 50; // %

    function updateWater() {
        const rain = Number(rainSlider.value);
        const temp = Number(tempSlider.value);

        const rainEffect = (rain - 50) * 0.02;
        const tempEffect = (temp - 25) * 0.02;

        waterLevel += rainEffect - tempEffect;

        waterLevel = Math.max(0, Math.min(100, waterLevel));
        water.style.height = `${waterLevel}%`;
    }

    setInterval(updateWater, 100);

    tempSlider.addEventListener("input", updateWater);
    rainSlider.addEventListener("input", updateWater);


})

$(function () {
    $('.fdf-weetjes__question__title').on('click', function () {
        $(this).parent().toggleClass('active');
    });

});

function updateSeasonTree() {
    const month = new Date().getMonth() + 1; // 1 t/m 12

    const tree = document.getElementById("seasonTree");

    if (month >= 3 && month <= 5) {
        tree.src = "./img/cherry-tree-png.png";
    } else if (month >= 6 && month <= 8) {
        tree.src = "./img/tree-normal-png.png";
    } else if (month >= 9 && month <= 11) {
        tree.src = "./img/autumn-tree-png.png";
    } else {
        tree.src = "./img/tree-snowy-png.png";
    }
}

updateSeasonTree();
