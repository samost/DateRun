using System;
using UnityEngine;
using UnityEngine.Serialization;

public class AnimatorManager : MonoBehaviour
{
    public static AnimatorManager Instance;

    [SerializeField] private Animator girlAnimator;
    [SerializeField] private Animator manAnimator;
    
    private void Awake()
    {
        Instance = this;
    }

    public void SetGirlAnimation(TypeAnimation typeAnim, bool state)
    {
        girlAnimator.SetBool("isWalk", state);
    }
    
    public void SetManAnimation(TypeAnimation typeAnim, bool state)
    {
        manAnimator.SetBool("isWalk", state);
    }
    
}

public enum TypeAnimation
{
    Idle,
    Walk
}
