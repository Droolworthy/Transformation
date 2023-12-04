using UnityEngine;

[RequireComponent (typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private float _lastAssaultTime;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(_lastAssaultTime <= 0)
        {
            Assault(Target);

            _lastAssaultTime = _delay;
        }

        _lastAssaultTime -= Time.deltaTime;  
    }

    private void Assault(Player target)
    {
        _animator.Play("Assault");

        target.ApplyDamage(_damage);
    }
}
