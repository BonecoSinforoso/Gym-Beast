using System.Collections;
using UnityEngine;

public class Script_ErroManager : MonoBehaviour
{
    public static Script_ErroManager instance;

    [SerializeField] bool debugAtivado;

    void Start()
    {
        instance = this;
    }

    void OnEnable()
    {
        Application.logMessageReceived += Call_Erro_Detectado;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= Call_Erro_Detectado;
    }

    void Call_Erro_Detectado(string _conteudo, string _stackTrace, LogType _tipo)
    {
        StartCoroutine(Erro_Detectado(_conteudo, _stackTrace, _tipo));
    }

    IEnumerator Erro_Detectado(string _conteudo, string _stackTrace, LogType _tipo)
    {
        yield return new WaitUntil(() => Script_TraducaoManager.instance != null);

        if (_tipo == LogType.Exception)
        {
            if (debugAtivado)
            {
                Debug.Log(_conteudo);
                Debug.Log(_stackTrace);
            }

            string _erro = Script_TraducaoManager.instance.TermoTraduzido_Get("Erro detectado:") + " " + _conteudo;
            string _stack = "Stack Trace: " + _stackTrace;

            //sua logica aqui
            if (_stackTrace.Contains("UnityEditor"))
            {
                Debug.Log("Ignorado: " + _erro + "\n\n" + _stackTrace);
            }
            else
            {
                Script_NotificacaoManager.instance.Notificacao_ShowErro(NotificacaoDados.NotificacaoDados_CriarErro(_erro + "\n\n" + _stack, false, 5f));
            }
        }
    }
}