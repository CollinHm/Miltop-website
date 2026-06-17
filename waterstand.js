$(document).ready(async function () {
    try {
        const start_date = 1781042400;
        const end_date = 1781128799;

        const url =
            `https://tbundertje.gwmn.nl/api/v2/measurements/gws/` +
            `?start_date=${start_date}` +
            `&end_date=${end_date}`;

        console.log("URL:", url);

        const response = await fetch(url);

        console.log("Status:", response.status);

        const text = await response.text();

        console.log("Response:", text);

        $("#grondwaterStand").text(text);

    } catch (err) {
        console.error("FOUT:", err);
        $("#grondwaterStand").text("Fout bij ophalen data");
    }
});