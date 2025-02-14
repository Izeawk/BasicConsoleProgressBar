using System;
using System.Threading;

namespace ProgressBarLibrary.ProgressBar;

public class ProgressBar
{
    public ProgressBar(int LowerBound, int UpperBound)
    {
        this.LowerBound = LowerBound;
        this.UpperBound = UpperBound;
    }

    public ProgressBar(int LowerBound, int UpperBound, string Graphic)
    {
        this.LowerBound = LowerBound;
        this.UpperBound = UpperBound;
        this.Graphic = Graphic;
    }

    public ProgressBar(int LowerBound, int UpperBound, ConsoleColor Color)
    {
        this.LowerBound = LowerBound;
        this.UpperBound = UpperBound;
        this.Color = Color;
    }

    public ProgressBar(int LowerBound, int UpperBound, string Graphic, ConsoleColor Color)
    {
        this.LowerBound = LowerBound;
        this.UpperBound = UpperBound;
        this.Graphic = Graphic;
        this.Color = Color;
    }

    public ProgressBar(int LowerBound, int UpperBound, bool ShowPercentage, int PercentagePosition)
    {
        this.LowerBound = LowerBound;
        this.UpperBound = UpperBound;
        this.ShowPercentage = ShowPercentage;
        this.PercentagePosition = PercentagePosition;
    }

    public ProgressBar(int LowerBound, int UpperBound, string Graphic, bool ShowPercentage, int PercentagePosition)
    {
        this.LowerBound = LowerBound;
        this.UpperBound = UpperBound;
        this.Graphic = Graphic;
        this.ShowPercentage = ShowPercentage;
        this.PercentagePosition = PercentagePosition;
    }

    public ProgressBar(int LowerBound, int UpperBound, string Graphic, ConsoleColor Color, bool ShowPercentage, int PercentagePosition)
    {
        this.LowerBound = LowerBound;
        this.UpperBound = UpperBound;
        this.Graphic = Graphic;
        this.Color = Color;
        this.ShowPercentage = ShowPercentage;
        this.PercentagePosition = PercentagePosition;
    }

    public string? Graphic { get; set; } = "■";
    public ConsoleColor Color { get; set; } = ConsoleColor.White;
    public bool? ShowPercentage { get; set; } = null;
    public int PercentagePosition { get; set; } = 3; // 0 = off, 1 = left, 2 = right, 3 = inside
    public double LowerBound { get; set; } = 0;
    public double UpperBound { get; set; } = 100;

    private static bool IsFirstPass = true;
    private static int FirstPassLine = 0;

    public static void PrintProgressBar(ProgressBar PB)
    {
        Console.CursorVisible = false;
        int Percentage = (int)Math.Round(PB.LowerBound / PB.UpperBound * 100, 0);
        Console.ForegroundColor = PB.Color;

        if (IsFirstPass)
        {
            IsFirstPass = false;
            FirstPassLine = Console.GetCursorPosition().Top + 1;
        }

        if (PB.ShowPercentage != null && PB.ShowPercentage != false)
        {
            Console.SetCursorPosition(0, FirstPassLine);
            switch (PB.PercentagePosition)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\r{0}  ", $"{Percentage}%");

                    Console.ForegroundColor = PB.Color;
                    Console.Write($"[{string.Concat(Enumerable.Repeat(PB.Graphic, Percentage))}{string.Concat(Enumerable.Repeat(" ", 100 - Percentage))}]");
                    break;
                case 2:
                    Console.ForegroundColor = PB.Color;
                    Console.Write("\r{0}  ", $"[{string.Concat(Enumerable.Repeat(PB.Graphic, Percentage))}{string.Concat(Enumerable.Repeat(" ", 100 - Percentage))}]");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{Percentage}%");
                    break;
                case 3:
                    Console.ForegroundColor = PB.Color;
                    Console.WriteLine("\r{0}  ", $"[{string.Concat(Enumerable.Repeat(PB.Graphic, Percentage))}{string.Concat(Enumerable.Repeat(" ", 100 - Percentage))}]");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(50, Console.CursorTop - 1);
                    Console.Write($"{Percentage}%");
                    break;
            }
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            Console.ResetColor();
        }

        else
        {
            Console.SetCursorPosition(0, FirstPassLine);

            Console.ForegroundColor = PB.Color;
            Console.Write("\r{0}  ", $"[{string.Concat(Enumerable.Repeat(PB.Graphic, Percentage))}{string.Concat(Enumerable.Repeat(" ", 100 - Percentage))}]");

            Console.SetCursorPosition(0, Console.CursorTop + 1);
            Console.ResetColor();
        }

        if (PB.LowerBound == PB.UpperBound) // process is 100% complete, thread can end
        {
            Console.CursorVisible = true;
            Console.ResetColor();
            IsFirstPass = true;
        }
    }
}
