# Functional Design Document (FDD)
 
    De klant gaat jullie briefen over wat ze willen dat je gaat bouwen.

    Stel vragen om duidelijk te krijgen wat nu eigenlijk de requirements zijn.
    
    Maak dit FDD compleet door die requirements hier op te schrijven!
    Het is tenslotte de basis voor je TDD, je scrum board, en je acceptatietest.

## Functional requirements
Functional requirements zijn de eisen die beschrijven wat het systeem moet doen. Ze zijn gericht op de functionaliteit van het systeem en beschrijven de taken, functies of services die het systeem moet uitvoeren.
Bijvoorbeeld: "Het systeem moet gebruikers kunnen registreren", "Het systeem moet een zoekfunctie hebben", "Het systeem moet een dashboard tonen met statistieken", etc.

Web: 
* de applicatie moet responsive zijn voor telefoon, tablet, laptop en desktop
* de applicatie moet laten zien hoe diep het grondwater zit, met data uit een online databron API
* De omgeving moet meeveranderen met het seizoen/de applicatie moet een seizoensindicator hebben (De omgeving veranderd gebaseerd op het seizoen; bijv: Zomer = zon, lente = bloemen, etc.)
* de user kan schuifbalken gebruiken om regen en temperatuur aan te passen en ziet live hoe dit de grondwaterstand beïnvloedt, je kan direct zien wat er gebeurt met het grondwater
* de applicatie moet educatieve weetjes bevatten (grondwater, drinkwater, milieu. gekoppeld aan de actuele situatie)
* er moet een QR code gemaakt worden, die gelinkt zit aan deze webapplicatie.


Game:
* Maak je eigen water fabriek op basis van informatie die vernoemd wordt.
  Een soort tutorial / introductie achtige game.

* Je krijgt telkens een stap met informatie over wat het onderdeel doet en die moet je zelf neer zetten en aansluiten.
  De stappen duren niet lang en zijn makkelijk om te volgen.
* Zet de onderdelen neer op volgorden en sluit ze allemaal op elkaar aan en zien hoe het werkt.
* Step by step guide moet hints geven wat er als volgend nodig is voor het water als voorbeeld wat moet er gebeuren wanneer het water vies is?
* drag and drop to snap gameobjects (compoments van de fabriek)
* de namen van de compoments staan al bij de compoments
* wanneer de goede compoments er in zitten dan spawnen de pipes er gelijk daar aan
* wanneer de compoments niet goed staan dan spawnen de pipes niet in
* visual indicator wanneer de compoments verkeerd staat
* step by step guide zegt wanneer de laatste geplaatste compoment verkeerd staat
 


## Non-functional requirements
Non-functional requirements zijn de eisen die beschrijven hoe het systeem moet presteren. Ze zijn gericht op de kwaliteit van het systeem en beschrijven de eigenschappen, beperkingen of criteria waaraan het systeem moet voldoen.
Bijvoorbeeld: performance, security, usability, maintainability, etc.

Web:
* De applicatie moet blijven werken, zelfs als er 100 man tegelijk op zitten
* De applicatie moet makkelijk toegankelijk zijn, alles duidelijk aangegeven
* Je hoeft bij deze website niet in te loggen, hier door blijven je privacygegevens veilig
* De applicatie moet er schoon uitzien