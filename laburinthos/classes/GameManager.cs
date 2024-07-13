using System;
using Avalonia.Controls;
using Avalonia.Input;
using System.Xml.Serialization;

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

    public static void Moving(MenuItem direction){
        var test = direction.HotKey;
        System.Console.WriteLine(test);
    }

}