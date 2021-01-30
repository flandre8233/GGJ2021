using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameAnimation : MonoBehaviour
{

    [SerializeField]
    Animator animator;
    public void SetAnimation()
    {
        animator.SetTrigger("Reserver");
    }
}
