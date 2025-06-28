using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class UI_StatBar : MonoBehaviour
{

    private Slider slider;
    // VARIABLE TO SCALE BAR SIZE DEPENDING ON STAT
    // SECONDARY BAR BEHIND MAIN BAR FOR POLISH EFFECT INDICATING HOW MUCH ACTION DEPLETED BAR

    protected virtual void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public virtual void SetStat(int newValue)
    {
        slider.value = newValue;
    }

    public virtual void SetMaxStat(int maxValue)
    {
        slider.maxValue = maxValue;
        slider.value = maxValue;
    }


}
