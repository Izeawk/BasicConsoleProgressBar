namespace ProgressBarLibrary.Samples;

public class BackgroundBarDemo
{
    public static void SampleBackgroundProgressBar(ProgressBar.BackgroundProgressBar BPB)
    {
        /* Example Loop from the lower bound value to the upper bound value */
        for (double i = BPB.LowerBound; i <= BPB.UpperBound; i++)
        {
            BPB.LowerBound = i; // To increment the bar (set i to your current value of progress)
            ProgressBar.BackgroundProgressBar.PrintProgressBar(BPB); // Printing the actual progress bar in the console window
            Console.WriteLine($"Processing File #:{i}");
            Thread.Sleep(25);
        }
    }
}
