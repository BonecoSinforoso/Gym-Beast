using System.IO;
using UnityEditor;
using UnityEngine;

public class Script_PastaCriar
{
    [MenuItem("Pasta/_CriarME")]
    static void Pastas_Criar()
    {
        string[] _pasta = { "Animations", "Animators", "AudioClips", "AudioMixers", "AvatarMasks", "LightingSettings", "Materials", "Meshes", "PhysicsMaterials", "Prefabs", "RenderTextures", "Scenes", "Scriptables", "Scripts", "Shaders", "Sprites", "Textures", "VolumeProfiles" };

        string _pastaFiles = Path.Combine(Application.dataPath, "_Files");
        string _pastaMe = Path.Combine(Application.dataPath, "_ME");

        if (!Directory.Exists(_pastaFiles))
        {
            Directory.CreateDirectory(_pastaFiles);
        }

        if (!Directory.Exists(_pastaMe))
        {
            Directory.CreateDirectory(_pastaMe);

            for (int i = 0; i < _pasta.Length; i++)
            {
                Directory.CreateDirectory(Path.Combine(_pastaMe, _pasta[i]));
            }

            Debug.Log("Pastas Criadas.");
        }
        else
        {
            Debug.Log($"A pasta já existe em: {_pastaMe}");
        }
    }

    [MenuItem("Pasta/_CriarSinforoso")]
    static void PastasCompartilhadas_Criar()
    {
        string[] _pasta = { "Animations", "Animators", "AudioClips", "AudioMixers", "AvatarMasks", "LightingSettings", "Materials", "Meshes", "PhysicsMaterials", "Prefabs", "RenderTextures", "Scenes", "Scriptables", "Scripts", "Shaders", "Sprites", "Textures", "VolumeProfiles" };

        string _pastaSinforoso = Path.Combine(Application.dataPath, "_Sinforoso");

        if (!Directory.Exists(_pastaSinforoso))
        {
            Directory.CreateDirectory(_pastaSinforoso);

            for (int i = 0; i < _pasta.Length; i++)
            {
                Directory.CreateDirectory(Path.Combine(_pastaSinforoso, _pasta[i]));
            }

            Debug.Log("Pastas Criadas.");
        }
        else
        {
            Debug.Log($"A pasta já existe em: {_pastaSinforoso}");
        }
    }
}