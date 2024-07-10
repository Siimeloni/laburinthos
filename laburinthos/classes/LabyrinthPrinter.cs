using System;
using laburinthos;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

public static class LabyrinthPrinter {

    public static void PrintLabyrinthConnection(ConnectionNode[,] grid, byte size) {
        int imageSize = 2*size+1;
        Image<Rgb24> image = new(imageSize, imageSize);
        int scaledImageSize = (int)(imageSize*Math.Floor(700.0f/(float)imageSize));
        Rgb24 Wall = new Rgb24(66, 110, 93);
        Rgb24 Path = new Rgb24(229, 176, 131);

        for (int i = 0; i<imageSize; i++) {
            for (int j = 0; j<imageSize; j++) {
                image[i,j] = Wall;
            }
        }

        foreach (ConnectionNode node in grid) {
            int posX = 2*node.positionX+1;
            int posY = 2*node.positionY+1;
            image[posX,posY] = Path;

            if (node.connections[1]) { image[posX+1, posY] = Path; }
            if (node.connections[2]) { image[posX,posY+1] = Path;}
        }

        image[1,0] = Path;
        image[imageSize-2, imageSize-1] = Path;

        image.Mutate(x => x.Resize(scaledImageSize,scaledImageSize, KnownResamplers.NearestNeighbor));
        string text = "labyrinth.bmp";
        image.SaveAsBmp(text);
        
    }

}
