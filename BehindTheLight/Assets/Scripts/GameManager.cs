using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private bool isPaused;
    public bool IsPaused { get { return isPaused; } private set { isPaused = value; } }

    private void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        isPaused = false;
    }



    public void SetPaused()
    {
        isPaused = !isPaused;
        GameObject.FindObjectOfType<MainMenuController>().OnPause();
    }

}
