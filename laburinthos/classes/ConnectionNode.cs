using System;
using System.Collections;

public enum Direction {Up, Right, Down, Left};

public class ConnectionNode : Node {

    public BitArray connections = new BitArray(4);
    public int set;

    public ConnectionNode(byte Y, byte X, int set) : base(Y, X) {
        this.set = set;
    }

    /// <summary>
    /// Assigns the nodes a new valid connection direction
    /// </summary>
    /// <param name="direction"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void SetConnection(Direction direction) {
        switch (direction) {
            case Direction.Up:
                this.connections[0] = true; 
                break;
            case Direction.Right:
                this.connections[1] = true; 
                break;
            case Direction.Down:
                this.connections[2] = true; 
                break;
            case Direction.Left:
                this.connections[3] = true; 
                break;
            default:
                throw new NotImplementedException();
        }
    }

}