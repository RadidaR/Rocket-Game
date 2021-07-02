using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasScript : MonoBehaviour
{
    public GameData gameData;
    public StatsData statsData;
    public MovementData movementData;
    public GameManagerScript gameManager;

    public GameObject uiElements;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI score;

    public TextMeshProUGUI leftFuelText;
    public TextMeshProUGUI rightFuelText;
    public TextMeshProUGUI mainFuelText;
    public Slider mainTankSlider;
    public Slider leftTankSlider;
    public Slider rightTankSlider;

    public GameObject buttons;

    public GameObject winScreen;
    public GameObject lossScreen;
    public TextMeshProUGUI winFinalScore;
    public TextMeshProUGUI lossFinalScore;

    public GameObject[] lives;

    public GameObject extraFuel;
    public Slider extraFuelSlider;
    public float currentMaxExtraFuel;

    //public TextMeshProUGUI amountText;

    public GameObject pauseMenu;
    public GameEvent eButtonClicked;

    // Start is called before the first frame update
    void Start()
    {
        //lives = GetComponentsInChildren<Image>();
        UpdateLives();

        mainTankSlider.maxValue = movementData.mainTankMaxFuel;
        leftTankSlider.maxValue = movementData.sideTanksMaxFuel;
        rightTankSlider.maxValue = movementData.sideTanksMaxFuel;

        UpdateExtraFuel();
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = gameManager.timeLeft.ToString();

        score.text = gameData.currentScore.ToString();

        //Debug.Log(Mathf.RoundToInt((movementData.currentLeftFuel / movementData.sideTanksMaxFuel) * 100).ToString());

        //leftFuelText.text = Mathf.Round(movementData.currentLeftFuel).ToString();
        leftFuelText.text = Mathf.RoundToInt((movementData.currentLeftFuel / movementData.sideTanksMaxFuel) * 100).ToString() + "%";
        //leftFuel.text = movementData.currentLeftFuel.ToString();
        //rightFuelText.text = Mathf.Round(movementData.currentRightFuel).ToString();
        rightFuelText.text = Mathf.RoundToInt((movementData.currentRightFuel / movementData.sideTanksMaxFuel) * 100).ToString() + "%";
        //rightFuel.text = movementData.currentRightFuel.ToString();
        mainFuelText.text = Mathf.RoundToInt((movementData.currentMainFuel / movementData.mainTankMaxFuel) * 100).ToString() + "%";
        //mainFuel.text = movementData.currentMainFuel.ToString();

        if (gameData.extraFuel > 0)
        {
            if (!extraFuel.activeInHierarchy)
            {
                extraFuel.SetActive(true);
            }

            //amountText.text = Mathf.RoundToInt(gameData.extraFuel).ToString();
        }
        else
        {
            gameData.extraFuel = 0;
            extraFuel.SetActive(false);
        }

        mainTankSlider.value = movementData.currentMainFuel;
        leftTankSlider.value = movementData.currentLeftFuel;
        rightTankSlider.value = movementData.currentRightFuel;
        if (currentMaxExtraFuel != 0)
        {
            extraFuelSlider.value = gameData.extraFuel;
        }
    }

    public void UpdateExtraFuel()
    {
        currentMaxExtraFuel = gameData.extraFuel;
        extraFuelSlider.maxValue = currentMaxExtraFuel;
    }

    public void WinScreen()
    {
        HideUI();
        buttons.SetActive(true);
        winScreen.SetActive(true);
        winFinalScore.text = "Final Score: " + gameData.currentScore.ToString();
    }

    public void LossScreen()
    {
        HideUI();
        buttons.SetActive(true);
        lossScreen.SetActive(true);
        lossFinalScore.text = "Final Score: " + gameData.currentScore.ToString();
    }

    public void PauseScreen()
    {
        //HideUI();
        pauseMenu.SetActive(true);
    }

    public void UnpauseScreen()
    {
        pauseMenu.SetActive(false);
    }

    private void HideUI()
    {
        uiElements.SetActive(false);

        //timer.gameObject.SetActive(false);
        //score.gameObject.SetActive(false);
        //leftFuelText.gameObject.SetActive(false);
        //rightFuelText.gameObject.SetActive(false);
        //mainFuelText.gameObject.SetActive(false);

        //foreach (Image life in lives)
        //{
        //    life.gameObject.SetActive(false);
        //}

        //extraFuel.gameObject.SetActive(false);
    }

    public void ButtonClicked()
    {
        eButtonClicked.Raise();
    }

    public void UpdateLives()
    {
        for (int i = 0; i < statsData.currentLives; i++)
        {
            lives[i].gameObject.SetActive(true);
        }

        for (int i = 9; i >= statsData.currentLives; i--)
        {
            lives[i].gameObject.SetActive(false);
        }
    }
}
