using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject slider;
    public GameObject point;

    public List<Vector3> target;
    public List<GameObject> points;

    private void Start()
    {
        var anArray = PlayerPrefsX.GetVector3Array("VectorsArray");
        target.AddRange(anArray);
        foreach (var vector in target)
        {
            points.Add(Instantiate(point, vector, Quaternion.identity));
        }
        gameObject.transform.position = PlayerPrefsX.GetVector3("position", transform.position);
    }
    void Update()
    {
        if(target.Count != 0)
        { //moving image
            float step = slider.GetComponent<Slider>().value * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target[0], step);
            if (transform.position == target[0])
            {
                target.RemoveAt(0);
                Destroy(points[0]);
                points.RemoveAt(0);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        { //mouse point to list
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y <= 4.1f)
            {
                var a = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.Add(new Vector3(a.x, a.y, 0f));
                points.Add(Instantiate(point, target[target.Count - 1], Quaternion.identity));
            }
        }
    }

    private void OnApplicationQuit()
    { //save date
        PlayerPrefsX.SetVector3("position", transform.position);
        Vector3[] anArray  = target.ToArray();
        PlayerPrefsX.SetVector3Array("VectorsArray", anArray);
    }
    
}

        

