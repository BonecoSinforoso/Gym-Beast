using UnityEditor;
using UnityEditor.SceneManagement;

public class Script_CenaCarregar
{
    [MenuItem("Cena/Aviso")]
    static void Aviso()
    {
        Teste("Assets/_ME/Scenes/Scene_Aviso.unity");
    }

    [MenuItem("Cena/Menu")]
    static void Menu()
    {
        Teste("Assets/_ME/Scenes/Scene_Menu.unity");
    }

    static void Teste(string _caminho)
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();

        EditorSceneManager.OpenScene(_caminho);
    }
}