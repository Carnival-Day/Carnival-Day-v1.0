using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopScript : MonoBehaviour
{
    public BalloonManager balloonManager;  // Ensure this is set in the Unity inspector

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Check if the left mouse button was clicked
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;  // Since it's 2D, set z to 0 to avoid unnecessary depth issues
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                BalloonBehavior balloon = hit.collider.GetComponent<BalloonBehavior>();
                if (balloon != null)
                {
                    balloonManager.adjustScore(balloon.points);  // Adjust score based on balloon's points
                    Destroy(hit.collider.gameObject);  // Destroy the balloon
                }
            }
        }
    }
}

