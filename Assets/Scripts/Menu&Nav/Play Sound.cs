using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    // Reference to the AudioSource component
    private AudioSource audioSource;

    // Create a singleton pattern to ensure only one instance exists
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    GameObject audioManagerObject = new GameObject("AudioManager");
                    instance = audioManagerObject.AddComponent<AudioManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject); // Prevent this GameObject from being destroyed when scenes change

        audioSource = GetComponent<AudioSource>();
    }

    // Play a sound effect
    public void PlaySoundEffect(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}

