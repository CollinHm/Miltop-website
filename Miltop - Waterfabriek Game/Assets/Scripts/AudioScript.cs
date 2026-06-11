using UnityEngine;

public class AudioScript : MonoBehaviour
{
    [SerializeField] private AudioClip pickupClip;
    [SerializeField] private AudioClip dropClip;
    [SerializeField] private AudioClip correctClip;
    [SerializeField] private AudioClip wrongClip;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayPickup()
    {
        source.PlayOneShot(pickupClip);
    }

    public void PlayDrop()
    {
        source.PlayOneShot(dropClip);
    }

    public void PlayCorrect()
    {
        source.PlayOneShot(correctClip);
    }

    public void PlayWrong()
    {
        source.PlayOneShot(wrongClip);
    }
}
