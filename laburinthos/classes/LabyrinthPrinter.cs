using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

public static class LabyrinthPrinter {

    static Image<Rgb24> image;
    static int scaledImageSize;
    static int imageSize;

    static Rgb24 WallColor = new Rgb24(66, 110, 93);          // Color of Walls
    static Rgb24 PathColor = new Rgb24(229, 176, 131);        // Color of Paths
    static Rgb24 PlayerColor = new Rgb24(149, 49, 49);        // Color of the Players Position
    static Rgb24 PlayerPathColor = new Rgb24(193, 112, 112);  // Color of all Paths the Player has already stepped on

    public static void PrintLabyrinth(ConnectionNode[,] grid, byte size, int modus) {
        imageSize = 2*size+1;
        image = new Image<Rgb24>(imageSize, imageSize);
        scaledImageSize = (int)(imageSize*Math.Floor(700.0/imageSize));

        // Fill background
        for (int i = 0; i<imageSize; i++) {
            for (int j = 0; j<imageSize; j++) {
                image[i,j] = WallColor;
            }
        }

        // Fill path
        if (modus == 0) {
            foreach (ConnectionNode node in grid) {
            int posX = 2*node.positionX+1;
            int posY = 2*node.positionY+1;
            image[posX,posY] = PathColor;

            if (node.connections[1]) { image[posX+1, posY] = PathColor; }
            if (node.connections[2]) { image[posX,posY+1] = PathColor; }
            }
        } else {
            if (grid[0,0].connections[1]) { image[2, 1] = PathColor; }
            if (grid[0,0].connections[2]) { image[1,2] = PathColor; }
        }
        

        // Color rim pixels
        image[1,0] = PlayerPathColor;
        image[1,1] = PlayerColor;
        image[imageSize-2, imageSize-1] = PathColor;

        SaveImage(image);
    }

    public static void PrintPlayerMovement(ConnectionNode node, Direction direction) {
        int posX = 2*node.positionX+1;
        int posY = 2*node.positionY+1;

        // Fill possible moving directions
        if (node.connections[0] && image[posX,posY-1]!=PlayerPathColor) { image[posX,posY-1] = PathColor; }
        if (node.connections[1] && image[posX+1,posY]!=PlayerPathColor) { image[posX+1,posY] = PathColor; }
        if (node.connections[2] && image[posX,posY+1]!=PlayerPathColor) { image[posX,posY+1] = PathColor; }
        if (node.connections[3] && image[posX-1,posY]!=PlayerPathColor) { image[posX-1,posY] = PathColor; }

        // Print new player positions and move path
        switch (direction) {
            case Direction.Up:
                image[posX,posY] = PlayerColor;
                image[posX,posY+1] = PlayerPathColor;
                image[posX,posY+2] = PlayerPathColor;
                break;
            case Direction.Right:
                image[posX,posY] = PlayerColor;
                image[posX-1,posY] = PlayerPathColor;
                image[posX-2,posY] = PlayerPathColor;
                break;
            case Direction.Down:
                image[posX,posY] = PlayerColor;
                image[posX,posY-1] = PlayerPathColor;
                image[posX,posY-2] = PlayerPathColor;
                break;
            case Direction.Left:
                image[posX,posY] = PlayerColor;
                image[posX+1,posY] = PlayerPathColor;
                image[posX+2,posY] = PlayerPathColor;
                break;
            default:
                break;
        }

        SaveImage(image);
    }

    public static void PrintFinalStep() {
        image[imageSize-2,imageSize-1] = PlayerPathColor;
        image[imageSize-2,imageSize-2] = PlayerPathColor;

        SaveImage(image);
    }

    static void SaveImage(Image<Rgb24> image) {
        Image<Rgb24> image_out = image.Clone();
        image_out.Mutate(x => x.Resize(scaledImageSize,scaledImageSize, KnownResamplers.NearestNeighbor));
        image_out.SaveAsBmp(GameManager.FilePath);
    } 
}
