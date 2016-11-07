using UnityEngine;
using System.Collections;

public class NewScore : MonoBehaviour
{
    private float timer;
    private float interval;

	void Start ()
    {
        timer = 0f;
        interval = 0.1f;
	}

	void Update ()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            gameObject.GetComponent<Renderer>().enabled = !gameObject.GetComponent<Renderer>().enabled;
            timer = 0f;
        }
	}
}