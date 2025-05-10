using UnityEngine;

[RequireComponent(typeof(Renderer))] 
public class ButtonPuzzle : MonoBehaviour, IInteractable
{
    [SerializeField] private int id = 0;
    [SerializeField] private SecondPuzzleLogic puzzleManager;
    [SerializeField] private string onInteractMsg;

    public string OnInteractMsg => onInteractMsg;

    private Color baseColor;
    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        baseColor = rend.material.color;
    }

    public void OnInteract()
    {
        if (puzzleManager != null)
            puzzleManager.OnButtonPressedSequence(id, this);
    }

    public void SetColor(Color c) => rend.material.color = c;
    public void ResetColor() => rend.material.color = baseColor;
}
