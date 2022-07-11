using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth; // оставил его [SerializeField] для того, чтобы наблюдать изменение жизни.
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _healingButton;
    [SerializeField] private int _damage;
    [SerializeField] private int _healing;

    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void OnEnable()
    {
        _damageButton.onClick.AddListener(OnDamageButtonClick);
        _healingButton.onClick.AddListener(OnHealtingButtonClick);
    }

    private void OnDisable()
    {
        _damageButton.onClick.RemoveListener(OnDamageButtonClick);
        _healingButton.onClick.RemoveListener(OnHealtingButtonClick);
    }

    private void ApplyDamage(int damage)
    {
        if (_currentHealth != 0)
        {
            _currentHealth -= damage;
            HealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
    }

    private void ApplyHealing(int healting)
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth += healting;
            HealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
    }

    private void OnDamageButtonClick()
    {
        ApplyDamage(_damage);
    }

    private void OnHealtingButtonClick()
    {
        ApplyHealing(_healing);
    }
}
