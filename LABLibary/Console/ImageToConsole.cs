using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = System.Drawing.Color;
using Console = System.Console;

namespace LABLibary.Console
{
    public class ImageToConsole
    {
        private readonly ConsoleColor[,] _pixels;

        public ImageToConsole(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                throw new ArgumentException("Image path cannot be null or empty.", nameof(imagePath));
            }

            var bitmap = new Bitmap(imagePath);
            var width = bitmap.Width;
            var height = bitmap.Height;
            _pixels = new ConsoleColor[height, width];

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    var color = bitmap.GetPixel(col, row);
                    _pixels[row, col] = GetClosestConsoleColor(color);
                }
            }
        }

        public void Display()
        {
            var height = _pixels.GetLength(0);
            var width = _pixels.GetLength(1);

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    System.Console.BackgroundColor = _pixels[row, col];
                    System.Console.Write(" ");
                }

                System.Console.WriteLine();
            }
        }

        private ConsoleColor GetClosestConsoleColor(System.Drawing.Color color)
        {
            ConsoleColor closestColor = ConsoleColor.Black;
            double closestDistance = double.MaxValue;

            foreach (ConsoleColor consoleColor in Enum.GetValues(typeof(ConsoleColor)))
            {
                var consoleColorValue = Color.FromName(consoleColor.ToString());
                var distance = ColorDistance(color, consoleColorValue);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestColor = consoleColor;
                }
            }

            return closestColor;
        }

        private double ColorDistance(Color color1, Color color2)
        {
            var r1 = color1.R;
            var g1 = color1.G;
            var b1 = color1.B;

            var r2 = color2.R;
            var g2 = color2.G;
            var b2 = color2.B;

            var rMean = (r1 + r2) / 2.0;
            var rDiff = r1 - r2;
            var gDiff = g1 - g2;
            var bDiff = b1 - b2;

            var distance = Math.Sqrt((2 + rMean / 256.0) * Math.Pow(rDiff, 2) + 4 * Math.Pow(gDiff, 2) + (2 + (255 - rMean) / 256.0) * Math.Pow(bDiff, 2));

            return distance;
        }
    }
}
