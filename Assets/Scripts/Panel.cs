using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour
{
    private SoundManager soundManager;

	void Start ()
    {
        soundManager = FindObjectOfType(typeof(SoundManager)) as SoundManager;
	}
	void Update ()
    {
	
	}
    public void StartSound()
    {
        soundManager.Death();
    }
}