using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    protected float speed;
    protected int health;

    [SerializeField]
    protected Weapon weapon;

    protected virtual void Awake()
    {
        speed = 5f;
        health = 100;
    }

    // Start is called before the first frame update
    void Start()
    {
        weapon = gameObject.AddComponent<Weapon>();
    }

    protected abstract void Attack(int amount);

    public abstract void TakeDamage(int amount);

    // Update is called once per frame
    void Update()
    {
        
    }
}
