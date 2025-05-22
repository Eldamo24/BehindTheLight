using System.Collections.Generic;
using UnityEngine;

public class SecondPuzzleLogic : MonoBehaviour
{

    [SerializeField] private Door doorToUnlock;


    [SerializeField] private int numOfButtons = 3;
    [SerializeField] private List<ButtonPuzzle> buttons;


    [SerializeField] private List<Renderer> slotRenderers;


    [SerializeField] private List<Texture2D> numberTextures;


    [SerializeField] private Color baseSlotColor = Color.white;
    [SerializeField] private Color okColor = Color.green;
    [SerializeField] private Color completeColor = new Color(0.9f, 0.8f, 0.2f);

    int[] sequence;          
    int currentIndex;       
    bool puzzleSolved;

    void Start() => RestartSequence();

    public bool OnButtonPressedSequence(int idButton, ButtonPuzzle pressedButton)
    {
        if (puzzleSolved) return true;  

        if (sequence[currentIndex] == idButton) 
        {
            currentIndex++;
            //HighlightProgress();

            if (currentIndex >= sequence.Length)
                CompletePuzzle();

            return true;  
        }

        RestartSequence();
        return false;   
    }

    void CompletePuzzle()
    {
        puzzleSolved = true;
        doorToUnlock.UnlockDoor();

       // foreach (var r in slotRenderers) r.material.color = completeColor;
       // foreach (var b in buttons) b.SetColor(completeColor);

        Debug.Log("¡Puzzle completado!");
    }

    void RestartSequence()
    {
        sequence = GenerateSequence(numOfButtons);
        currentIndex = 0;
        puzzleSolved = false;

        for (int i = 0; i < slotRenderers.Count && i < sequence.Length; i++)
        {
            int idx = sequence[i] - 1;
            if (idx >= numberTextures.Count)
            {
                Debug.LogError($"numberTextures no tiene entrada para el número {sequence[i]} (indice {idx}).");
                continue;
            }

            //Material mat = slotRenderers[i].material;
            //mat.mainTexture = numberTextures[idx];
            //mat.color = baseSlotColor;

            //slotRenderers[i].GetComponent<LightedObjects>()?.StartFadeOut();
        }

        foreach (var b in buttons)
        {
           // b.ResetColor();
            b.ResetPosition();
        }
    }

    void HighlightProgress()
    {
        for (int i = 0; i < slotRenderers.Count; i++)
        {
            Color target = (i < currentIndex) ? okColor : baseSlotColor;
            slotRenderers[i].material.color = target;

            if (i < currentIndex)
                slotRenderers[i].GetComponent<LightedObjects>()?.StartFadeIn();
        }
    }

    static int[] GenerateSequence(int n)
    {
        var seq = new int[n];
        var pool = new List<int>();
        for (int i = 1; i <= n; i++) pool.Add(i);

        for (int i = 0; i < n; i++)
        {
            int k = Random.Range(0, pool.Count);
            seq[i] = pool[k];
            pool.RemoveAt(k);
        }
        return seq;
    }
}
