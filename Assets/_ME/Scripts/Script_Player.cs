using UnityEngine;
using System.Collections;

public class Script_Player : MonoBehaviour
{
    #region variaveis
    [SerializeField] RectTransform rect_joy_front;
    [SerializeField] RectTransform rect_joy_back;

    [SerializeField] float moveSpeed;
    [SerializeField] float punchForce;

    [SerializeField] SkinnedMeshRenderer skmesh_player;
    [SerializeField] Transform t_move;
    [SerializeField] AudioClip[] ac_footstep;
    
    Animator animator;
    AudioSource audioSource;
    Rigidbody rb;

    Script_Enemy script_Enemy;
    Script_StackController script_StackController;
    #endregion

    void Start()
    {
        animator = transform.GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        script_StackController = GetComponent<Script_StackController>();
    }

    void Update()
    {
        bool _joyMoved = Vector2.Distance(rect_joy_back.position, rect_joy_front.position) > 0.1f;

        animator.SetBool("_run", _joyMoved);

        if (_joyMoved)
        {
            animator.speed = 1 + ((moveSpeed - 5) / 5);

            t_move.eulerAngles = new Vector3(0, -Script_Util.Direction2D_Get(rect_joy_back.position, rect_joy_front.position) + 90, 0);

            rb.velocity = t_move.forward * moveSpeed;
        }
        else
        {
            animator.speed = 1;
            rb.velocity = Vector3.zero;
        }
    }

    [SinforosoButton]
    public void MoveSpeed_Upgrade()
    {
        moveSpeed += 5;
    }

    [SinforosoButton]
    public void ColorChange_Upgrade()
    {
        Color _color = new(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        skmesh_player.material.color = _color;
    }

    #region acoes chamadas pelos botoes
    public void Action_Collect()
    {
        if (script_StackController.Stack_Create())
        {
            Script_GameManager.instance.Area_Collect_Set(false);
            StartCoroutine(Script_GameManager.instance.Call_Enemy_Spawn(script_Enemy.Index));
            Destroy(script_Enemy.gameObject);
        }        
    }

    public void Action_Punch()
    {
        animator.SetTrigger("_punch");

        script_Enemy.TakePunch(punchForce, script_Enemy.transform.position - transform.position);

        Script_GameManager.instance.Area_Punch_Set(false);
    }

    public void Action_Throw()
    {
        script_StackController.Call_ThrowRoutine();
    }
    #endregion

    #region Colisao
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);

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

    public void Ac_Footstep_Play()
    {
        Script_Util.AudioSource_Play(audioSource, ac_footstep);
    }
}