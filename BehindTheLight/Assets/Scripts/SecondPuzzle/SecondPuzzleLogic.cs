using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SecondPuzzleLogic : MonoBehaviour
{
    [SerializeField] private TextMeshPro displayText;
    [SerializeField] private int numOfButtons = 3;    

    private bool solvedPuzzle = false;

    private int[] sequence;             
    private int currentIndex = 0;

    void Start()
    {
        RestartSequence();  
    }

    /// <summary>
    /// Generates a sequence with the number of buttons availables
    /// </summary>
    void RestartSequence()
    {
        sequence = new int[numOfButtons];
        List<int> availableButtons = new List<int>();
        for (int i = 1; i <= numOfButtons; i++)
        {
            availableButtons.Add(i);
        }
        for (int idx = 0; idx < numOfButtons; idx++)
        {
            int indiceAleatorio = Random.Range(0, availableButtons.Count);
            sequence[idx] = availableButtons[indiceAleatorio];
            availableButtons.RemoveAt(indiceAleatorio);
        }

        currentIndex = 0;
        solvedPuzzle = false;
        UpdateSequenceText();
    }

    /// <summary>
    /// This function updates the sequence text on the panel
    /// </summary>
    void UpdateSequenceText()
    {
        string textSequence = string.Join("- ", sequence);
        displayText.text = textSequence;
    }


    /// <summary>
    /// Function that activates on pressed button
    /// </summary>
    /// <param name="idBoton">Id of pressed button</param>
    public void OnButtonPressedSequence(int idBoton)
    {
        if (solvedPuzzle) return;

        if (sequence[currentIndex] == idBoton)
        {
            currentIndex++;
            if (currentIndex >= sequence.Length)
            {
                CompletedPuzzle();
            }
        }
        else
        {
            // Wrong Button
            Debug.Log("Wrong Button. Restarting sequence...");
            RestartSequence();
        }
    }

    void CompletedPuzzle()
    {
        solvedPuzzle = true;
        Debug.Log("¡Good Job!");
    }

}
