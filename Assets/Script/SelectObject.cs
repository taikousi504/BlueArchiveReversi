using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    GameObject clickedGameObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                clickedGameObject = hit.collider.gameObject;
            }

            if (clickedGameObject.CompareTag("Hex"))
            {
                var hex = clickedGameObject.GetComponent<Hex>();
                Debug.Log("Hex(" + hex.InGamePos.x + ", " + hex.InGamePos.y + ")");

                hex.SetSchool(GameManager.Instance.NowTurnSchool);
                GameManager.Instance.NextTurn();
            }
        }
    }
}
