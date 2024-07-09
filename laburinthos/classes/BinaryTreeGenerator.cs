using System;

public static class BinaryTreeGenerator{

    static ConnectionNode[,] NodeGrid;

    public static void GenerateLabyrinth(byte size) {
        NodeGrid = ConstructGrid(size);

        for (int col = (size-1); col >= 0; col--) {
            for (int row = (size-1); row >= 0; row--) {
                ChooseDirection(NodeGrid[row,col]);
            }
        }

        LabyrinthPrinter.PrintLabyrinthConnection(NodeGrid, size);
    }

    static ConnectionNode[,] ConstructGrid(byte size) {
        var grid = new ConnectionNode[size,size];

        for (byte col = 0; col < size; col++) {
            for (byte row = 0; row < size; row++) {
                grid[row,col] = new ConnectionNode(row,col,1);
            }
        }

        return grid;
    }

    static void ChooseDirection(ConnectionNode node) {
        Direction direction;
        Direction[] possibleDirections = [Direction.Up, Direction.Left];
        var rand = new Random();

        if (node.positionX == 0 && node.positionY == 0) {
            return;
        } else if (node.positionX == 0) {
            direction = Direction.Up;
        } else if (node.positionY == 0) {
            direction = Direction.Left;
        } else {
            int index = rand.Next(0,2);
            direction = possibleDirections[index];
        }

        node.SetConnection(direction);
        ConnectOtherNode(node, direction);

    }

    public static void ConnectOtherNode(ConnectionNode node, Direction direction) {
        switch (direction) {
            case Direction.Up:
                NodeGrid[node.positionY-1, node.positionX].SetConnection(Direction.Down);
                break;
            case Direction.Left:
                NodeGrid[node.positionY, node.positionX-1].SetConnection(Direction.Right);
                break;
            default:
                break;
        }
    }

}