using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskHandler : MonoBehaviour
{
    [SerializeField] private List<DeskButton> desks;
    public int StudentStudyActivity()
    {
        int learnings = 0;
        foreach (DeskButton desk in desks)
        {
            desk.CountDown();
            learnings += desk.CheckStudyProgress();
        }
        return learnings;
    }
}
