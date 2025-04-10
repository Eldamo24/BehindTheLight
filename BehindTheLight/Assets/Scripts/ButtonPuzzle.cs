using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzle : MonoBehaviour
{
    public int id = 0;
    [SerializeField] private SecondPuzzleLogic puzzleManager;

    void OnMouseDown()
    {
        if (puzzleManager != null)
        {
             puzzleManager.OnButtonPressedSequence(id);
        }
    }
}
