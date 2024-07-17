using System;
using System.Collections.Generic;

public static class OriginShiftGenerator {

    static PointerNode[,] PointerGrid;
    static PointerNode currentOrigin;
    static byte LabyrinthSize;

    public static ConnectionNode[,] GenerateLabyrinth(byte size) {
        LabyrinthSize = size;
        PointerGrid = ConstructGrid();

        int numberOfIterations = (int)Math.Pow(LabyrinthSize, 3);
        for (int i = 0; i < numberOfIterations; i++) {
            ShiftOrigin();
        }

        ConnectionNode[,] ConnectionGrid = ConvertToConnectionGrid();
        return ConnectionGrid;
    }

    static PointerNode[,] ConstructGrid() {
        var grid = new PointerNode[LabyrinthSize,LabyrinthSize];
        byte lastCol = (byte)(LabyrinthSize - 1);

        for (byte row = 0; row < LabyrinthSize; row++) {
            for (byte col = 0; col < LabyrinthSize-1; col++) {
                grid[row,col] = new PointerNode(row,col, false, false); //Pointer : Right
            }

            if (row == LabyrinthSize-1) {
                grid[row,lastCol] = new PointerNode(row,lastCol, true, true); //Pointer : None
                currentOrigin = grid[row,lastCol];
            } else {
                grid[row,lastCol] = new PointerNode(row,lastCol, false, true); //Pointer : Down
            }
        }
            return grid;
    }

        

    static void ShiftOrigin() {
        var rand = new Random();
        List<Direction> directions = GetValidPointers(); 
        int index = rand.Next(0,directions.Count);
        Direction newPointerDirection = directions[index];

        currentOrigin.SetPointer(newPointerDirection);
        switch (newPointerDirection) {
            case Direction.Up:
                currentOrigin = PointerGrid[currentOrigin.positionY-1,currentOrigin.positionX];
                currentOrigin.MakeOrigin();
                break;
            case Direction.Right:
                currentOrigin = PointerGrid[currentOrigin.positionY,currentOrigin.positionX+1];
                currentOrigin.MakeOrigin();
                break;
            case Direction.Down:
                currentOrigin = PointerGrid[currentOrigin.positionY+1,currentOrigin.positionX];
                currentOrigin.MakeOrigin();
                break;
            case Direction.Left:
                currentOrigin = PointerGrid[currentOrigin.positionY,currentOrigin.positionX-1];
                currentOrigin.MakeOrigin();
                break;
            default:
                throw new NotImplementedException();
        }
        
    }

    static List<Direction> GetValidPointers() {
        List<Direction> validPointers = new List<Direction>();
        if (currentOrigin.positionX < LabyrinthSize-1) { validPointers.Add(Direction.Right); }
        if (currentOrigin.positionY < LabyrinthSize-1) { validPointers.Add(Direction.Down); }
        if (currentOrigin.positionX > 0) { validPointers.Add(Direction.Left); }
        if (currentOrigin.positionY > 0) { validPointers.Add(Direction.Up); }

        return validPointers;
    }

    static ConnectionNode[,] ConvertToConnectionGrid() {
        ConnectionNode[,] connecGrid = new ConnectionNode[LabyrinthSize,LabyrinthSize];
        Direction ?direction;

        for (byte col = 0; col < LabyrinthSize; col++) {
            for (byte row = 0; row < LabyrinthSize; row++) {
                connecGrid[row,col] = new ConnectionNode(row,col,1);
                direction = PointerGrid[row,col].GetPointer();

                if (direction != null) {
                     connecGrid[row,col].SetConnection((Direction)direction);
                }
            }
        }

        // Set Connection of other Node
        for (byte col = 0; col < LabyrinthSize; col++) {
            for (byte row = 0; row < LabyrinthSize; row++) {
                switch (PointerGrid[row,col].GetPointer()) {
                    case Direction.Up:
                        connecGrid[PointerGrid[row,col].positionY-1,PointerGrid[row,col].positionX].SetConnection(Direction.Down);
                        break;
                    case Direction.Right:
                        connecGrid[PointerGrid[row,col].positionY,PointerGrid[row,col].positionX+1].SetConnection(Direction.Left);
                        break;
                    case Direction.Down:
                        connecGrid[PointerGrid[row,col].positionY+1,PointerGrid[row,col].positionX].SetConnection(Direction.Up);
                        break;
                    case Direction.Left:
                        connecGrid[PointerGrid[row,col].positionY,PointerGrid[row,col].positionX-1].SetConnection(Direction.Right);
                        break;
                    default:
                        break;
                }
            }
        }

        return connecGrid;
    }

}