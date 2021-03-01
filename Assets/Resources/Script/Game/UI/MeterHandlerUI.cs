using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterHandlerUI : MonoBehaviour
{
    [SerializeField] private Transform fillMeter;
    int targetAmount = 0;
    float divider = 100f;
    public void UpdateMeter(int amount)
    {
        targetAmount = amount;
    }

    public void ControlledUpdate()
    {
        Vector3 scale = Vector3.one;
        scale.x = (float)targetAmount / divider;
        if (scale.x >= 1)
        {
            Vector3 scaleReset = Vector3.one;
            scaleReset.x = 0;
            fillMeter.localScale = Vector3.Lerp(fillMeter.localScale, scaleReset, Time.deltaTime);
            divider += 100;
        }
        fillMeter.localScale = Vector3.Lerp(fillMeter.localScale, scale, Time.deltaTime);
    }
}
