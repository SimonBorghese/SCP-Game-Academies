using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryUI : MonoBehaviour
{

    [SerializeField] GameObject victoryScreen;
    public void loadMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void showVictory()
    {
        victoryScreen.SetActive(true);
    }
}
