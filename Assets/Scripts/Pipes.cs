using UnityEngine;
using System.Collections;

public class Pipes : MonoBehaviour
{
    private GameManager gameManager;
    private SoundManager soundManager;
    private Flappy flappy;
    private bool passed;

    public float speed;

	void Start ()
    {
        gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
        soundManager = FindObjectOfType(typeof(SoundManager)) as SoundManager;
        flappy = FindObjectOfType(typeof(Flappy)) as Flappy;
        passed = false;
	}
	void Update ()
    {
        if (gameManager.CurrentScene() != GameScenes.INGAME)
        {
            return;
        }
        //--------------------------------------------------------------
        if (transform.position.x < flappy.transform.position.x && !passed)
        {
            soundManager.Coin();
            flappy.AddScore();
            passed = true;
        }
        //--------------------------------------------------------------
        transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;

        if (transform.position.x < -10)
        {
            gameObject.SetActive(false);
        }
	}
    private void OnEnable()
    {
        passed = false;
    }
}