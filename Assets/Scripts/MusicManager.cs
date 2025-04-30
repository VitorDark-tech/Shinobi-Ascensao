using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioClip level1Music;
    public AudioClip level2Music;
    public AudioClip level3Music;

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Cena carregada: " + scene.name); 

        switch (scene.name)
        {
            case "Level1":
                TocarMusica(level1Music);
                break;
            case "Level2":
                TocarMusica(level2Music);
                break;
            case "Level3":
                TocarMusica(level3Music);
                break;
        }
    }

    private void TocarMusica(AudioClip musica)
    {
        if (musica == null)
            return;

        if (audioSource.clip == musica)
            return;

        audioSource.clip = musica;
        audioSource.loop = true;
        audioSource.Play();
    }
}