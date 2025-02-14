using ProgressBarLibrary.ProgressBar; // using placed here to demonstrate implementation

namespace ProgressBarLibrary.Samples;

public class ProgressBarDemo
{
    public static void SampleProgressBar(ProgressBar.ProgressBar PB)
    {
        /* Example Loop from the lower bound value to the upper bound value */
        for (double i = PB.LowerBound; i <= PB.UpperBound; i++)
        {
            PB.LowerBound = i; // To increment the bar (set i to your current value of progress)
            ProgressBar.ProgressBar.PrintProgressBar(PB); // Printing the actual progress bar in the console window
            Thread.Sleep(25);
            Console.WriteLine("Regular bar.");
        }
    }
}
