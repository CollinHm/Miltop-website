import express from "express";
import fetch from "node-fetch";

const app = express();

app.get("/api/grondwater", async (req, res) => {
    try {
        const now = Math.floor(Date.now() / 1000);
        const yesterday = now - 86400;

        const url = `https://tbundertje.gwmn.nl/api/v2/measurements/GWS/?start_date=${yesterday}&end_date=${now}`;

        const response = await fetch(url);
        const data = await response.json();

        res.json(data);
    } catch (err) {
        res.status(500).json({ error: "Server error" });
    }
});

app.listen(63342, () => {
    console.log("Server running on http://localhost:63342");
});