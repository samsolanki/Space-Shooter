using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationContrallor : MonoBehaviour
{

    [SerializeField] Animator _anim;

    private Animator shootAnimation;

    private void Awake()
    {
        shootAnimation = GameObject.Find("Shooting Point").GetComponent<Animator>();
    }

    public void Move(float move)
    {
        _anim.SetFloat("Move", move);
    }

    public void Shoot()
    {
        shootAnimation.SetTrigger("Shoot");
    }

    public void Hit()
    {
        _anim.SetTrigger("Hit");
    }
    public void DeadAnim()
    {
        _anim.Play("dead");
    }
}
