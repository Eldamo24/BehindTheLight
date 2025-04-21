using UnityEngine;

public class CocentricController : MonoBehaviour
{
   
    [SerializeField]private CocentricRing ring1;
    [SerializeField] private CocentricRing ring2;
    [SerializeField] private CocentricRing ring3;

    public bool solvedPuzzle = false;

    public void CheckSolution()
    {
        if (ring1.correctPosition && ring2.correctPosition && ring3.correctPosition)
        {
            if (!solvedPuzzle)
            {
                solvedPuzzle = true;
                Solved();
            }
        }
    }

    private void Solved()
    {
        Debug.Log("¡Cocentric ring solved!");

        if (ring1 != null) ring1.GetComponent<Renderer>().material.color = Color.yellow;
        if (ring2 != null) ring2.GetComponent<Renderer>().material.color = Color.yellow;
        if (ring3 != null) ring3.GetComponent<Renderer>().material.color = Color.yellow;
    }

}
