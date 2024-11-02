using System.IO;
using UnityEngine;

public class Script_DadoManager : MonoBehaviour
{
    public static Script_DadoManager instance;

#if UNITY_EDITOR
    readonly string caminho = "Assets/_Jasao/Dado.txt";
#else
    readonly string caminho = Path.Combine(Application.persistentDataPath, "Dado.txt");
#endif

    Dado dado = new Dado();

    void Start()
    {
        instance = this;

        Dado_Carregar();
    }

    void Dado_Carregar()
    {
        if (!File.Exists(caminho))
        {
            Dado_Salvar();
        }
        else
        {
            string _conteudo = File.ReadAllText(caminho);
            dado = JsonUtility.FromJson<Dado>(_conteudo);
        }
    }

    void Dado_Salvar()
    {
        string _conteudo = JsonUtility.ToJson(dado, true);
        File.WriteAllText(caminho, _conteudo);
    }

    public Data Dado_DataTavernaReset
    {
        get { return dado.data_tavernaReset; }
        set
        {
            dado.data_tavernaReset = value;

            Dado_Salvar();
        }
    }

    public int Dado_GenerosoQuant
    {
        get { return dado.generosoQuant; }
        set
        {
            dado.generosoQuant = value;

            Dado_Salvar();
        }
    }

    public int Dado_IdiomaAtualIndex
    {
        get { return dado.idiomaAtualIndex; }
        set
        {
            dado.idiomaAtualIndex = value;

            Dado_Salvar();
        }
    }

    public string Dado_JogadorNome
    {
        get { return dado.jogadorNome; }
        set
        {
            dado.jogadorNome = value;

            Dado_Salvar();
        }
    }

    public bool Dado_PrimeiraLuta
    {
        get { return dado.primeiraLuta; }
        set
        {
            dado.primeiraLuta = value;

            Dado_Salvar();
        }
    }

    //player
    public int Dado_PlayerFamiliaIdAtual
    {
        get { return dado.playerFamiliaIdAtual; }
        set
        {
            dado.playerFamiliaIdAtual = value;

            Dado_Salvar();
        }
    }

    public int Dado_ItemUsado_IdUnico_Get(int _index)
    {
        switch (_index)
        {
            case 0:
                return Dado_ItemUsado_IdUnico_00;
            case 1:
                return Dado_ItemUsado_IdUnico_01;
            case 2:
                return Dado_ItemUsado_IdUnico_02;
            default:
                Script_NotificacaoManager.instance.Notificacao_ShowErro(NotificacaoDados.NotificacaoDados_CriarErro("Index do item usado não existe."));
                return -1;
        }
    }

    public void Dado_ItemUsado_IdUnico_Set(int _valor, int _index)
    {
        switch (_index)
        {
            case 0:
                Dado_ItemUsado_IdUnico_00 = _valor;
                break;
            case 1:
                Dado_ItemUsado_IdUnico_01 = _valor;
                break;
            case 2:
                Dado_ItemUsado_IdUnico_02 = _valor;
                break;
        }
    }

    int Dado_ItemUsado_IdUnico_00
    {
        get { return dado.itemUsado_idUnico_00; }
        set
        {
            dado.itemUsado_idUnico_00 = value;

            Dado_Salvar();
        }
    }

    int Dado_ItemUsado_IdUnico_01
    {
        get { return dado.itemUsado_idUnico_01; }
        set
        {
            dado.itemUsado_idUnico_01 = value;

            Dado_Salvar();
        }
    }

    int Dado_ItemUsado_IdUnico_02
    {
        get { return dado.itemUsado_idUnico_02; }
        set
        {
            dado.itemUsado_idUnico_02 = value;

            Dado_Salvar();
        }
    }
}