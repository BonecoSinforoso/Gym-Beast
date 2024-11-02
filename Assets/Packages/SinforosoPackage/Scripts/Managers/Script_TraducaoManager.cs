using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Script_TraducaoManager : MonoBehaviour
{
    public static Script_TraducaoManager instance;

#if UNITY_EDITOR
    readonly string caminho = "Assets/_Jasao/TermosSemTraducao.txt";
#else
    readonly string caminho = Path.Combine(Application.persistentDataPath, "TermosSemTraducao.txt");
#endif

    [SerializeField] TMP_Dropdown drop_idioma;

    string[] termos_pt;
    string[] termos_en;

    int idiomaAtualIndex;
    int idiomaDesejadoIndex;

    string[] termos_atual;
    string[] termos_desejado;

    TermosSemTraducao termosSemTraducao = new TermosSemTraducao();

    private void Start()
    {
        instance = this;

        termos_pt = Termos_pt.termos;
        termos_en = Termos_en.termos;

        Idioma_Get();

        if (idiomaAtualIndex != 0) //quando nn eh ptbr... traduz
        {
            idiomaAtualIndex = 0;
            idiomaDesejadoIndex = 1;

            CenaTraduzir();
        }

        drop_idioma.value = idiomaAtualIndex;

        TermosSemTraducao_Otimizar();
    }

    void Idioma_Get()
    {
        idiomaAtualIndex = Script_DadoManager.instance.Dado_IdiomaAtualIndex;
    }

    public void IdiomaDesejado_Set()
    {
        idiomaDesejadoIndex = drop_idioma.value;

        if (idiomaDesejadoIndex != idiomaAtualIndex)
        {
            Termos_Set();
            CenaTraduzir();
        }

        Script_DadoManager.instance.Dado_IdiomaAtualIndex = idiomaDesejadoIndex;
    }

    void CenaTraduzir()
    {
        Termos_Set();

        TextMeshProUGUI[] _txts = FindObjectsOfType<TextMeshProUGUI>();

        foreach (TextMeshProUGUI _txt in _txts)
        {
            for (int i = 0; i < termos_atual.Length; i++)
            {
                if (_txt.text == termos_atual[i])
                {
                    _txt.text = termos_desejado[i];
                    break;
                }
            }
        }

        idiomaAtualIndex = idiomaDesejadoIndex;
    }

    public string TermoTraduzido_Get(string _termoParaTraduzir) //sempre vai vir termo em pt
    {
        if (idiomaAtualIndex == 0 || string.IsNullOrEmpty(_termoParaTraduzir)) return _termoParaTraduzir;

        for (int i = 0; i < termos_desejado.Length; i++)
        {
            if (_termoParaTraduzir == termos_pt[i])
            {
                return termos_en[i];
            }
        }

        TermosSemTraducao_Carregar();

        if (!termosSemTraducao.list_termosSemTraducao.Contains(_termoParaTraduzir))
        {
            termosSemTraducao.list_termosSemTraducao.Add(_termoParaTraduzir);

            TermosSemTraducao_Salvar();

            string _t1 = TermoTraduzido_Get("O termo:");
            string _t2 = TermoTraduzido_Get("não tem tradução.");

            Script_NotificacaoManager.instance.Notificacao_ShowAviso(NotificacaoDados.NotificacaoDados_CriarAviso(_t1 + " " + _termoParaTraduzir + " " + _t2, false));
        }

        return _termoParaTraduzir;
    }

    void Termos_Set()
    {
        switch (idiomaAtualIndex)
        {
            case 0:
                termos_atual = termos_pt;
                break;
            case 1:
                termos_atual = termos_en;
                break;
        }

        switch (idiomaDesejadoIndex)
        {
            case 0:
                termos_desejado = termos_pt;
                break;
            case 1:
                termos_desejado = termos_en;
                break;
        }
    }

    #region termos sem traducao
    void TermosSemTraducao_Carregar()
    {
        if (!File.Exists(caminho))
        {
            TermosSemTraducao_Salvar();
        }
        else
        {
            string _conteudo = File.ReadAllText(caminho);
            termosSemTraducao = JsonUtility.FromJson<TermosSemTraducao>(_conteudo);
        }
    }

    void TermosSemTraducao_Salvar()
    {
        string _conteudo = JsonUtility.ToJson(termosSemTraducao, true);
        File.WriteAllText(caminho, _conteudo);
    }

    void TermosSemTraducao_Otimizar()
    {
        TermosSemTraducao_Carregar();

        List<string> _list_termosRemover = new List<string>();

        foreach (string _termo in termosSemTraducao.list_termosSemTraducao)
        {
            for (int i = 0; i < termos_pt.Length; i++)
            {
                if (termos_pt[i] == _termo)
                {
                    _list_termosRemover.Add(_termo);
                    break;
                }
            }
        }

        if (_list_termosRemover.Count > 0)
        {
            foreach (string _termoRemover in _list_termosRemover)
            {
                termosSemTraducao.list_termosSemTraducao.Remove(_termoRemover);
            }
        }

        TermosSemTraducao_Salvar();
    }
    #endregion
}