using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Script_GameManager : MonoBehaviour
{
    public static Script_GameManager instance;

    [SerializeField] int fps_target;
    [SerializeField] float cam_moveSpeed;
    [SerializeField] int player_money;

    [Header("Elementos do canvas")]
    [SerializeField] TextMeshProUGUI txt_fps;
    [SerializeField] TextMeshProUGUI txt_stack;
    [SerializeField] Button btn_collect;
    [SerializeField] Button btn_punch;
    [SerializeField] Button btn_throw;

    Transform t_cam;
    Transform t_player;

    void Start()
    {
        instance = this;

        Application.targetFrameRate = fps_target;

        t_cam = Camera.main.transform.parent;
        t_player = GameObject.FindGameObjectWithTag("Player").transform;

        Area_Collect_Set(false);
        Area_Punch_Set(false);
        Area_Throw_Set(false);
    }

    void Update()
    {
        Txt_Fps_Set();

        t_cam.position = Vector3.Lerp(t_cam.position, t_player.position, cam_moveSpeed * Time.deltaTime);
    }

    #region textos
    void Txt_Fps_Set()
    {
        txt_fps.text = (1f / Time.deltaTime).ToString();
    }

    public void Txt_Money_Set()
    {
        txt_fps.text = player_money.ToString();
    }

    public void Txt_Stack_Set(int _current, int _max)
    {
        txt_stack.text = _current.ToString() + "/" + _max.ToString();
    }
    #endregion

    #region botoes
    public void Area_Collect_Set(bool _value)
    {
        btn_collect.interactable = _value;
    }

    public void Area_Punch_Set(bool _value)
    {
        btn_punch.interactable = _value;
    }

    public void Area_Throw_Set(bool _value)
    {
        btn_throw.interactable = _value;
    }
    #endregion
}