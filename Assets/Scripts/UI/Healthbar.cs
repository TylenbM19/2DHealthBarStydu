using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;

    private Coroutine _coroutine;
    private float _changeValue = 1f;
    private float _speedChangeSlider = 0.5f;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _changeValue;
    }

    private void FixedUpdate()
    {
        SetSetting();
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }

    private void OnValueChanged(int value, int maxValue)
    {
        _changeValue = (float)value / maxValue;
    }

    private void SetSetting()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CoroutineSlider(_changeValue));
    }

    private IEnumerator CoroutineSlider(float changeValue)
    {
        if (_slider.value != changeValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, changeValue, _speedChangeSlider * Time.deltaTime);
            yield return null;
        }
    }
}
