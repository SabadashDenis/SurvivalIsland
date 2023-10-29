using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Vector3 moveSpeed = Vector3.zero;

    public void TranslateCharacterSpeed(float forward, float right)
    {
        animator.SetFloat("Y", forward);
        animator.SetFloat("X", right);
    }

    public void Jump()
    {
        animator.Play("Jump");
    }

    public void Attack()
    {
        animator.Play("Melee Attack");
    }
}