# laburinthos

Im Rahmen des Abschlussprojektes Softwareentwicklung SS24 wurde durch:

- Maik Simon Mikoszek
- Janette Tetzner

das Projekt **"laburinthos"** erstellt.

Es handelt sich um einen Labyrinth-Generator, mit der Option dieses als Spieler zu durchlaufen. 


## Umsetzung

Die Ziele (näheres im Wiki) umfassten die Erstellung 
- einer grafischen Benutzeroberfläche, 
- eines konfigurierbaren Labyrinths, und
- eines Spielers, welcher den Weg von Start- zu Endpunkt finden kann.

Für die Erzeugung des Projektes und der Oberfläche wurde ein Avalonia UI Projekt erstellt. 

Es wurden drei unterschiedliche Algorithmen für die Erstellung der Labyrinthe verwendet:

- Binary Tree Algorithmus
- Randomized Kruskal's Algorithmus
- Origin Shift

Die eben genannten Algorithmen werden im Wiki dieses Repositorys näher erläutert. 

Es kann zwischen dem "normalen" oder "blinden" Spielmodus gewählt werden.
Bei der standartmäßigen Variante sieht der Nutzer das gesamte zu durchlaufende Labyrinth.
Bei dem "blinden" Spielmodus ist stehts nur ein Außschnitt, um die aktuelle Position des Spielers, für den Nutzer sichtbar. 


## Verwendungshinweise / Anleitung

Nach dem Start der Anwendung ist auf der linken Seite ein "default"-Labyrinth erkennbar, während sich auf der rechten Seite die Kon­fi­gu­ra­ti­ons­mög­lich­keiten für ein Labyrinth befinden. 
Zuerst erfolgt, durch eine ComboBox, die Auswahlmöglichkeit eines Algorithmus. Hierbei ist der "Binary Tree" standartmäßig gesetzt. Anschließend kann die Größe des Labyrinth bestimmt werden. Die Kantenlänge darf hier in einem Bereich von 5 bis 50 liegen, damit eine ausreichend gute Auflösung gewährleistet werden kann. In einer weiteren ComboBox ist der Spielmodus ("normal"(standartmäßig) oder "blind") auszuwählen. 
Durch die Betätigung des Buttons wird das Labyrinth erstellt. 

Die Steuerung des Spielers (Farbiger Pixel) erfolgt über die Pfeiltasten der Tastatur oder über die Tasten W-A-S-D. Mit der Taste "N" kann ein neues Labyrinth, mit den gleichen Einstellungen, erstelt werden. Der Spieler startet stehts in der linken oberen Ecke und muss das letzte rechte untere Feld erreichen. Das "Laufen" ist nur auf den Wegen möglich, während Wände undurchdringlich sind. Sollte der Spieler das Ziel erreichen, wird er informiert und es sind keine weiteren Bewegungen mehr möglich. 

## Klassendiagramm



