using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : HealthBar
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _delay = 1f;

    private Coroutine _coroutine;
    private float _currentNormalizedValue = 0f;

    private void Start()
    {
        _currentNormalizedValue = CalculateNormalizedValue(Health.CurrentValue);
        _slider.value = _currentNormalizedValue;
    }

    public override void ChangeValue(float value)
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(SmoothChangeValue(CalculateNormalizedValue(value)));
    }

    private IEnumerator SmoothChangeValue(float targetValue)
    {
        while(Mathf.Approximately(targetValue, _slider.value) == false)
        {
            yield return null;

            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _delay * Time.deltaTime);
        }
    }

    private float CalculateNormalizedValue(float absoluteValue)
    {
        return Health.MaxValue > 0 ? absoluteValue / Health.MaxValue : 0f;
    }
}
