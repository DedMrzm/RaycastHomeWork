using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable1
{
    private const string TakeDamageTriggerKey = "TakeDamage";
    private const string IsDeadKey = "IsDead";

    [SerializeField] private Animator _animator;
    [SerializeField] private Collider _bodyCollider;

    [SerializeField] private int _maxHealth;
    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
       if(damage < 0)
        {
            Debug.LogError(damage);
            return;
        }

       _currentHealth -= damage;

        if(_currentHealth < 0)
        {
            _currentHealth = 0;
            _bodyCollider.enabled = false;
            _animator.SetBool(IsDeadKey, true);
            return;
        }

        _animator.SetTrigger(TakeDamageTriggerKey);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
