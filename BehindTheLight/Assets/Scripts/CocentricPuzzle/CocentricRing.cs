using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocentricRing : MonoBehaviour, IInteractable
{
    [SerializeField] private float rotationStep = 30f;
    [SerializeField] private float correctAngle = 0f;
    [SerializeField] private CocentricController controller;

    [SerializeField] private string onInteractMsg;

    public string OnInteractMsg => onInteractMsg;

    public bool correctPosition = false;

    public void OnInteract()
    {
        if (!controller.solvedPuzzle)
        {
            transform.Rotate(0f, rotationStep, 0f);
            CheckAlignment();
            if (controller != null) controller.CheckSolution();
        }
    }

    public void CheckAlignment()
    {
        float angleY = transform.localEulerAngles.y;
        float dif = Mathf.Abs(Mathf.DeltaAngle(angleY, correctAngle));
        correctPosition = (dif < 0.1f);
        GetComponent<Renderer>().material.color = correctPosition ? Color.green : Color.gray;
    }

}
