using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Healthbar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Slider _slider;
    private Coroutine _coroutine;
    private float _speedChangeSlider = 1f;
    private float _changeValue = 1f;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.value = _changeValue;
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
        StartSliderCoroutine();
    }

    private void StartSliderCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CoroutineSlider());
    }

    private IEnumerator CoroutineSlider()
    {
        var fixedUpdateAwaiter = new WaitForFixedUpdate();

        while (_slider.value != _changeValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _changeValue, _speedChangeSlider * Time.deltaTime);
            yield return fixedUpdateAwaiter;
        }
    }
}
