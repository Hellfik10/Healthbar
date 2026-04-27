using UnityEngine;
using UnityEngine.UI;

public class SimpleHealthBar : HealthBar
{
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.maxValue = Health.MaxValue;
        _slider.value = Health.CurrentValue;
    }

    public override void ChangeValue(float value)
    {
        _slider.value = value;
    }
}
