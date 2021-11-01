using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GPC;

public class RunMan_UIManager : CanvasManager
{
    public Text _scoreText;
    public Text _highText;
    public Text _finalScoreText;
    public Text _newHighScoreText;

    private void Start()
    {
        _scoreText.text = "Score 0";
        _newHighScoreText.gameObject.SetActive(false);

        HideAll();
    }
    public void ShowGetReadyUI()
    {
        ShowCanvas(0);
    }
    public void HideGetReadyUI()
    {
        HideCanvas(0);
    }
    public void ShowGameOverUI()
    {
        ShowCanvas(1);
    }
    public void ShowGameUI()
    {
        ShowCanvas(2);
    }
    public void HideGameUI()
    {
        HideCanvas(2);
    }
    public void SetScore(int scoreAmount)
    {
        _scoreText.text = "Score" + scoreAmount.ToString("D5");
    }
    public void SetHighScore(int scoreAmount)
    {
        _finalScoreText.text = "High" + scoreAmount.ToString("D5");
    }
    public void SetFinalScore(int scoreAmount)
    {
        _finalScoreText.text = "Final Score" + scoreAmount.ToString("D5");
    }
    public void ShowGotHighScore()
    {
        _newHighScoreText.gameObject.SetActive(true);
    }
}
