using UnityEngine;

public class Script_Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody[] rb_ragdool;
    [SerializeField] Collider[] col_ragdoll;

    [SerializeField] Animator animator;

    void Start()
    {
        Ragdoll_Set(false);
    }

    [SinforosoButton]
    void TakePunch()
    {
        animator.enabled = false;
        Ragdoll_Set(true);

        rb_ragdool[0].AddForce(Vector3.zero, ForceMode.Impulse);
    }

    public void TakePunch(float _punchForce)
    {
        animator.enabled = false;
        Ragdoll_Set(true);

        rb_ragdool[0].AddForce(Vector3.forward * _punchForce, ForceMode.Impulse);
    }

    void Ragdoll_Set(bool _value)
    {
        for (int i = 0; i < rb_ragdool.Length; i++)
        {
            rb_ragdool[i].useGravity = _value;
            col_ragdoll[i].enabled = _value;
        }
    }
}