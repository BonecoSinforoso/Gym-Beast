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
    [SerializeField] TextMeshProUGUI txt_money;
    [SerializeField] TextMeshProUGUI txt_stack;
    [SerializeField] TextMeshProUGUI[] txt_upgrade;
    [SerializeField] Button btn_collect;
    [SerializeField] Button btn_punch;
    [SerializeField] Button btn_throw;

    Transform t_cam;
    Transform t_player;

    [SerializeField] Upgrade[] upgrade;

    void Start()
    {
        instance = this;

        Application.targetFrameRate = fps_target;

        t_cam = Camera.main.transform.parent;
        t_player = GameObject.FindGameObjectWithTag("Player").transform;

        Area_Collect_Set(false);
        Area_Punch_Set(false);
        Area_Throw_Set(false);

        Txt_Upgrade_Set();
    }

    void Update()
    {
        Txt_Fps_Set();

        t_cam.position = Vector3.Lerp(t_cam.position, t_player.position, cam_moveSpeed * Time.deltaTime);
    }

    public void Player_Money_Set(int _value)
    {
        player_money += _value;
        Txt_Money_Set();
    }

    #region textos
    void Txt_Fps_Set()
    {
        txt_fps.text = (1f / Time.deltaTime).ToString();
    }

    void Txt_Money_Set()
    {
        txt_money.text = player_money.ToString();
    }

    public void Txt_Stack_Set(int _current, int _max)
    {
        txt_stack.text = _current.ToString() + "/" + _max.ToString();
    }

    void Txt_Upgrade_Set()
    {
        for (int i = 0; i < upgrade.Length; i++)
        {
            txt_upgrade[i].text = upgrade[i].title + "\n$" + upgrade[i].price;
        }
    }
    #endregion

    #region controle da interatividade dos botoes
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

    #region upgrade
    public void Upgrade_Buy(int _index)
    {
        if (player_money < upgrade[_index].price)
        {
            Debug.Log("dinheiro insuficiente");
            return;
        }

        player_money -= upgrade[_index].price;

        switch (_index)
        {
            case 0: //mudar cor
                break;
            case 1: //aumentar capacidade
                t_player.GetComponent<Script_StackController>().Quant_Max_Increment();
                break;
            case 2: //aumentar move speed
                t_player.GetComponent<Script_Player>().MoveSpeed_Upgrade();
                break;
            default:
                Debug.Log("upgrade nn encontrado");
                break;
        }
    }
    #endregion
}