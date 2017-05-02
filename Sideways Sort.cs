using System;
using System.Threading;

public class SidewaysSort
{
    
    void SidewaysSort(int[] nums)
    {
        List<int> sortedList = new List<int>();
        Thread[] threads = new Thread[nums.Length];
        int loops = 0;

        for (int i = 0; i < threads.Length; i++)
            threads[i] = new Thread(Spin);

        while (!Sorted(nums, out int idx))
        {
            for (int i = 0; i < threads.Length; i++)                           
                threads[i].Start(nums[i]);
            
            foreach (Thread t in threads)
                t.Join();

            for (int i = 0; i < nums.Length; i++)
                nums[i] = sortedList[i];

            sortedList.Clear();
            loops++;
        }
    }

    //pass in the amount of time to sleep for, so when the thread wakes up
    //we'll magically insert into the sorted list in order...ish
    private void Spin(object timeToSleep)
    {
        int time = (int)timeToSleep;
        Thread.Sleep(time * 10);
        lock (nums)
        {
            sortedList.Add(time);
        }
    }

    private bool Sorted(int[] list, out int firstIdx)
    {
        for (int i = 0; i < list.Length - 1; i++)
        {
            if (list[i] > list[i + 1])
            {
                firstIdx = i;
                return false;
            }
        }
        firstIdx = -1;
        return true;
    }
}

