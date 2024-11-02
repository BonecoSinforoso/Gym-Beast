using UnityEditor;
using UnityEngine;

public class Script_PastaAbrir : EditorWindow
{
    [MenuItem("Pasta/Scripts")]
    static void Scripts()
    {
        GoTo("Assets/_ME/Scripts");
    }

    [MenuItem("Pasta/Scenes")]
    static void Scenes()
    {
        GoTo("Assets/_ME/Scenes");
    }

    static void GoTo(string _pastaCaminho)
    {
        string[] _asset = AssetDatabase.FindAssets("", new[] { _pastaCaminho });

        string _assetCaminho = _pastaCaminho;

        if (_asset.Length > 0) _assetCaminho = AssetDatabase.GUIDToAssetPath(_asset[0]);

        Object _pastaObj = AssetDatabase.LoadAssetAtPath(_assetCaminho, typeof(Object));
        Selection.activeObject = _pastaObj;
        EditorGUIUtility.PingObject(_pastaObj);
    }
}