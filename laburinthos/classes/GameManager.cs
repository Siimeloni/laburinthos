using laburinthos.ViewModels;

public class GameManager {

    enum Method {
        BinaryTree,
        OriginShift,
        RandomizeKruskal
    }
    enum Modus {
        normal,
        blind
    }

    static byte size;
    static ConnectionNode[,] grid;
    static Player Plyr;
    public static bool isActive = true; //toggles if player is movable

    public readonly static string FilePath = "Assets/labyrinth.bmp";
    public readonly static string DefaultFilePath = "Assets/default.bmp";
    
    /// <summary>
    /// Initialization of the labyrinth - calling the desired algorithm
    /// </summary>
    /// <param name="method"></param>
    /// <param name="modus"></param>
    /// <param name="Size"></param>
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

        LabyrinthPrinter.PrintLabyrinth(grid, size);
    }

    /// <summary>
    /// Initialize player; activate movement for it
    /// </summary>
    public static void PlayerInit() {
        Plyr = new Player();
        isActive = true;
    }

    /// <summary>
    /// Reaction according to the desired movement. Player movement; call LabyrinthPrinter; update of image in GUI.
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="context"></param>
    public static void Moving(Direction direction, MainViewModel context) {
        if (!isActive) { return; }
        switch (direction) {
            case Direction.Up:
                if (grid[Plyr.PositionY,Plyr.PositionX].connections[0] == true) {
                    Plyr.MoveUp();
                    LabyrinthPrinter.PrintPlayerMovement([Plyr.PositionX,Plyr.PositionY], Direction.Up);
                    context.UpdateImage(FilePath);
                }
                break;
            case Direction.Left:
                if (grid[Plyr.PositionY,Plyr.PositionX].connections[3] == true) {
                    Plyr.MoveLeft();
                    LabyrinthPrinter.PrintPlayerMovement([Plyr.PositionX,Plyr.PositionY], Direction.Left);
                    context.UpdateImage(FilePath);
                }
                break;
            case Direction.Down:
                if (grid[Plyr.PositionY,Plyr.PositionX].connections[2] == true) {
                    Plyr.MoveDown();
                    LabyrinthPrinter.PrintPlayerMovement([Plyr.PositionX,Plyr.PositionY], Direction.Down);
                    context.UpdateImage(FilePath);
                }
                break;
            case Direction.Right:
                if (grid[Plyr.PositionY,Plyr.PositionX].connections[1] == true) {
                    Plyr.MoveRight();
                    LabyrinthPrinter.PrintPlayerMovement([Plyr.PositionX,Plyr.PositionY], Direction.Right);
                    context.UpdateImage(FilePath);
                }
                break;
        }

        //check if player is on end-node:
        if (Plyr.PositionX==size-1 && Plyr.PositionY==size-1) {
            EndGame(context);
        }        
    }

    /// <summary>
    /// Reaction when game is won - no more player movements possible; update image
    /// </summary>
    /// <param name="context"></param>
    static void EndGame(MainViewModel context) {
            System.Console.WriteLine("Congratulations, you did it. The game is over.");
            isActive = false;
            LabyrinthPrinter.PrintFinalStep();
            context.UpdateImage(FilePath);
    }

}