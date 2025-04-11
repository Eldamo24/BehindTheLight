using UnityEngine;

public class ButtonPuzzle : MonoBehaviour, IInteractable
{
    public int id = 0;
    [SerializeField] private SecondPuzzleLogic puzzleManager;
    [SerializeField] private string onInteractMsg;

    public string OnInteractMsg => onInteractMsg;

    public void OnInteract()
    {
        if (puzzleManager != null)
        {
            puzzleManager.OnButtonPressedSequence(id);
        }
    }
}
