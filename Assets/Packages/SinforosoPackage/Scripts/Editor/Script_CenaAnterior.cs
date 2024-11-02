using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class Script_CenaAnterior : MonoBehaviour
{
    static string cenaUltimaCaminho = "";

    static Script_CenaAnterior()
    {
        EditorSceneManager.sceneClosed += OnSceneClosed;
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private static void OnSceneClosed(Scene _scene)
    {
        cenaUltimaCaminho = _scene.path;
    }

    [MenuItem("Cena/Ultima")]
    static void K()
    {
        ReabrirUltimaCena();
    }

    static void ReabrirUltimaCena()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene(cenaUltimaCaminho);
    }

    static void OnSceneGUI(SceneView sceneView)
    {
        Event e = Event.current;
        if (e.type == EventType.KeyDown && e.keyCode == KeyCode.F12)
        {
            ReabrirUltimaCena();
            e.Use();
        }
    }
}