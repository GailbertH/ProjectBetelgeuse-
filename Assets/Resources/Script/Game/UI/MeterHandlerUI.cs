using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterHandlerUI : MonoBehaviour
{
    [SerializeField] private Transform fillMeter;
    [SerializeField] private Transform fillMeterAlternate;
    int targetAmount = 0;
    int meterCounter = 0;
    bool switchMeter = false;
    Transform currentMeter;
    const int MAX_VALUE = 100;
    public void Start()
    {
        bool isActive = true;
        fillMeter.gameObject.SetActive(isActive);
        fillMeterAlternate.gameObject.SetActive(!isActive);
        SetActiveMeter();
    }

    public void UpdateMeter(int amount)
    {
        targetAmount += amount;
    }

    public void ControlledUpdate()
    {
        if (switchMeter)
        {
            switchMeter = false;
            SwitchActiveMeter();
            SetActiveMeter();
        }
        Vector3 scale = Vector3.one;
        scale.x = (float)targetAmount / (float)MAX_VALUE;
        scale.x = scale.x > 1 ? 1 : scale.x;
        currentMeter.localScale = Vector3.Lerp(currentMeter.localScale, scale, Time.deltaTime);
        if (scale.x >= 1)
        {
            meterCounter++;
            targetAmount -= MAX_VALUE;
            switchMeter = true;
        }
    }

    private void SetActiveMeter()
    {
        currentMeter = fillMeter.gameObject.activeSelf ? fillMeter : fillMeterAlternate;
    }

    private void SwitchActiveMeter()
    {
        bool isFillmeterCurrent = fillMeter == currentMeter;
        fillMeter.gameObject.SetActive(!isFillmeterCurrent);
        fillMeterAlternate.gameObject.SetActive(isFillmeterCurrent);
        if (fillMeter.gameObject.activeSelf)
        {
            fillMeter.localScale = new Vector3(0, 1, 1);
        }
        else
        {
            fillMeterAlternate.localScale = new Vector3(0, 1, 1);
        }
    }
}
