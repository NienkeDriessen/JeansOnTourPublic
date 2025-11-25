# JeansOnTour
Laatste update: juni 2024
In opdracht van TU Delft Science Centre 
Door Sara Kooistra, {} en {}

# Puzzle scene 
In de puzzle scene moeten alle patroonstukken (met tag JeansPart) binnen de bounds van de JeansFabric komen te liggen. De CanvasGroup.alpha van de knipbutton (CutOut -> Knippen) wordt dan op 1 gezet en zichtbaar. Er mogen dan geen JeansParts met elkaar colliden. Als er geknipt worden worden de JeansParts grijs gekleurd en wordt de (high)score berekend. De volgende scripts zijn hiervoor geschreven: 
## BoundingBox.cs
Bepaalt de bounds waarbinnen de JeansParts liggen en het percentage van de stof dat dit omvat. Legt de objects van de bounds (Bounds -> LeftBound etc.) op de juiste plaats.
## Collision.cs

## CutOut.cs
## DragDrop.cs
## HighScore.cs
## JeansOnFabric.cs
## NoVelocity.cs
## percentageText.cs
## Restart.cs
