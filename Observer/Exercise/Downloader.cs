namespace Observer.Exercise;

// Simulate download progress (0–100); no actual downloading is required.
// Add two subscribers: one prints progress after each change, the other prints
// "Download complete" when progress reaches 100. Repeating a value must not notify.
// Demonstrate updates at 10, 50, and 100, and unsubscribing the progress display
// while keeping the completion notification subscribed.
// Implement two variants: OOP Observer with an interface, and C# delegates/events.
public class Downloader
{

    private readonly List<IChangeListener> eventListeners = new();

    public int percentage;

    public void AddListener(IChangeListener listener)
    {
        eventListeners.Add(listener);
    }

        public void RemoveListener(IChangeListener listener)
    {
        eventListeners.Remove(listener);
    }


    public void UpdateProgress(int percentage)
    {        
        if (percentage == this.percentage)
        {
            return;
        }
        else
        {
            this.percentage = percentage;
            foreach (var listener in eventListeners)
            {
                listener.OnProgressChanged(this.percentage);
            }
        }
    }

}


class ProgressDisplay : IChangeListener
{

    public void OnProgressChanged(int percentage)
    {
        System.Console.WriteLine($"Current progress: {percentage}");
    }
}

class CompleteListener : IChangeListener
{

    public void OnProgressChanged(int percentage)
    {
        if (percentage == 100)
        {
            System.Console.WriteLine($"Finished progress: {percentage}");
        }
    }
}
