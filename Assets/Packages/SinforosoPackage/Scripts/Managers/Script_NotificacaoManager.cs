using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Script_NotificacaoManager : MonoBehaviour
{
    public static Script_NotificacaoManager instance;

    [SerializeField] CanvasGroup cg_notificacao;
    [SerializeField] TextMeshProUGUI txt_notificacao;
    [SerializeField] Image img_fundo;

    List<NotificacaoDados> list_notificacaoDados = new List<NotificacaoDados>();
    NotificacaoDados notificacaoDados_atual;

    void Start()
    {
        instance = this;
    }

    void Miolo(NotificacaoDados _notificacaoDados)
    {
        Script_Util.Cg_Set(cg_notificacao, true);

        notificacaoDados_atual = _notificacaoDados;

        txt_notificacao.text = notificacaoDados_atual.texto;

        Img_Fundo_Cor_Set(notificacaoDados_atual.cor_fundo);

        Invoke(nameof(Notificacao_Hide), notificacaoDados_atual.delay);
    }

    #region info
    public void Notificacao_ShowInfo(NotificacaoDados _notificacaoDados)
    {
        if (_notificacaoDados.traduzir) _notificacaoDados.texto = Texto_Traduzir(_notificacaoDados.texto);

        if (_notificacaoDados.imediata)
        {
            CancelInvoke();

            list_notificacaoDados.Insert(0, _notificacaoDados);

            Miolo(_notificacaoDados);
        }
        else
        {
            if (list_notificacaoDados.Count == 0)
            {
                list_notificacaoDados.Add(_notificacaoDados);

                Miolo(_notificacaoDados);
            }
            else
            {
                list_notificacaoDados.Add(_notificacaoDados);
            }
        }
    }
    #endregion

    #region aviso
    public void Notificacao_ShowAviso(NotificacaoDados _notificacaoDados)
    {
        if (_notificacaoDados.traduzir) _notificacaoDados.texto = Texto_Traduzir(_notificacaoDados.texto);

        if (_notificacaoDados.imediata)
        {
            CancelInvoke();

            list_notificacaoDados.Insert(0, _notificacaoDados);

            Miolo(_notificacaoDados);
        }
        else
        {
            if (list_notificacaoDados.Count == 0)
            {
                list_notificacaoDados.Add(_notificacaoDados);

                Miolo(_notificacaoDados);
            }
            else
            {
                list_notificacaoDados.Add(_notificacaoDados);
            }
        }
    }
    #endregion

    #region erro
    public void Notificacao_ShowErro(NotificacaoDados _notificacaoDados)
    {
        if (_notificacaoDados.traduzir) _notificacaoDados.texto = Texto_Traduzir(_notificacaoDados.texto);

        if (_notificacaoDados.imediata)
        {
            CancelInvoke();

            list_notificacaoDados.Insert(0, _notificacaoDados);

            Miolo(_notificacaoDados);
        }
        else
        {
            if (list_notificacaoDados.Count == 0)
            {
                list_notificacaoDados.Add(_notificacaoDados);

                Miolo(_notificacaoDados);
            }
            else
            {
                list_notificacaoDados.Add(_notificacaoDados);
            }
        }
    }
    #endregion

    string Texto_Traduzir(string _texto)
    {
        return Script_TraducaoManager.instance.TermoTraduzido_Get(_texto);
    }

    void Img_Fundo_Cor_Set(Color _cor)
    {
        img_fundo.color = _cor;
    }

    void Notificacao_Hide()
    {
        list_notificacaoDados.Remove(notificacaoDados_atual);

        if (list_notificacaoDados.Count == 0) Script_Util.Cg_Set(cg_notificacao, false);
        else Miolo(list_notificacaoDados[0]);
    }
}