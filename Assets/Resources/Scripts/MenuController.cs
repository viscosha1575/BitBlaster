using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    public Text highScoreText;
    public int highScoreInt;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void Awake()
    {
        if (PlayerPrefs.HasKey("highscore"))
        {
            this.highScoreInt = PlayerPrefs.GetInt("highscore");
        }
        else
        {
            highScoreInt = 0;
            PlayerPrefs.SetInt("highscore", 0);
        }
        this.highScoreText.text = "highscore " + this.highScoreInt.ToString();
    }
    public void PlayClick()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitClick()
    {
        Application.Quit();
    }
}
