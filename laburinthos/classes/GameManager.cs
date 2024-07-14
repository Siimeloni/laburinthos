using System;
using Avalonia.Controls;
using Avalonia.Input;
using System.Xml.Serialization;
using System.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using laburinthos;
using System.Collections.Generic;

public class GameManager{
    enum Method{
        BinaryTree,
        OriginShift,
        RandomizeKruskal
    }
    enum Modus{
        normal,
        blind
    }

    static Direction way;
    static int[] pos;
    static byte size;
    static ConnectionNode[,] grid;

    public static void LabyrinthInit(int method, int modus, byte Size){
        size = Size;
        switch (method){
            case 0:
                grid = BinaryTreeGenerator.GenerateLabyrinth(size);
                break;
            case 1:
                grid = OriginShiftGenerator.GenerateLabyrinth(size);
                break;
            case 2:
                grid = KruskalGenerator.GenerateLabyrinth(size);
                break;
        }
    }

    public static void Moving(Direction direction){

        Player Plyr = new Player();

        switch (direction) {
            case Direction.Up:
                if (grid[Plyr.PositionY,Plyr.PositionX].connections[0] == true) {
                    Plyr.MoveUp();
                    LabyrinthPrinter.PrintPlayerMovement([Plyr.PositionX,Plyr.PositionY], Direction.Up);
                }
                break;
            case Direction.Left:
                if (grid[Plyr.PositionY,Plyr.PositionX].connections[3] == true) {
                    Plyr.MoveLeft();
                    LabyrinthPrinter.PrintPlayerMovement([Plyr.PositionX,Plyr.PositionY], Direction.Left);
                }
                break;
            case Direction.Down:
                if (grid[Plyr.PositionY,Plyr.PositionX].connections[2] == true) {
                    Plyr.MoveDown();
                    LabyrinthPrinter.PrintPlayerMovement([Plyr.PositionX,Plyr.PositionY], Direction.Down);
                }
                break;
            case Direction.Right:
                if (grid[Plyr.PositionY,Plyr.PositionX].connections[1] == true) {
                    Plyr.MoveRight();
                    LabyrinthPrinter.PrintPlayerMovement([Plyr.PositionX,Plyr.PositionY], Direction.Right);
                }
                break;
        }
        //check if player is on end-node:
        if (Plyr.PositionX==size-1 && Plyr.PositionY==size-1){
            System.Console.WriteLine("Congratulations, you did it. The game is over.");
        }        
    }

}