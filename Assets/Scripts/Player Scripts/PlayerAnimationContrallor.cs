using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationContrallor : MonoBehaviour
{

    [SerializeField] Animator _anim;

    public void Move(bool move)
    {
        _anim.SetBool("Moving", move);
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
