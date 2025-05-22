using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))] 
public class ButtonPuzzle : MonoBehaviour, IInteractable
{
    [SerializeField] private int id = 0;
    [SerializeField] private SecondPuzzleLogic puzzleManager;
    [SerializeField] private string onInteractMsg;
    [SerializeField] private float pressDepth = 0.015f;
    [SerializeField] private float pressSpeed = 20f;

    public string OnInteractMsg => onInteractMsg;

    Renderer _rend;
    Color _baseColor;
    Vector3 _baseLocalPos;
    bool _lockedDown;

    void Awake()
    {
        _rend = GetComponent<Renderer>();
        _baseColor = _rend.material.color;
        _baseLocalPos = transform.localPosition;
        _lockedDown = false;
    }

    // === llamado por PlayerInteractor ===
    public void OnInteract()
    {
        if (puzzleManager == null) return;

        // Disparo la secuencia; me dir� si soy el bot�n correcto
        bool stayDown = puzzleManager.OnButtonPressedSequence(id, this);
        StartCoroutine(AnimatePress(stayDown));
    }

    //public void SetColor(Color c) => _rend.material.color = c;
    //public void ResetColor() => _rend.material.color = _baseColor;

    public void ResetPosition()
    {
        _lockedDown = false;
        transform.localPosition = _baseLocalPos;
    }

    IEnumerator AnimatePress(bool lockDown)
    {

        Vector3 target = _baseLocalPos - Vector3.up * pressDepth;
        while (Vector3.Distance(transform.localPosition, target) > 0.001f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, target, pressSpeed * Time.deltaTime);
            yield return null;
        }

        _lockedDown = lockDown;
        if (!_lockedDown)
        {
            while (Vector3.Distance(transform.localPosition, _baseLocalPos) > 0.001f)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, _baseLocalPos, pressSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
}
