using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
    private GameManager gameManager;
    private bool isPaused;

    public Texture2D pause;
    public Texture2D play;
    public float size;

	void Start ()
    {
        gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
	}

	void OnGUI ()
    {
        if (gameManager.CurrentScene() == GameScenes.INGAME)
        {
            if (!isPaused)
            {
                if (GUI.Button(new Rect(0, 0, pause.width, pause.height), pause, GUIStyle.none))
                {
                    isPaused = true;
                    Time.timeScale = 0;
                }
            }
            else
            {
                if (GUI.Button(new Rect(0, 0, play.width, play.height), play, GUIStyle.none))
                {
                    isPaused = false;
                    Time.timeScale = 1;
                }
            }
        }
	}
}