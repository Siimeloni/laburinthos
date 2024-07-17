public class Player{

    private int posX=0, posY=0;

    public int PositionX { get => posX; }
    public int PositionY { get => posY; }

    public void MoveRight(){
        posX = posX + 1;
    }
    public void MoveLeft(){
        posX = posX - 1;
    }
    public void MoveUp(){
        posY = posY - 1;
    }
    public void MoveDown(){
        posY = posY + 1;
    }

}