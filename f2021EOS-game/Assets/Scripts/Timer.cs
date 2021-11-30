using System;

public class Timer
{
    private double timeLeft;

    public Timer(double time)
    {
        this.timeLeft = time;
    }

    public void Tick(double amount)
    {
        if (timeLeft > 0)
        {
            timeLeft -= amount;
        }

        if (timeLeft < 0)
        {
            timeLeft = 0;
        }
    }

    public bool Done()
    {
        return timeLeft == 0;
    }

    public string GetText()
    {
        int minutes = (int)(timeLeft / 60);
        int seconds = (int)(timeLeft - (minutes * 60));

        return String.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
