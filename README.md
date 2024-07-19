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

Es kann zwischen dem "Normal", "Blind" oder "Double Blind" Spielmodus gewählt werden.
Bei der standardmäßigen Variante sieht der Nutzer das gesamte zu durchlaufende Labyrinth, sowie den zurück gelegten Weg. 
Bei dem "Blind" Spielmodus sind stehts nur die Möglichen nächsten Wege, um die aktuelle Position des Spielers, für den Nutzer sichtbar. 
Beim "Double Blind" Spielmodus ist nur die Position, sowie die nächsten Wege sichtbar, jedoch nicht der zurückgelegte Weg. 


## Verwendungshinweise / Anleitung

Nach dem Start der Anwendung ist auf der linken Seite ein "default"-Labyrinth erkennbar, während sich auf der rechten Seite die Kon­fi­gu­ra­ti­ons­mög­lich­keiten für ein Labyrinth befinden. 
Zuerst erfolgt, durch eine ComboBox, die Auswahlmöglichkeit eines Algorithmus. Hierbei ist der "Binary Tree" standardmäßig gesetzt. Anschließend kann die Größe des Labyrinth bestimmt werden. Die Kantenlänge darf hier in einem Bereich von 5 bis 50 liegen, damit eine ausreichend gute Auflösung gewährleistet werden kann. In einer weiteren ComboBox ist der Spielmodus ("Normal"(standardmäßig), "Blind", "Double Blind") auszuwählen. 
Durch die Betätigung des Buttons wird das Labyrinth erstellt. 

Die Steuerung des Spielers (Farbiger Pixel) erfolgt über die Pfeiltasten der Tastatur oder über die Tasten W-A-S-D. Mit der Taste "N" kann ein neues Labyrinth, mit den gleichen Einstellungen, erstelt werden. Der Spieler startet stehts in der linken oberen Ecke und muss das letzte rechte untere Feld erreichen. Das "Laufen" ist nur auf den Wegen möglich, während Wände undurchdringlich sind. Sollte der Spieler das Ziel erreichen, wird er informiert und es sind keine weiteren Bewegungen mehr möglich. 

## Klassendiagramm

![laburinthos](https://www.plantuml.com/plantuml/png/jLPDSziu3BthLt1yKcQTxbsZkbMS9irit7ZYJTjCfmTQWcLCA993GlQwhV_x3gaFoxBYtKiljWmy0dZW0-JtbhYXiX1Cy6LfKD9QsI0Lt5hs4OJ-WZ9JMnR7cXj2BYOJzZDWZB4_Ekxm8jW73VBNvMN75TInPXpbPuJjJ6KWsX0iZc43aYOJDZTAWw7TTCrb3XcB-fOF3lYHoqo0OVNv9vrnWhk2vn2kKC2SqpgoP53c5onY6uLPi0_kFYd2rQwVmLTwL5TmNENbvOIDfgKn8Cdd6B4hf8BhBgap3JgumulQz45cCx3MrTifiDkwmw4cIwBrOFWuLXim1ZEOJDYTHEV67vt00x07UMDu0LjbNjeJd539gIgq08AiMrUYjS3K-wlY4jrodnkL6rwqrVoqn0dJlISGSfFR-YA-VUyLr2AlIXHPik52IUI9rZvrehMtWmdsGS2NbWnFYLL9FwaCsenQMNIbVMKHM-u8M1pduAGKnoYH9fCUxla_S2vu-1mvo9XzzTzErpNV1uCvoiKQLtGB4WmdPLWSLrmwjzAogr5mpvSxFrUXnHzGXMKHcoef8NLrkRpVnjyFgGwkDYhQps08KouS2QN4QoGEPqEfChYFZlECcRC-zgoDEgThI5yMl805aByCbodO1vs2_4puoB2YKO_58F0Hy_KfigPwomkOSSbpCASTH9kaX1jeABzbP4fePMs0PqgAdMj-S-IcNW8iOfNws5isIgm5id-AvYBUB0izEXlc6bQy57GkMbP1kh7Qu-sLknaB2w2roYAKD6Q5oafRFIwwQXWQZxdWEp0-n6kGcTgWpCCCJTNQwBfv6hDKIO9_A3hQQPtXhc-WhNNkFk6yfZtc8EZSO1QT27dCMg5t2B_AqeMggCxK1WgGv9Lx8jm1akpTsQWtABbO4EZkJWj0bWKxXAWuFkcn__PYhHwlrLPMJqxgus1_Cfr7syW2iOYXf9D17DWhOmVtNQdH2w3Ev0vGxJ3mQVqwVdNwF4Iv2KnRc_LlhyGOlcjtk6zxIs7UMQWegLanFU_peDVTdMzUNwlEuHeuP7_IGrRN-F1Kg5SekTdzRG1-q_xjdQy13xG6uw_m_whojFI_J6bVkFZTxusvyXDy9CkEBMoqrsWHRVLIYznsTJ_lkQKx-QYstdBH_ervWGhOlwq5K1q_r9BCcS6yFI2TfmM-Ez9pfzWWU0yoAmjn-l0l "laburinthos")


