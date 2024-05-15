using UnityEngine;
using UnityEngine.Rendering;

public class CameraController : MonoBehaviour
{
    public Transform target;

    private Vector3 offset;
    private GameObject lastObstruction;

    public bool inCutscene = false;

    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!inCutscene)
        {
            transform.position = target.position - offset;
        }
    }
    
}