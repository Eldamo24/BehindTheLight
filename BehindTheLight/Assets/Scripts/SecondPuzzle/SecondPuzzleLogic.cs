using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondPuzzleLogic : MonoBehaviour
{
    [SerializeField] private List<Image> sequenceSlots;
    [SerializeField] private List<Sprite> numberSprites;
    [SerializeField] private Color baseSlotColor = Color.white;
    [SerializeField] private Color okColor = Color.green;
    [SerializeField] private Color completeColor = new Color(0.9f, 0.8f, 0.2f);

    [SerializeField] private int numOfButtons = 3;
    [SerializeField] private List<ButtonPuzzle> buttons;
    [SerializeField] private Door doorToUnlock;

    int[] sequence;
    int currentIndex;
    bool solvedPuzzle;

    void Start() => RestartSequence();

    public bool OnButtonPressedSequence(int idButton, ButtonPuzzle pressedButton)
    {
        if (solvedPuzzle) return true;

        if (sequence[currentIndex] == idButton)
        {
            pressedButton.SetColor(okColor);
            currentIndex++;
            HighlightProgress();

            if (currentIndex >= sequence.Length)
                CompletedPuzzle();

            return true;
        }

        RestartSequence();
        return false; 
    }

    void CompletedPuzzle()
    {
        solvedPuzzle = true;
        doorToUnlock.UnlockDoor();

        for (int i = 0; i < sequenceSlots.Count; i++)
        {
            sequenceSlots[i].color = completeColor;
        }

        foreach (var btn in buttons)
            btn.SetColor(completeColor);

        Debug.Log("¡Good Job!");
    }

    void RestartSequence()
    {
        sequence = GenerateSequence(numOfButtons);
        currentIndex = 0;
        solvedPuzzle = false;

        for (int i = 0; i < sequenceSlots.Count; i++)
        {
            sequenceSlots[i].sprite = numberSprites[sequence[i] - 1]; // sprites 0-based
            sequenceSlots[i].color = baseSlotColor;
        }

        foreach (var btn in buttons)
        {
            btn.ResetColor();
            btn.ResetPosition();
        }
    }

    void HighlightProgress()
    {
        for (int i = 0; i < sequenceSlots.Count; i++)
        {
            sequenceSlots[i].color = (i < currentIndex) ? okColor : baseSlotColor;
        }
    }

    static int[] GenerateSequence(int n)
    {
        var result = new int[n];
        var pool = new List<int>();
        for (int i = 1; i <= n; i++) pool.Add(i);

        for (int idx = 0; idx < n; idx++)
        {
            int k = Random.Range(0, pool.Count);
            result[idx] = pool[k];
            pool.RemoveAt(k);
        }
        return result;
    }
}