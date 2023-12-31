using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using Unity.VisualScripting;

// namespace RandomSystem
// {
public class Random : MonoBehaviour
{
  public TextMeshProUGUI textRestrat;

  [SerializeField] public int playerHp;
  public BotRandom botRandom;
  [SerializeField] static private int randomPlayerDice;
  public List<GameObject> dice = new List<GameObject>();
  public GameObject item;

  public GameObject rolling;
  public GameObject textBox;
  public GameObject rollButton, restartButton;

  public TextMeshProUGUI text, textHp;

  [SerializeField] public bool isCheckResult = false;
  [SerializeField] public bool isWait = false;
  [SerializeField] private bool isHealthMax = false;

  [SerializeField] private List<string> demon = new List<string>();
  void Start()
  {
    textRestrat.text = "ROLL DICE";
    playerHp = 3;
    botRandom.botHp = 3;
    textBox.SetActive(false);
    rollButton.SetActive(true);
    restartButton.SetActive(false);
    text.text = "";

    rolling.SetActive(false);
    item.SetActive(false);

    for (int i = 0; i < 3; i++)
    {
      dice[i].SetActive(false);
    }
    demon.Add("Buer");
    demon.Add("Caim");
  }
  private void HealthSystem()
  {
    if (playerHp == 3)
    {
      isHealthMax = true;
      playerHp = 3;
    }
    else if (playerHp <= 2)
    {
      isHealthMax = false;
    }

    if (botRandom.botHp == 3)
    {
      botRandom.isHealthMax = true;
      botRandom.botHp = 3;
    }
    else if (botRandom.botHp <= 2)
    {
      botRandom.isHealthMax = false;
    }


  }
  public void PickRandom()
  {
    if (isWait == false && isCheckResult == false)
    {
      textBox.SetActive(false);
      rolling.SetActive(true);
      item.SetActive(false);

      randomPlayerDice = UnityEngine.Random.Range(0, 3);
      botRandom.randomBotDice = UnityEngine.Random.Range(0, 3);
      if (randomPlayerDice == 0)//ออกกระดาษ
      {
        Debug.Log(randomPlayerDice);
        dice[2].SetActive(false);
        dice[1].SetActive(true);
        dice[0].SetActive(false);
        Debug.Log("You got paper");

      }
      else if (randomPlayerDice == 1)//ออกค้อน
      {
        Debug.Log(randomPlayerDice);
        dice[2].SetActive(false);
        dice[1].SetActive(false);
        dice[0].SetActive(true);
        Debug.Log("You got rock");

      }
      else if (randomPlayerDice == 2)//ออกกรรไกร
      {
        Debug.Log(randomPlayerDice);
        dice[2].SetActive(true);
        dice[1].SetActive(false);
        dice[0].SetActive(false);
        Debug.Log("You got scissors");

      }
      StartCoroutine(RollingAnimation());
    }
  }
  IEnumerator RollingAnimation()
  {
    isWait = true;
    isCheckResult = true;
    Result();
    yield return new WaitForSeconds(0.5f);
    textBox.SetActive(true);
    item.SetActive(true);
    rolling.SetActive(false);
    yield return new WaitForSeconds(0.5f);
    isWait = false;
    isCheckResult = false;

  }
  public void Result()
  {

    if (isCheckResult == true && isWait == true)
    {
      if (randomPlayerDice == 0 && botRandom.randomBotDice == 0)
      {
        if (isHealthMax == false)
        {
          playerHp += 1;
        }
        if (botRandom.isHealthMax == false)
        {
          botRandom.botHp += 1;
        }
        text.SetText("It's a tie!, You and " + demon[0] + " selected paper");
        Debug.Log("It's a tie!, You and bot selected paper" + randomPlayerDice + " & " + botRandom.randomBotDice);
      }
      else if (randomPlayerDice == 0 && botRandom.randomBotDice == 1)
      {
        playerHp += 0;
        botRandom.botHp -= 1;

        text.text = "You win!, Paper cover rock.";
        Debug.Log("You win!, Paper cover rock." + randomPlayerDice + " & " + botRandom.randomBotDice);
      }
      else if (randomPlayerDice == 0 && botRandom.randomBotDice == 2)
      {
        playerHp -= 1;
        botRandom.botHp += 0;

        text.text = "You lose!, Scissors cut paper.";
        Debug.Log("You lose!, Scissors cut paper." + randomPlayerDice + " & " + botRandom.randomBotDice);
      }

      else if (randomPlayerDice == 1 && botRandom.randomBotDice == 0)
      {
        playerHp -= 1;
        botRandom.botHp += 0;

        text.text = "You lose! Paper cover rock.";
        Debug.Log("You lose! Paper cover rock." + randomPlayerDice + " & " + botRandom.randomBotDice);
      }
      else if (randomPlayerDice == 1 && botRandom.randomBotDice == 1)
      {
        if (isHealthMax == false)
        {
          playerHp += 1;
        }
        if (botRandom.isHealthMax == false)
        {
          botRandom.botHp += 1;
        }

        text.SetText("It's a tie!, You and " + demon[0] + " selected rock.");
        Debug.Log("It's a tie!, You and bot selected rock." + randomPlayerDice + " & " + botRandom.randomBotDice);
      }
      else if (randomPlayerDice == 1 && botRandom.randomBotDice == 2)
      {
        playerHp += 0;
        botRandom.botHp -= 1;
        text.text = "You win!, Rock smashes scissors.";
        Debug.Log("You win!, Rock smashes scissors." + randomPlayerDice + " & " + botRandom.randomBotDice);
      }

      else if (randomPlayerDice == 2 && botRandom.randomBotDice == 0)
      {
        playerHp += 0;
        botRandom.botHp -= 1;
        text.text = "You win!, Scissors cut paper.";
        Debug.Log("You win!, Scissors cut paper." + randomPlayerDice + " & " + botRandom.randomBotDice);
      }
      else if (randomPlayerDice == 2 && botRandom.randomBotDice == 1)
      {
        playerHp -= 1;
        botRandom.botHp += 0;
        text.text = "You lose!, Rock smashes scissors.";
        Debug.Log("You lose!, Rock smashes scissors." + randomPlayerDice + " & " + botRandom.randomBotDice);
      }
      else if (randomPlayerDice == 2 && botRandom.randomBotDice == 2)
      {
        if (isHealthMax == false)
        {
          playerHp += 1;
        }
        if (botRandom.isHealthMax == false)
        {
          botRandom.botHp += 1;
        }

        text.SetText("It's a tie!, You and " + demon[0] + " selected scissors.");
        Debug.Log("It's a tie!, You and bot selected scissors." + randomPlayerDice + " & " + botRandom.randomBotDice);
      }
    }
  }


  void Update()
  {
    HealthSystem();

    textHp.text = playerHp.ToString();
    botRandom.textHp.text = botRandom.botHp.ToString();
    if (playerHp == 0)
    {
      rollButton.SetActive(false);
      // restartButton.SetActive(true);

      text.fontSize = 100;
      text.text = "YOU LOSE";
      // textRestrat.text = "RESTART";

    }
    if (botRandom.botHp == 0)
    {
      rollButton.SetActive(false);
      // restartButton.SetActive(true);

      text.fontSize = 100;
      text.text = "YOU WIN";
      // textRestrat.text = "RESTART";

    }
  }
}
//}

