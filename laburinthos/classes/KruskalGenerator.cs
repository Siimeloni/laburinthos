using System;
using System.Collections.Generic;

public static class KruskalGenerator{

    static ConnectionNode[,] NodeGrid;
    static List<Connection> ConnectionList; 
    static byte LabyrinthSize;

    /// <summary>
    /// Generating the labyrinth with Randomized Kruskal's Algorithmus
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    public static ConnectionNode[,] GenerateLabyrinth(byte size) {
        LabyrinthSize = size;
        NodeGrid = ConstructGrid();
        ConnectionList = ConstructConnections(NodeGrid);

        while(ConnectionList.Count != 0) {
            Random rand = new Random();
            int index = rand.Next(0, ConnectionList.Count);
            Connection connec = ConnectionList[index];
            ConnectionList.RemoveAt(index);

            if (connec.CheckSameSet()) {
                continue;
            } else {
                ConnectNodes(connec.nodeLeft, connec.nodeRight, connec.isVertical);
            }
        }
        
        return NodeGrid;
    }

    static ConnectionNode[,] ConstructGrid() {
        var grid = new ConnectionNode[LabyrinthSize,LabyrinthSize];
        int setCounter = 0;

        for (byte col = 0; col < LabyrinthSize; col++) {
            for (byte row = 0; row < LabyrinthSize; row++) {
                grid[row,col] = new ConnectionNode(row,col, setCounter++);
            }
        }

        return grid;
    }

    static List<Connection> ConstructConnections(ConnectionNode[,] grid) {
        List<Connection> ConnectionList = new List<Connection>();

        for (int row = 0; row < LabyrinthSize-1; row++) {
            for (int element = 0; element < LabyrinthSize; element++) {
                ConnectionList.Add(new Connection(grid[row, element], grid[row+1, element]));
            }
        }
        for (int col = 0; col < LabyrinthSize-1; col++) {
            for (int element = 0; element < LabyrinthSize; element++) {
                ConnectionList.Add(new Connection(grid[element, col], grid[element, col+1]));
            }
        }

        return ConnectionList;
    }

    static void ChangeSet(int setOld, int setNew) {
        for (int col = 0; col < LabyrinthSize; col++) {
            for (int row = 0; row < LabyrinthSize; row++) {
                if (NodeGrid[row, col].set == setOld) {NodeGrid[row, col].set = setNew;}
            }
        }
    }

    /// <summary>
    /// Connects the nodes
    /// </summary>
    /// <param name="node1"></param>
    /// <param name="node2"></param>
    /// <param name="isVertical"></param>
    static void ConnectNodes(ConnectionNode node1, ConnectionNode node2, bool isVertical) {
        if (isVertical) {
            node1.SetConnection(Direction.Down);
            node2.SetConnection(Direction.Up);
        } else {
            node1.SetConnection(Direction.Right);
            node2.SetConnection(Direction.Left);
        }
        ChangeSet(node2.set, node1.set);
    }

}