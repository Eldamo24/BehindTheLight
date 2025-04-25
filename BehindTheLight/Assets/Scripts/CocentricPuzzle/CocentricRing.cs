using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CocentricRing : MonoBehaviour, IInteractable
{
    [SerializeField] private float rotationStep = 30f;
    [SerializeField] private float correctAngle = 0f;
    [SerializeField] private CocentricController controller;
    [SerializeField] private string onInteractMsg;

    private bool isCorrect;
    private Color baseColor;
    private Renderer rend;

    public string OnInteractMsg => onInteractMsg;
    internal bool IsCorrect => isCorrect;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        baseColor = rend.material.color;
    }


    public void OnInteract()
    {
        if (!controller.IsSolved)
        {
            transform.Rotate(0f, rotationStep, 0f);
            CheckAlignment();
            controller.CheckSolution();
        }
    }

    private void CheckAlignment()
    {
        float angleY = transform.localEulerAngles.y;
        float dif = Mathf.Abs(Mathf.DeltaAngle(angleY, correctAngle));

        isCorrect = dif < 0.1f;
        rend.material.color = isCorrect ? Color.green : baseColor;
    }

    internal void PaintSolved(Color solvedColor) =>
        rend.material.color = solvedColor;
}
