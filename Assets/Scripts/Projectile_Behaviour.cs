using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile_Behaviour : MonoBehaviour
{
    [SerializeField] protected GameObject kitty;
    [SerializeField] protected string wall;
    protected float attackDamage;

    protected abstract void checkCollision(Collider2D other);
}
