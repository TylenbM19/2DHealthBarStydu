using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealButton : AbstractButton
{
    [SerializeField] private Player _player;
    [SerializeField] private int _heals;

    protected override void OnClickButton()
    {
        _player.Heal(_heals);
    }
}
