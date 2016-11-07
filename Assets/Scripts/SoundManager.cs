using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip title;
    public AudioClip wing;
    public AudioClip hit;
    public AudioClip death;
    public AudioClip coin;

	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
	}
	void Update ()
    {
	
	}
    public void Title()
    {
        audioSource.PlayOneShot(title);
    }
    public void Wing()
    {
        audioSource.PlayOneShot(wing);
    }
    public void Hit()
    {
        audioSource.PlayOneShot(hit);
    }
    public void Death()
    {
        audioSource.PlayOneShot(death);
    }
    public void Coin()
    {
        audioSource.PlayOneShot(coin);
    }
}