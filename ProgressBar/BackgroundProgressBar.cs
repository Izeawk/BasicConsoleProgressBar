namespace ProgressBarLibrary.ProgressBar;

public class BackgroundProgressBar
{
    public BackgroundProgressBar(int LowerBound, int UpperBound)
    {
        this.LowerBound = LowerBound;
        this.UpperBound = UpperBound;
    }

    public BackgroundProgressBar(int LowerBound, int UpperBound, ConsoleColor ForegroundColor, ConsoleColor BackgroundColor)
    {
        this.LowerBound = LowerBound;
        this.UpperBound = UpperBound;
        this.ForegroundColor = ForegroundColor;
        this.BackgroundColor = BackgroundColor;
    }

    public BackgroundProgressBar(int LowerBound, int UpperBound, bool ShowPercentage, int PercentagePosition)
    {
        this.LowerBound = LowerBound;
        this.UpperBound = UpperBound;
        this.ShowPercentage = ShowPercentage;
        this.PercentagePosition = PercentagePosition;
    }

    public BackgroundProgressBar(int LowerBound, int UpperBound, ConsoleColor ForegroundColor, ConsoleColor BackgroundColor, bool ShowPercentage, int PercentagePosition)
    {
        this.LowerBound = LowerBound;
        this.UpperBound = UpperBound;
        this.ForegroundColor = ForegroundColor;
        this.ShowPercentage = ShowPercentage;
        this.PercentagePosition = PercentagePosition;
    }

    public ConsoleColor ForegroundColor { get; set; } = ConsoleColor.Green;
    public ConsoleColor BackgroundColor { get; set; } = ConsoleColor.DarkRed;
    public bool? ShowPercentage { get; set; } = null;
    public int PercentagePosition { get; set; } = 3; // 1 = left, 2 = right, 3 = inside
    public double LowerBound { get; set; } = 0;
    public double UpperBound { get; set; } = 100;

    public static void PrintProgressBar(BackgroundProgressBar BPB)
    {
        Console.CursorVisible = false;
        int Percentage = (int)Math.Round((BPB.LowerBound / BPB.UpperBound) * (Console.WindowWidth), 0);
        int HundredthPercent = (int)Math.Round(((double)Percentage / Console.WindowWidth)*100, 0);
        string PercentageToPrint = $"{HundredthPercent}%";

        if (BPB.ShowPercentage != null && BPB.ShowPercentage != false)
        {
            switch (BPB.PercentagePosition)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\r{0}", PercentageToPrint);

                    Console.ForegroundColor = BPB.ForegroundColor;
                    Console.Write($"{string.Concat(Enumerable.Repeat("█", Math.Max(0, Percentage - PercentageToPrint.Length)))}");
                    
                    Console.ForegroundColor = BPB.BackgroundColor;
                    Console.Write($"{string.Concat(Enumerable.Repeat("█", Math.Max(0, Console.WindowWidth - Math.Max(0, Percentage - PercentageToPrint.Length) - PercentageToPrint.Length)))}");
                    break;
                case 2:
                    Console.ForegroundColor = BPB.ForegroundColor;
                    Console.Write("\r{0}", $"{string.Concat(Enumerable.Repeat("█", Math.Max(0, Percentage - PercentageToPrint.Length)))}");

                    Console.ForegroundColor = BPB.BackgroundColor;
                    Console.Write($"{string.Concat(Enumerable.Repeat("█", Math.Max(0, Console.WindowWidth - Math.Max(0, Percentage - PercentageToPrint.Length) - PercentageToPrint.Length)))}");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(PercentageToPrint);
                    break;
                case 3:
                    Console.ForegroundColor = BPB.ForegroundColor;
                    Console.Write("\r{0}", $"{string.Concat(Enumerable.Repeat("█", Math.Max(0, Percentage)))}");

                    Console.ForegroundColor = BPB.BackgroundColor;
                    Console.Write($"{string.Concat(Enumerable.Repeat("█", Math.Max(0, Console.WindowWidth - Math.Max(0, Percentage))))}");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(Console.WindowWidth / 2, Console.CursorTop);
                    Console.Write(PercentageToPrint);
                    break;
            }
        }

        else
        {
            Console.ForegroundColor = BPB.ForegroundColor;
            Console.Write("\r{0}", $"{string.Concat(Enumerable.Repeat("█", Percentage))}");
            Console.ForegroundColor = BPB.BackgroundColor;
            Console.Write($"{string.Concat(Enumerable.Repeat("█", Console.WindowWidth - Percentage))}");
        }

        if (BPB.LowerBound == BPB.UpperBound) // process is 100% complete
        {
            Console.CursorVisible = true;
            Console.ResetColor();
            Console.SetCursorPosition(0, Console.CursorTop + 1);
        }
    }
}

