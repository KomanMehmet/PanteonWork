using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWall : MonoBehaviour
{


    Coroutine drawing;
    public GameObject brush;
    public Camera endCamera;



    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Start_Line();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Finish_Line();
        }
    }

    private void Start_Line()
    {
        if (drawing != null)
        {
            StopCoroutine(drawing);
        }

        drawing = StartCoroutine(DrawLine());
    }

    private void Finish_Line()
    {

        StopCoroutine(drawing);
    }

    IEnumerator DrawLine()
    {
        GameObject newGameObject = Instantiate(brush, new Vector3(0, 1.26f, 11.63f), Quaternion.identity);
        LineRenderer line = newGameObject.GetComponent<LineRenderer>();
        line.positionCount = 0;



        while (true)
        {
            Vector3 position = endCamera.ScreenToWorldPoint(Input.mousePosition);

            position.z = 0;
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, position);

            yield return null;
        }
    }


}
