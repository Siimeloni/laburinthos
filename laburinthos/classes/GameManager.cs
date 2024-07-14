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
    enum Direction{
        Up,
        Down,
        Right,
        Left
    }
    static Direction way;
    static int[] pos;
    static byte size;

    public static void LabyrinthInit(int method, int modus, byte Size){
        size = Size;
        switch (method){
            case 0:
                BinaryTreeGenerator.GenerateLabyrinth(size);
                break;
            case 1:
                OriginShiftGenerator.GenerateLabyrinth(size);
                break;
            case 2:
                KruskalGenerator.GenerateLabyrinth(size);
                break;
        }
    }

    public static void Moving(string direction){
        Player Spieler = new Player();
        switch (direction) {
            case "Up":
                int[] pos = Spieler.move_up();
                Direction way = Direction.Up;
                break;
            case "Left":
                pos = Spieler.move_left();
                way = Direction.Left;
                break;
            case "Down":
                pos = Spieler.move_down();
                way = Direction.Down;
                break;
            case "Right":
                pos = Spieler.move_right();
                way = Direction.Right;
                break;
        }
        //check if player is on end-node:
        if (pos[0]==size-1 && pos[1]==size-1){
            System.Console.WriteLine("Congratulations, you did it. The game is over.");
        }

        //handover to labyrinthprinter:
        LabyrinthPrinter.PrintLabyrinthConnection(pos,way);

        
    }

}