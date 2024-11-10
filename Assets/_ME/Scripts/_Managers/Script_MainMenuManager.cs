using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_MainMenuManager : MonoBehaviour
{
    [SerializeField] AudioClip[] ac;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Game_Start()
    {
        SceneManager.LoadScene("Scene_Game");
    }

    public void Game_Quit()
    {
        Application.Quit();
    }

    public void AudioClip_Play()
    {
        Script_Util.AudioSource_Play(audioSource, ac);
    }
}