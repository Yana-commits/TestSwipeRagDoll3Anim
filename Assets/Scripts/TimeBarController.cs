using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI timeTxt;

    public void SetMaxTime(float time)
    {
        slider.maxValue = time;
        slider.value = time;
    }

    public void SetTime(float time)
    {
        int showTime = (int)time;
        timeTxt.text = showTime.ToString();
        slider.value = time;
    }
}
