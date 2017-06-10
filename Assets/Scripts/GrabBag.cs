using UnityEngine;
using System.Collections.Generic;

public class GrabBag {

    int memberCount;
    List<int> members;

    public GrabBag(int count)
    {
        memberCount = count;
        members = new List<int>();
        PopulateBag();
    }

    void PopulateBag()
    {
        for (int i = 0; i < memberCount; i++)
        {
            members.Add(i);
        }
    }

    public int Grab()
    {
        int i = Random.Range(0, members.Count);
        int result = members[i];
        members.RemoveAt(i);

        if (members.Count == 0)
        {
            PopulateBag();
        }

        return result;
    }
}
