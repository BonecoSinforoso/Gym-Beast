using UnityEngine;

public class Script_Player : MonoBehaviour
{
    [SerializeField] RectTransform rect_joy_front;
    [SerializeField] RectTransform rect_joy_back;

    [SerializeField] float moveSpeed;
    [SerializeField] float punchForce;

    [SerializeField] Transform t_move;
    Animator animator;
    Rigidbody rb;

    Script_Enemy script_Enemy;
    Script_StackController script_StackController;

    void Start()
    {
        animator = transform.GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        script_StackController = GetComponent<Script_StackController>();
    }

    void Update()
    {
        bool _joyMoved = Vector2.Distance(rect_joy_back.position, rect_joy_front.position) > 0.1f;

        animator.SetBool("_run", _joyMoved);

        if (_joyMoved)
        {
            t_move.eulerAngles = new Vector3(0, -Script_Util.Direction2D_Get(rect_joy_back.position, rect_joy_front.position) + 90, 0);

            rb.velocity = t_move.forward * moveSpeed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    public void Action_Collect()
    {
        script_StackController.Stack_Create();

        Destroy(script_Enemy.gameObject);

        Script_GameManager.instance.Area_Collect_Set(false);
    }

    public void Action_Punch()
    {
        script_Enemy.TakePunch(punchForce, script_Enemy.transform.position - transform.position);

        Script_GameManager.instance.Area_Punch_Set(false);
    }

    public void Action_Throw()
    {

    }

    #region Colisao
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (other.CompareTag("Area_Collect"))
        {
            Script_GameManager.instance.Area_Collect_Set(true);

            script_Enemy = other.GetComponentInParent<Script_Enemy>();
        }
        if (other.CompareTag("Area_Punch"))
        {
            Script_GameManager.instance.Area_Punch_Set(true);

            script_Enemy = other.GetComponentInParent<Script_Enemy>();
        }
        if (other.CompareTag("Area_Throw"))
        {
            Script_GameManager.instance.Area_Throw_Set(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Area_Collect"))
        {
            Script_GameManager.instance.Area_Collect_Set(false);
        }
        if (other.CompareTag("Area_Punch"))
        {
            Script_GameManager.instance.Area_Punch_Set(false);
        }
        if (other.CompareTag("Area_Throw"))
        {
            Script_GameManager.instance.Area_Throw_Set(false);
        }
    }
    #endregion
}