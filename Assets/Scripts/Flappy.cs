using UnityEngine;
using System.Collections;

public class Flappy : MonoBehaviour
{
    private GameManager gameManager;
    private GameOver gameOver;
    private SoundManager soundManager;

    private Animator anim;
    private int score;

    public float flyForce;
    public TextMesh scoreText;
    public TextMesh scoreTextShadow;

    void Start()
    {
        gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
        gameOver = FindObjectOfType(typeof(GameOver)) as GameOver;
        soundManager = FindObjectOfType(typeof(SoundManager)) as SoundManager;

        anim = GetComponentInChildren<Animator>();

        score = 0;
    }
	void Update ()
    {
        if (gameManager.CurrentScene() == GameScenes.GAMEOVER)
        {
            transform.eulerAngles -= new Vector3(0, 0, 5f);
            if (transform.eulerAngles.z < 270 && transform.eulerAngles.z > 30)
            {
                transform.eulerAngles = new Vector3(0, 0, 270);
            }
        }
        if (gameManager.CurrentScene() != GameScenes.INGAME)
        {
            return;
        }
        //---------------------------------------------------------------
	    if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        {
            soundManager.Wing();
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * flyForce);
            anim.SetBool("fly", true);
        }
        else
        {
            anim.SetBool("fly", false);
        }
        //---------------------------------------------------------------
        if (GetComponent<Rigidbody2D>().velocity.y < 1)
        {
            transform.eulerAngles -= new Vector3(0, 0, 5f);
            if (transform.eulerAngles.z < 270 && transform.eulerAngles.z > 30)
            {
                transform.eulerAngles = new Vector3(0, 0, 270);
            }
        }
        else if (GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            transform.eulerAngles += new Vector3(0, 0, 10f);
            if (transform.eulerAngles.z < 270)
            {
                transform.eulerAngles = new Vector3(0, 0, 30);
            }
        }
        //---------------------------------------------------------------
        if (transform.position.y > 4)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 4);
        }
	}
    private void OnCollisionEnter2D(Collision2D collide)
    {
        if (gameManager.CurrentScene() == GameScenes.INGAME)
        {
            soundManager.Hit();
        }
        gameManager.SetGameOver();
        gameOver.FinalScore(score);
    }
    //----------------------------------------------------------------
    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (gameManager.CurrentScene() == GameScenes.INGAME)
        {
            soundManager.Hit();
        }
        gameManager.SetGameOver();
        gameOver.FinalScore(score);
    }
    //----------------------------------------------------------------
    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
        scoreTextShadow.text = score.ToString();
    }
    //----------------------------------------------------------------
    public void RestartScore()
    {
        score = 0;
        scoreText.text = score.ToString();
        scoreTextShadow.text = score.ToString();
    }
}