public abstract class Node{

    public byte positionX{ get; init; }
    public byte positionY{ get; init; }

    public Node(byte Y, byte X){
        this.positionX = X;
        this.positionY = Y;
    }

}