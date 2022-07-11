using UnityEngine;

public class DamageButton : AbstractButton
{
    [SerializeField] private Player _player;
    [SerializeField] private int _damage;

    protected override void OnClickButton()
    {
        _player.TakeDamage(_damage);
    }
}
