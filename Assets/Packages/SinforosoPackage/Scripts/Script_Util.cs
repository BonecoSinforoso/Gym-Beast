using UnityEngine;

public class Script_Util : MonoBehaviour
{
    /// <summary>
    /// retorna true se dist entre 1 e 2 for menor q dist entre 1 e 3
    /// </summary>
    public static bool Closest_Get(Vector3 _valor_01, Vector3 _valor_02, Vector3 _valor_03)
    {
        return Vector3.Distance(_valor_01, _valor_02) < Vector3.Distance(_valor_01, _valor_03);
    }

    /// <summary>
    /// _valor_01 = oq repete --- _valor_02 = testar para ver se eh mais prox --- _valor_03 = antigo/atual
    /// </summary>
    public static bool Closest2D_Get(Vector3 _valor_01, Vector3 _valor_02, Vector3 _valor_03)
    {
        return Vector2.Distance(_valor_01, _valor_02) < Vector2.Distance(_valor_01, _valor_03);
    }

    public static float Direction2D_Get(Vector2 _pos, Vector2 _alvoPos, float _acrescimo = 0)
    {
        Vector2 _dir = _alvoPos - _pos;
        float _angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
        return _angle + _acrescimo;
    }

    public static float RandomValue_GetFloat(Vector2 _v2)
    {
        return Random.Range(_v2.x, _v2.y);
    }

    public static int RandomValue_GetInt(Vector2 _v2)
    {
        return Random.Range((int)_v2.x, (int)(_v2.y + 1));
    }

    public static void Cg_Toggle(CanvasGroup _cg)
    {
        _cg.alpha = _cg.alpha == 0 ? 1 : 0;
        _cg.blocksRaycasts = _cg.alpha == 1;
        _cg.interactable = _cg.alpha == 1;
    }

    public static void Cg_Set(CanvasGroup _cg, bool _valor)
    {
        _cg.alpha = _valor ? 1 : 0;
        _cg.blocksRaycasts = _valor;
        _cg.interactable = _valor;
    }

    public static void AudioSource_Play(AudioSource _audioSource, AudioClip[] _ac)
    {
        _audioSource.PlayOneShot(_ac[Random.Range(0, _ac.Length)]);
    }
}