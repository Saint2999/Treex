using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGKitty_Behaviour : Projectile_Behaviour
{
    void Start()
    {
        attackDamage = kitty.GetComponent<GingerKitty_Behaviour>().getAttackdamage();
    }
}

