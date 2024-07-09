using System;

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

}