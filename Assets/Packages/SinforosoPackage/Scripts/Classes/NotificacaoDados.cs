using System;
using UnityEngine;

[Serializable]
public class NotificacaoDados
{
    public string texto;
    public bool traduzir = false;
    public float delay = 3f;
    public bool imediata = false; //cancela as outras
    public Color cor_fundo;

    public static NotificacaoDados NotificacaoDados_CriarInfo(string _texto, bool _traduzir = false, float _delay = 3f, bool _imediata = false)
    {
        NotificacaoDados _notificacaoDados = new NotificacaoDados
        {
            texto = _texto,
            traduzir = _traduzir,
            delay = _delay,
            imediata = _imediata,
            cor_fundo = Color.white
        };

        return _notificacaoDados;
    }

    public static NotificacaoDados NotificacaoDados_CriarAviso(string _texto, bool _traduzir = false, float _delay = 3f, bool _imediata = false)
    {
        NotificacaoDados _notificacaoDados = new NotificacaoDados
        {
            texto = _texto,
            traduzir = _traduzir,
            delay = _delay,
            imediata = _imediata,
            cor_fundo = Color.yellow
        };

        return _notificacaoDados;
    }

    public static NotificacaoDados NotificacaoDados_CriarErro(string _texto, bool _traduzir = false, float _delay = 3f, bool _imediata = false)
    {
        NotificacaoDados _notificacaoDados = new NotificacaoDados
        {
            texto = _texto,
            traduzir = _traduzir,
            delay = _delay,
            imediata = _imediata,
            cor_fundo = Color.red
        };

        return _notificacaoDados;
    }
}