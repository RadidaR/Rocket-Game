using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    public int storyScene;

    public TextMeshProUGUI highScoreText;
    public GameData gameData;

    private void Start()
    {
        highScoreText.text = $"{PlayerPrefs.GetInt("Highscore")}";
        FindObjectOfType<AudioManager>().StopSound("audio_background_music_1");
        FindObjectOfType<AudioManager>().StopSound("audio_background_music_2");
        FindObjectOfType<AudioManager>().PlayRandomSound("audio_main_menu_");
    }

    public void LoadStoryScene()
    {
        SceneManager.LoadScene(storyScene);
    }
    public void LoadEasyMode()
    {
        gameData.totalPlanets = gameData.easyDifficultyPlanetTotal;
        SceneManager.LoadScene(storyScene);
    }
    public void LoadNormalMode()
    {
        gameData.totalPlanets = gameData.normalDifficultyPlanetTotal;
        SceneManager.LoadScene(storyScene);
    }
    public void LoadHardMode()
    {
        gameData.totalPlanets = gameData.hardDifficultyPlanetTotal;
        SceneManager.LoadScene(storyScene);
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("Highscore");
        highScoreText.text = $"{PlayerPrefs.GetInt("Highscore")}";
    }

    public void PlaySound(string soundName)
    {
        FindObjectOfType<AudioManager>().PlaySound(soundName);
    }


}
