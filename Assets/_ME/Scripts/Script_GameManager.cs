using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Script_GameManager : MonoBehaviour
{
    public static Script_GameManager instance;

    [SerializeField] float cam_moveSpeed;    
    [SerializeField] int player_victimQuant;
    [SerializeField] int player_money;

    [Header("Elementos do canvas")]
    [SerializeField] TextMeshProUGUI txt_fps;
    [SerializeField] Button btn_punch;
    [SerializeField] Button btn_throw;

    Transform t_cam;
    Transform t_player;

    void Start()
    {
        instance = this;

        t_cam = Camera.main.transform.parent;
        t_player = GameObject.FindGameObjectWithTag("Player").transform;

        Area_Punch_Set(false);
        Area_Throw_Set(false);
    }

    void Update()
    {
        txt_fps.text = (1f / Time.deltaTime).ToString();

        t_cam.position = Vector3.Lerp(t_cam.position, t_player.position, cam_moveSpeed * Time.deltaTime);
    }

    public void Area_Punch_Set(bool _value)
    {
        btn_punch.interactable = _value;
    }

    public void Area_Throw_Set(bool _value)
    {
        if (_value && player_victimQuant == 0) return;
        btn_throw.interactable = _value;
    }

    public void Txt_Money_Set()
    {
        txt_fps.text = player_money.ToString();
    }
}