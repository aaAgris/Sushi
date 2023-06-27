using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioClip soundClip;
    public float soundDuration = 1f; // Duration in seconds for the sound to play

    private AudioSource audioSource;
    private bool isPlaying = false;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(PlaySound);

        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void PlaySound()
    {
        if (!isPlaying)
        {
            isPlaying = true;
            audioSource.clip = soundClip; // Assign the AudioClip to the AudioSource
            audioSource.Play();
            Invoke("StopSound", soundDuration);
        }
    }

    private void StopSound()
    {
        isPlaying = false;
        audioSource.Stop();
    }
}