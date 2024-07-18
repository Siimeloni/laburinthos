public class Connection {
    public ConnectionNode nodeLeft { get; init; }
    public ConnectionNode nodeRight { get; init; }
    public bool isVertical { get; init; }

    public Connection(ConnectionNode nodeL, ConnectionNode nodeR) {
        this.nodeLeft = nodeL;
        this.nodeRight = nodeR;
        if (nodeL.positionX == nodeR.positionX) {
            this.isVertical = true;
        } else {
            this.isVertical = false;
        }
    }

    /// <summary>
    /// checks if both nodes are in the same set
    /// </summary>
    /// <returns></returns>
    public bool CheckSameSet() {
        if (nodeLeft.set == nodeRight.set) {
            return true;
        } else {
            return false;
        }
    }
}