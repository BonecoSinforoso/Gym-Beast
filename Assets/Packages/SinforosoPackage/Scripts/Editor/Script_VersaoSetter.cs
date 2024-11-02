using UnityEditor;
using UnityEngine;

public class Script_VersaoSetter : MonoBehaviour
{
    static void Versao_Set(int _valor)
    {
        string _versao = Application.version;

        string[] _parte = _versao.Split('.');

        _parte[_valor] = (int.Parse(_parte[_valor]) + 1).ToString();

        PlayerSettings.bundleVersion = _parte[0] + "." + _parte[1] + "." + _parte[2] + "." + _parte[3];

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    [MenuItem("Versao/Major")]
    static void Major()
    {
        Versao_Set(0);
    }

    [MenuItem("Versao/Minor")]
    static void Minor()
    {
        Versao_Set(1);
    }

    [MenuItem("Versao/Patch")]
    static void Patch()
    {
        Versao_Set(2);
    }

    [MenuItem("Versao/Release")]
    static void Release()
    {
        Versao_Set(3);
    }
}