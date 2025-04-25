using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SecondPuzzleLogic : MonoBehaviour
{
    [SerializeField] private TextMeshPro displayText;

    [SerializeField] private int numOfButtons = 3;
    [SerializeField] private List<ButtonPuzzle> buttons;  

    [SerializeField] private Color baseTextColor = Color.black;
    [SerializeField] private Color okColor = Color.green;
    [SerializeField] private Color completeColor = new Color(0.9f, 0.8f, 0.2f);

    private int[] sequence;
    private int currentIndex;
    private bool solvedPuzzle;

    private void Start() => RestartSequence();

    public void OnButtonPressedSequence(int idButton, ButtonPuzzle pressedButton)
    {
        if (solvedPuzzle) return;

        if (sequence[currentIndex] == idButton)
        {
            pressedButton.SetColor(okColor);
            currentIndex++;

            if (currentIndex >= sequence.Length)
                CompletedPuzzle();
            else
                HighlightProgress();
        }
        else
        {
            RestartSequence();
        }
    }

    private void CompletedPuzzle()
    {
        solvedPuzzle = true;

        displayText.text = string.Join("- ", sequence);

        displayText.color = completeColor;

        foreach (var btn in buttons)
            btn.SetColor(completeColor);

        Debug.Log("¡Good Job!");
    }

    private void RestartSequence()
    {
        /* Secuencia nueva */
        sequence = GenerateSequence(numOfButtons);
        currentIndex = 0;
        solvedPuzzle = false;

        /* Reset feedback visual */
        displayText.color = baseTextColor;
        foreach (var btn in buttons) btn.ResetColor();

        UpdateSequenceText();
    }

    private void HighlightProgress()
    {
        var progress = new List<string>();
        for (var i = 0; i < sequence.Length; i++)
        {
            string elem = sequence[i].ToString();
            if (i < currentIndex) elem = $"<color=#{ColorUtility.ToHtmlStringRGB(okColor)}>{elem}</color>";
            progress.Add(elem);
        }
        displayText.text = string.Join("- ", progress);
    }

    private int[] GenerateSequence(int n)
    {
        var result = new int[n];
        var pool = new List<int>();
        for (int i = 1; i <= n; i++) pool.Add(i);

        for (int idx = 0; idx < n; idx++)
        {
            int index = Random.Range(0, pool.Count);
            result[idx] = pool[index];
            pool.RemoveAt(index);
        }
        return result;
    }

    private void UpdateSequenceText() =>
        displayText.text = string.Join("- ", sequence);
}
