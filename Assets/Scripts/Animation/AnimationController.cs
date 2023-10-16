using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Vector3 moveSpeed = Vector3.zero;

    public void TranslateCharacterSpeed(Vector3 speed)
    {
        animator.SetFloat("Y", speed.z );
        animator.SetFloat("X", speed.x );
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
