using System.Collections.Generic;

public class NpcUnlockChecker
{
    List<int> unlockedNpcNumbers = new List<int>();
    public NpcUnlockChecker()
    {
    }

    public int getUnlockedCount()
    {
        return unlockedNpcNumbers.Count;
    }

    public void unlockNpc(int npcNum)
    {
        if(unlockedNpcNumbers.Contains(npcNum))
        {
            return;
        }

        unlockedNpcNumbers.Add(npcNum);
    }
}