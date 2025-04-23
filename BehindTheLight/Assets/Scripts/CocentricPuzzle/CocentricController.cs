using UnityEngine;

public class CocentricController : MonoBehaviour
{
    [SerializeField] private CocentricRing ring1;
    [SerializeField] private CocentricRing ring2;
    [SerializeField] private CocentricRing ring3;

    private Color gold = new Color(0.9f, 0.8f, 0.2f);

    internal bool IsSolved { get; private set; }

    internal void CheckSolution()
    {
        if (!IsSolved &&
            ring1.IsCorrect && ring2.IsCorrect && ring3.IsCorrect)
        {
            IsSolved = true;
            OnSolved();
        }
    }

    private void OnSolved()
    {
        Debug.Log("¡Co­centric ring solved!");

        ring1.PaintSolved(gold);
        ring2.PaintSolved(gold);
        ring3.PaintSolved(gold);
    }
}