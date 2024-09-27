using System;
using System.IO;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

class AsciiArt
{
    // 밝기 값에 따라 아스키 문자를 매핑하는 배열

    private AsciiArt()
    {
    }

    public static void Draw(string imagePath, int asciiWidth = 45)
    {
        Draw(imagePath, Console.CursorLeft, Console.CursorTop, asciiWidth);
    }
    public static void Draw(string imagePath, int cursorX, int cursorY, int asciiWidth = 45)
    {
        imagePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\" + imagePath;
        using (Image<Rgba32> image = Image.Load<Rgba32>(imagePath))
        {
            // 아스키 아트로 변환
            ShowImageToAscii(image, cursorX, cursorY, asciiWidth);
        }
        Console.ResetColor();
    }

    // 이미지를 아스키 아트로 변환하는 함수
    private static string ShowImageToAscii(Image<Rgba32> image, int cursorX, int cursorY, int asciiWidth)
    {
        int asciiHeight = (int)(image.Height / (double)image.Width * asciiWidth); // 이미지 비율 유지
        image.Mutate(x => x.Resize(asciiWidth, asciiHeight)); // 이미지 크기 조정

        StringBuilder asciiArt = new StringBuilder();

        for (int y = 0; y < image.Height; y++)
        {
            Console.SetCursorPosition(cursorX, cursorY + y);
            for (int x = 0; x < image.Width; x++)
            {
                Rgba32 pixelColor = image[x, y];

                // 각 픽셀의 밝기 계산
                int brightness = (int)((pixelColor.R + pixelColor.G + pixelColor.B) / 3.0);

                // 아스키 문자와 색상 정보 추가
                Console.Write($"\x1b[38;2;{pixelColor.R};{pixelColor.G};{pixelColor.B}m\x1b[48;2;{pixelColor.R};{pixelColor.G};{pixelColor.B}m@");
            }
        }
        return asciiArt.ToString();
    }
}