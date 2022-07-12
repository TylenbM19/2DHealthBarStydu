using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{ 
    [SerializeField] private int _maxHealth = 10;
    [SerializeField] private int _currentHealth;
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _healingButton;
    [SerializeField] private int _damage;
    [SerializeField] private int _healing;

    public event UnityAction<int, int> OnHealthChanged;
    private int _minHealth = 0;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        ChangeHealth(-damage);
    }

    public void Heal(int health)
    {
        ChangeHealth(health);
    }

    private void ChangeHealth(int value)
    {
        int tempCurrentHealth = Mathf.Clamp(_currentHealth + value, _minHealth, _maxHealth);

        if (tempCurrentHealth != _currentHealth)
        {
            _currentHealth = tempCurrentHealth;
            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
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

    private void OnDamageButtonClick()
    {
        ChangeHealth(-_damage);
    }

    private void OnHealtingButtonClick()
    {
        ChangeHealth(_healing);
    }
}
