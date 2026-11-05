using System.Runtime.InteropServices;

namespace PrayerScheduler;

public class PrayerScheduler
{

    // TODO
    public int NumDailyPrayers => DailyPrayers.Count();
    // TODO
    public int NumNonDailyPrayers => NonDailyPrayers.Count();

    public List<Prayer> DailyPrayers { get; } = new();

    private Queue<Prayer> nonDailyPrayersQueue = new(); 
    public List<Prayer> NonDailyPrayers
    {
        get
        {
            return nonDailyPrayersQueue.ToList();
        }
    }

    public List<Prayer> AnsweredPrayers { get; } = new();

    public PrayerScheduler()
    {
    }

    // TODO
    public void AddPrayer(Prayer prayer)
    {
        // if answered
        // add it to answered
        if(DailyPrayers.Any( p => p.ID == prayer.ID) || AnsweredPrayers.Any( p => p.ID == prayer.ID))
        {
            throw new DuplicateIDException();
        }

        if (prayer.IsAnswered)
        {
            AnsweredPrayers.Add(prayer);
            return;
        }

        //if unanswered
        // if daily, add to dailyprayers
        if (prayer.IsDaily)
        {
            DailyPrayers.Add(prayer);
            return;
        }

        //unanswered non-daily prayer
        nonDailyPrayersQueue.Enqueue(prayer);
    }

    // TODO
    public void AnswerPrayer(int id)
    {
        //option A
        // foreach(var prayer in AnsweredPrayers)
        // {
        //     if(prayer.ID == id)
        //     {
        //         prayer.IsAnswered = true;
        //         return;
        //     }
        // }

        var dailyPrayer = DailyPrayers.Find( p => p.ID == id );
        if (dailyPrayer is not null)
        {
            dailyPrayer.IsAnswered = true; 
            DailyPrayers.Remove(dailyPrayer);
            AnsweredPrayers.Add(dailyPrayer);

            return;
        }
        
        int count = nonDailyPrayersQueue.Count;
        for(int i = 0; i < count; i++)
        {
            var nonDailyPrayer = nonDailyPrayersQueue.Dequeue();
            if(nonDailyPrayer.ID == id)
            {
                nonDailyPrayer.IsAnswered = true;
                AnsweredPrayers.Add(nonDailyPrayer);
            }
            else
            {
                nonDailyPrayersQueue.Enqueue(nonDailyPrayer);
            }
        }    
    }

    // TODO
    public List<Prayer> GetPrayers(int numPrayers)
    {   
        //get all daily prayers
        List<Prayer> prayers = new List<Prayer>(DailyPrayers);

        foreach(var p in prayers)
        {
            p.LastPrayed = DateTime.Now;
        }
        
        int spotsRemaining = numPrayers - DailyPrayers.Count;
        //spotsRemaining = Math.Min(spotsRemaining, nonDailyPrayersQueue.Count);

        //if we have spots remaining, get "front" non-daily prayers from queue
        while( spotsRemaining > 0)
        {
            var nonDailyPrayer = nonDailyPrayersQueue.Dequeue();
            nonDailyPrayer.LastPrayed = DateTime.Now;
            prayers.Add(nonDailyPrayer);

            spotsRemaining--;

            nonDailyPrayersQueue.Enqueue(nonDailyPrayer);

        }
        return prayers;
    }
}


