using UnityEngine;
using UnityEngine.UI;

public abstract class UIBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    protected void FillSlider(float value, float maxValue)
    {
        _slider.value = value/maxValue;
    }
}
