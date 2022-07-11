using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{ 
    [SerializeField] private int _maxHealth = 10;
    [SerializeField] private int _currentHealth; // ������� ��� [SerializeField] ��� ����, ����� ��������� ��������� �����.    

    public event UnityAction<int, int> HealthChanged;
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
        // Mathf.Clamp ��� ����, ���� �� �������� �� ����� min � max ��������. �� ����������� ����� �������� ����.
        int tempCurrentHealth = Mathf.Clamp(_currentHealth + value, _minHealth, _maxHealth);

        if (tempCurrentHealth != _currentHealth)
        {
            _currentHealth = tempCurrentHealth;
            HealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
    }
}
