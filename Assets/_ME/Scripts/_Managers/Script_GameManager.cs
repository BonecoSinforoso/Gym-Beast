using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Script_GameManager : MonoBehaviour
{
    #region variaveis
    public static Script_GameManager instance;

    [SerializeField] AudioClip[] ac_button;
    [SerializeField] AudioClip[] ac_money;
    [SerializeField] int fps_target;
    [SerializeField] float cam_moveSpeed;
    [SerializeField] int player_money;

    [Header("Inimigo")]
    [SerializeField] GameObject prefab_enemy;
    [SerializeField] Transform[] t_enemySpawn;
    [SerializeField] Transform parent_enemies;

    [Header("Textos")]
    [SerializeField] TextMeshProUGUI txt_fps;
    [SerializeField] TextMeshProUGUI txt_money;
    [SerializeField] TextMeshProUGUI txt_stack;
    [SerializeField] TextMeshProUGUI[] txt_upgrade;

    [Header("Botoes")]
    [SerializeField] Button btn_collect;
    [SerializeField] Button btn_punch;
    [SerializeField] Button btn_throw;

    [Header("Upgrades")]
    [SerializeField] CanvasGroup cg_upgradeShop;
    [SerializeField] Upgrade[] upgrade;

    Transform t_cam;
    Transform t_player;
    AudioSource audioSource;
    #endregion

    void Start()
    {
        instance = this;

        Application.targetFrameRate = fps_target;

        t_cam = Camera.main.transform.parent;
        t_player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();

        Area_Collect_Set(false);
        Area_Punch_Set(false);
        Area_Throw_Set(false);

        Txt_Money_Set();
        Txt_Upgrade_Set();

        for (int i = 0; i < t_enemySpawn.Length; i++) Enemy_Spawn(i);
    }

    void Update()
    {
        Txt_Fps_Set();

        t_cam.position = Vector3.Lerp(t_cam.position, t_player.position, cam_moveSpeed * Time.deltaTime);
    }

    public IEnumerator Call_Enemy_Spawn(int _index, float _delay = 10f)
    {
        yield return new WaitForSeconds(_delay);

        Enemy_Spawn(_index);
    }

    void Enemy_Spawn(int _index)
    {
        GameObject _go_enemy = Instantiate(prefab_enemy, t_enemySpawn[_index].position, Quaternion.Euler(0, 180, 0));
        _go_enemy.transform.parent = parent_enemies;
        _go_enemy.GetComponent<Script_Enemy>().Index = _index;
    }

    public void Player_Money_Set(int _value)
    {
        player_money += _value;
        Txt_Money_Set();
    }

    public void Cg_UpgradeShop_Toggle()
    {
        cg_upgradeShop.alpha = cg_upgradeShop.alpha == 0 ? 1 : 0;
        cg_upgradeShop.blocksRaycasts = cg_upgradeShop.alpha == 1;
        cg_upgradeShop.interactable = cg_upgradeShop.alpha == 1;

        Upgrade_Check();
    }

    #region audios
    public void Ac_Button_Play()
    {
        Script_Util.AudioSource_Play(audioSource, ac_button);
    }

    public void Ac_Money_Play()
    {
        Script_Util.AudioSource_Play(audioSource, ac_money);
    }
    #endregion

    #region textos
    void Txt_Fps_Set()
    {
        txt_fps.text = (1f / Time.deltaTime).ToString();
    }

    void Txt_Money_Set()
    {
        txt_money.text = "$" + player_money.ToString();
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

        Upgrade_Check();
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
        Player_Money_Set(-upgrade[_index].price);
        Ac_Money_Play();

        switch (_index)
        {
            case 0: //mudar cor
                t_player.GetComponent<Script_Player>().ColorChange_Upgrade();
                break;
            case 1: //aumentar capacidade
                t_player.GetComponent<Script_StackController>().Quant_Max_Upgrade();
                break;
            case 2: //aumentar move speed
                t_player.GetComponent<Script_Player>().MoveSpeed_Upgrade();
                break;
            default:
                Debug.Log("upgrade nn encontrado");
                break;
        }

        Upgrade_Check();
    }

    void Upgrade_Check() //verifica se tem o dinheiro suficiente para poder clicar no botao
    {
        for (int i = 0; i < upgrade.Length; i++)
        {
            txt_upgrade[i].GetComponentInParent<Button>().interactable = player_money >= upgrade[i].price;
        }
    }
    #endregion
}