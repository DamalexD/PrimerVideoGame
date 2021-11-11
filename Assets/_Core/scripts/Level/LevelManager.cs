using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Ins;
    public int coins = 0;
    public TextMeshProUGUI coinsText;
    public List<Life> lifeList;
    public GameObject gameOverMenu;

    
    
    private void Awake(){
        Ins = this;
    }
    
    public void AddCoins(){
        coins++;
        coinsText.text = coins.ToString();

        Debug.Log("LevelManager Coins " + coins);
    }

    public void GameOver(){
        gameOverMenu.gameObject.SetActive(true);
    }

    public void OnPlayerDamage(int _lifes){

        if(_lifes < 0){return;}

        lifeList[_lifes].ApagarVida();

    }
    public void OnRetryClick(){
        Debug.Log("On retryClick");
        SceneManager.LoadScene("Game");
    }
}
