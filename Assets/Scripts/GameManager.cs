using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform baseTransform;
    public GameObject ball;

    [SerializeField] Canvas canvas;

    private void OnEnable()
    {
        EndTrigger.onEndTrigger += StartEnd;
    }

    private void OnDisable()
    {
        EndTrigger.onEndTrigger -= StartEnd;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    
    void StartEnd()
    {
        if (canvas != null)
        {
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(8f);
        canvas.GetComponent<Animator>().SetTrigger("Fade");
        StartCoroutine(End());
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Quit");
        Application.Quit();
    }
}
