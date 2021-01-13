using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instance;

    public Slider energyBar;

    public Text currentScoreText;
    public Text highScoreText;
    public Text moneyEarnedText;
    public Text currentMoneyText;
    public Text heightText;

    private float currentNumber;
    private float desiredNumber;
    private float initialNumber;

    public float animationTime = 1.5f;

    public GameObject shopMenu;
    public GameObject endDay;
    public GameObject gameOverPanel;

    public void AddNumber(float value)
    {
        initialNumber = currentNumber;
        desiredNumber += value;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentNumber != desiredNumber)
        {
            // if(initialNumber)
            //{
            currentNumber += (Time.deltaTime * animationTime) * (desiredNumber - initialNumber);
            if (currentNumber >= desiredNumber)
            {
                currentNumber = desiredNumber;
            }
            //}
        }

        currentScoreText.text = "Current Score: " + currentNumber.ToString("0");
    }

    

    // Start is called before the first frame update
    void Awake()
    {
        instance = GetComponent<GUIManager>();
    }
    void SetGameOverUI()
    {
        gameOverPanel.SetActive(true);
        currentScoreText.text = "Current score:" + GameManager.instance.currentScore;
        highScoreText.text = "High Score: " + GameManager.instance.highScore;
        moneyEarnedText.text = "Money earned: " + GameManager.instance.moneyEarned;
        heightText.text = "Height: " + GameManager.instance.GetHeightOfPlayer() + " m";
        AddNumber(GameManager.instance.currentScore);

    }

    public void SetEnergyUI(float currentEnergy)
    {
        energyBar.value = currentEnergy;
    }

    public void SetMaxEnergy(float maxEnergy)
    {
        energyBar.maxValue = maxEnergy;
        energyBar.value = maxEnergy;
    }

    public void GameOver()
    {
        if(GameManager.instance.isGameOver)
        SetGameOverUI();
    }

    public void GoToShop()
    {
        shopMenu.SetActive(true);
        endDay.SetActive(false);
    }

    public void EndDay()
    {
        SceneManager.LoadScene(0);
    }
   

}
