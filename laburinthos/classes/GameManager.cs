using System;
using Avalonia.Controls;
using Avalonia.Input;
using System.Xml.Serialization;
using System.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
    public int[] pos;
    byte size;

    public static void LabyrinthInit(int method, int modus, byte size){
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
                break;
            case "Left":
                pos = Spieler.move_left();
                break;
            case "Down":
                pos = Spieler.move_down();
                break;
            case "Right":
                pos = Spieler.move_right();
                break;
        }
        //check if player is on end-node:
        //if (pos[0]==BitConverter.ToInt32(size,0)-1 && pos[1]==BitConverter.ToInt32(size,0)-1){}
        
    }

}