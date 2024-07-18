using laburinthos.ViewModels;

public class GameManager {

    static byte size;
    static ConnectionNode[,] grid;
    static Player Plyr;
    public static bool isActive = true; //toggles if player is movable

    public readonly static string FilePath = "Assets/labyrinth.bmp";
    public readonly static string DefaultFilePath = "Assets/default.bmp";
    

    public static void LabyrinthInit(int method, int modus, byte Size) {
        size = Size;
        switch (method) {
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

        LabyrinthPrinter.PrintLabyrinth(grid, size, modus);
    }

    public static void PlayerInit() {
        Plyr = new Player();
        isActive = true;
    }

    public static void Moving(Direction direction, MainViewModel context) {
        if (!isActive) { return; }
        ConnectionNode node = grid[Plyr.PositionY,Plyr.PositionX];
        switch (direction) {
            case Direction.Up:
                if (node.connections[0] == true) {
                    Plyr.MoveUp();
                    node = grid[Plyr.PositionY,Plyr.PositionX];
                    LabyrinthPrinter.PrintPlayerMovement(node, Direction.Up);
                    context.UpdateImage(FilePath);
                }
                break;
            case Direction.Left:
                if (node.connections[3] == true) {
                    Plyr.MoveLeft();
                    node = grid[Plyr.PositionY,Plyr.PositionX];
                    LabyrinthPrinter.PrintPlayerMovement(node, Direction.Left);
                    context.UpdateImage(FilePath);
                }
                break;
            case Direction.Down:
                if (node.connections[2] == true) {
                    Plyr.MoveDown();
                    node = grid[Plyr.PositionY,Plyr.PositionX];
                    LabyrinthPrinter.PrintPlayerMovement(node, Direction.Down);
                    context.UpdateImage(FilePath);
                }
                break;
            case Direction.Right:
                if (node.connections[1] == true) {
                    Plyr.MoveRight();
                    node = grid[Plyr.PositionY,Plyr.PositionX];
                    LabyrinthPrinter.PrintPlayerMovement(node, Direction.Right);
                    context.UpdateImage(FilePath);
                }
                break;
        }

        //check if player is on end-node:
        if (Plyr.PositionX==size-1 && Plyr.PositionY==size-1) {
            EndGame(context);
        }        
    }

    static void EndGame(MainViewModel context) {
            System.Console.WriteLine("Congratulations, you did it. The game is over.");
            isActive = false;
            LabyrinthPrinter.PrintFinalStep();
            context.UpdateImage(FilePath);
    }

}