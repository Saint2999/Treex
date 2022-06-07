using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit_Behaviour : MonoBehaviour
{
    [SerializeField] protected float currentHealth;
    [SerializeField] protected float maxHealth;
    public float speed;
    protected Animator anim;
    protected Rigidbody2D rb;
    protected Vector2 movement;
    protected Vector3 dir;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void updateHealth(float mod) 
    {
        currentHealth += mod;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        } 
        else if (currentHealth <= 0f)
            {
                currentHealth = 0f;
                Destroy(this.gameObject);
            }
    }
}
