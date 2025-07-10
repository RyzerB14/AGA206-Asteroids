using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip[] audioClip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(bool randomPitch = true)
    {
        if (audioClip == null || audioClip.Length == 0)
            return;

        if(randomPitch)
        {
            audioSource.pitch = Random.Range(-0.8f, 1.1f);
        }
        else
        {
            audioSource.pitch = 1f;
        }
            audioSource.clip = audioClip[0];
        audioSource.pitch = Random.Range(-0.8f, 1.1f);
        audioSource.Play();
    }


    public void PlayRandomSound(bool randomPitch = true)
    {
        audioSource.clip = audioClip[Random.Range(0, audioClip.Length)];
        audioSource.pitch = Random.Range(-0.8f, 1.1f);
        audioSource.Play();
    }
}
