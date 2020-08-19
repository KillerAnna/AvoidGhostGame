using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text scoreText, recordScore;

    public AudioClip mainAudio, DeathAudio;
    AudioSource aud;

    public float score;
    private bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        isGameOver = false;
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver)
        {
            scoreText.text = "Score : " + score.ToString();
            //timeText.text = "Time : " + (int)surviveTime;
            //메인음악
            aud.PlayOneShot(mainAudio);
        }
        else
        {
            //죽을때 트는 음악
            aud.PlayOneShot(DeathAudio);
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void EndGame()
    {
        isGameOver = true;
        gameoverText.SetActive(true);

        float bestScore = PlayerPrefs.GetFloat("BestScore");

        if(score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }

        recordScore.text = "Best Score: " + bestScore;
    }
}
//콜렉션 일반화
//List<T>
//Stack<T>
//Queue<T>
//Dictionary<T,U>

//PlayerPrefs.Set Int(string,int)
//PlayerPrefs.Set Float(string,f)
//PlayerPrefs.Set String(string,s)

//date가 없을 시 기본값이 저장된다.



