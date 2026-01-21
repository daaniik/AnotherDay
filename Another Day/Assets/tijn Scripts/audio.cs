using UnityEngine;
using System.Collections;

public class RandomSoundPlayer : MonoBehaviour
{
    public AudioClip[] sounds;   // sleep hier je 11 geluiden in de Inspector
    public AudioSource audioSource;

    void Start()
    {
        StartCoroutine(PlayRandomEvery20Seconds());
    }

    IEnumerator PlayRandomEvery20Seconds()
    {
        while (true)
        {
            // Kies een random geluid
            AudioClip clip = sounds[Random.Range(0, sounds.Length)];

            // Speel hem
            audioSource.PlayOneShot(clip);

            // Wacht 20 seconden
            yield return new WaitForSeconds(20f);
        }
    }
}
