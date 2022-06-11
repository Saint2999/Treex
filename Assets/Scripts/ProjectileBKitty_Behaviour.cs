using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBKitty_Behaviour : Projectile_Behaviour
{
    void Start()
    {
        attackDamage = kitty.GetComponent<BlackKitty_Behaviour>().getAttackdamage();
    }
}