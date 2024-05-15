using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Bye());
    }

    private IEnumerator Bye()
    {
        yield return new WaitForSeconds(2f);
        Application.Quit(); 
    }

}
