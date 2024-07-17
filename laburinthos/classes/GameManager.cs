using laburinthos.ViewModels;

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

    static byte size;
    static ConnectionNode[,] grid;
    static Player Plyr;

    public static void LabyrinthInit(int method, int modus, byte Size){
        size = Size;
        switch (method){
            case 0:
                grid = BinaryTreeGenerator.GenerateLabyrinth(size);
                break;
            case 1:
                grid = OriginShiftGenerator.GenerateLabyrinth(size);
                break;
            case 2:
                grid = KruskalGenerator.GenerateLabyrinth(size);
                break;
        }
        LabyrinthPrinter.PrintLabyrinthConnection(grid, size);
    }

    public static void PlayerInit() {
        Plyr = new Player();
    }

    public static void Moving(Direction direction, MainViewModel context){


        switch (direction) {
            case Direction.Up:
                if (grid[Plyr.PositionY,Plyr.PositionX].connections[0] == true) {
                    Plyr.MoveUp();
                    LabyrinthPrinter.PrintPlayerMovement([Plyr.PositionX,Plyr.PositionY], Direction.Up);
                    context.UpdateImage("Assets/labyrinth.bmp");
                }
                break;
            case Direction.Left:
                if (grid[Plyr.PositionY,Plyr.PositionX].connections[3] == true) {
                    Plyr.MoveLeft();
                    LabyrinthPrinter.PrintPlayerMovement([Plyr.PositionX,Plyr.PositionY], Direction.Left);
                    context.UpdateImage("Assets/labyrinth.bmp");
                }
                break;
            case Direction.Down:
                if (grid[Plyr.PositionY,Plyr.PositionX].connections[2] == true) {
                    Plyr.MoveDown();
                    LabyrinthPrinter.PrintPlayerMovement([Plyr.PositionX,Plyr.PositionY], Direction.Down);
                    context.UpdateImage("Assets/labyrinth.bmp");
                }
                break;
            case Direction.Right:
                if (grid[Plyr.PositionY,Plyr.PositionX].connections[1] == true) {
                    Plyr.MoveRight();
                    LabyrinthPrinter.PrintPlayerMovement([Plyr.PositionX,Plyr.PositionY], Direction.Right);
                    context.UpdateImage("Assets/labyrinth.bmp");
                }
                break;
        }
        //check if player is on end-node:
        if (Plyr.PositionX==size-1 && Plyr.PositionY==size-1){
            System.Console.WriteLine("Congratulations, you did it. The game is over.");
        }        
    }

}