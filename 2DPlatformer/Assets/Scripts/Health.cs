using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;}
    private BoxCollider2D boxCollider;
    Vector3 startpos;
    private void Awake()
    {
        currentHealth = startingHealth;
    }

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        startpos = transform.position;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if (currentHealth <= 0)
        {
            transform.position = startpos;
            currentHealth = startingHealth;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Player hit by enemy");
            TakeDamage(1);
        }
    }
}
