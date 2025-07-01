using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class UI_StatBar : MonoBehaviour
{

    private Slider slider;
    private RectTransform rectTransform;

    [Header("Bar Options")]
    [SerializeField] protected bool scaleBarLengthWithStats = true;
    [SerializeField] protected float widthScaleMultiplier = 1;
    // SECONDARY BAR BEHIND MAIN BAR FOR POLISH EFFECT INDICATING HOW MUCH ACTION DEPLETED BAR

    protected virtual void Awake()
    {
        slider = GetComponent<Slider>();
        rectTransform = GetComponent<RectTransform>();
    }

    public virtual void SetStat(int newValue)
    {
        slider.value = newValue;
    }

    public virtual void SetMaxStat(int maxValue)
    {
        slider.maxValue = maxValue;
        slider.value = maxValue;

        if (scaleBarLengthWithStats)
        {
            rectTransform.sizeDelta = new Vector2(maxValue * widthScaleMultiplier, rectTransform.sizeDelta.y);
            // RESETS THE POSITION OF THE BARS BASED ON THEIR LAYOUT GROUP SETTINGS
            PlayerUIManager.instance.playerUIHudManager.RefreshHUD();
        }
    }


}
