using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StudentState
{
    IDLE = 0,
    LEARNING = 1,
    DISTRACTED = 2,
    BULLYING = 3,
    BULLIED = 4
}


public class DeskButton : TouchResponse
{
    public SpriteRenderer sp;

    [SerializeField] private int counter;
    [SerializeField] DeskButton northSeatMate; //back
    [SerializeField] DeskButton southSeatMate; //front
    [SerializeField] DeskButton eastSeatMate; //right
    [SerializeField] DeskButton westSeatMate; //left

    private void Start()
    {
        counter = Random.Range(5, 11);
    }

    public void CountDown()
    {
        if (counter > 0)
        {
            counter--;
            if (counter == 0)
            {
                Color red = Color.red;
                red.a = 0.4f;
                sp.color = red;
            }
        }
    }

    public int CheckStudyProgress()
    {
        int studyScore = 1;
        if (counter > 0)
        {
            Color green = Color.green;
            green.a = 0.4f;
            sp.color = green;
            Invoke("ResetColor", 0.5f);
            return studyScore;
        }
        return 0;
    }

    public override void OnTouchDown(Touch touch)
    {
        Debug.Log("Hello");
        if (sp.color != Color.white)
        {
            ResetColor();
            counter = Random.Range(5, 11);
        }
    }

    private void ResetColor()
    {
        Color white = Color.white;
        white.a = 0.2f;
        sp.color = white;
    }
}
