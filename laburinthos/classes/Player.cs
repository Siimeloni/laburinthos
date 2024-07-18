public class Player{

    private int posX=0, posY=0;

    public int PositionX { get => posX; }
    public int PositionY { get => posY; }

    /// <summary>
    /// Player position change to the right
    /// </summary>
    public void MoveRight() {
        posX = posX + 1;
    }
    /// <summary>
    /// Player position change to the left
    /// </summary>
    public void MoveLeft() {
        posX = posX - 1;
    }
    /// <summary>
    /// Player position change to the up
    /// </summary>
    public void MoveUp() {
        posY = posY - 1;
    }
    /// <summary>
    /// Player position change to the down
    /// </summary>
    public void MoveDown() {
        posY = posY + 1;
    }

}