using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioClip resetAudio;
    public AudioClip pointAudio;
    private AudioSource audioS;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    public void resetSound()
    {
        audioS.PlayOneShot(resetAudio, 0.09f);
    }
    public void pointSound()
    {
        audioS.PlayOneShot(pointAudio, 0.07f);
    }
}
