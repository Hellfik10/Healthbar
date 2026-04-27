using UnityEngine;
using UnityEngine.UI;

public class SimpleHealthBar : HealthBar
{
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.maxValue = Health.MaxValue;
        ChangeValue(Health.CurrentValue);
    }

    public override void ChangeValue(float value)
    {
        _slider.value = CalculateNormalizedValue(value);
    }

    private float CalculateNormalizedValue(float absoluteValue)
    {
        if (Health.MaxValue <= 0)
            return 0f;

        float clampedValue = Mathf.Clamp(absoluteValue, 0, Health.MaxValue);
        return clampedValue / Health.MaxValue;
    }
}
