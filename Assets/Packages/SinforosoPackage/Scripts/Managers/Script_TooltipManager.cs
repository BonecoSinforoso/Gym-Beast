using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Script_TooltipManager : MonoBehaviour
{
    public static Script_TooltipManager instance;

    [SerializeField] CanvasGroup cg_tooltip;
    [SerializeField] TextMeshProUGUI txt_titulo;
    [SerializeField] TextMeshProUGUI txt_info;
    [SerializeField] Image img_qualidade;

    string titulo;
    string info;
    float qualidade;

    void Start()
    {
        instance = this;
    }

    public void Show(TooltipDados _tooltipDados, float _delay = 2f)
    {
        CancelInvoke();

        cg_tooltip.alpha = 1;

        if (_tooltipDados.traduzir) //separar traducao do titulo pra info
        {
            _tooltipDados.titulo = Script_TraducaoManager.instance.TermoTraduzido_Get(_tooltipDados.titulo);
            _tooltipDados.info = Script_TraducaoManager.instance.TermoTraduzido_Get(_tooltipDados.info);
        }

        txt_titulo.text = _tooltipDados.titulo;
        txt_info.text = _tooltipDados.info;

        img_qualidade.GetComponent<RectTransform>().sizeDelta = new Vector2(240, 48);

        Componentes_Set(_tooltipDados.qualidade);

        if (_delay != -1f) Invoke(nameof(Hide), _delay);
    }

    void Componentes_Set(float _qualidade)
    {
        if (_qualidade == -1)
        {
            img_qualidade.enabled = false;
            txt_info.enabled = true;
        }
        else
        {
            img_qualidade.enabled = true;
            img_qualidade.GetComponent<RectTransform>().sizeDelta = new Vector2(img_qualidade.GetComponent<RectTransform>().sizeDelta.x * (_qualidade / 100), img_qualidade.GetComponent<RectTransform>().sizeDelta.y);
            txt_info.enabled = false;
        }
    }

    public void Hide()
    {
        cg_tooltip.alpha = 0;
    }
}