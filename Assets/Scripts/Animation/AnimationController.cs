using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Vector3 moveSpeed = Vector3.zero;

    public void TranslateCharacterSpeed(float forward, float right)
    {
        animator.SetFloat("Y", forward );
        animator.SetFloat("X", right );
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
