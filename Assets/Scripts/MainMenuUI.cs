using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject instructionsUI;

    public void play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void showInstructions()
    {
        instructionsUI.SetActive(true);
    }

    public void hideInstructions()
    {
        instructionsUI.SetActive(false);
    }
}
