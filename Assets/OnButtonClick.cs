using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonClick : MonoBehaviour
{
    public GameObject moveImg;
    // Start is called before the first frame update

    public void OnClickDeletePoint()
    {
        PointMovement pointMovement = moveImg.GetComponent<PointMovement>();
        pointMovement.target.Clear();
        foreach(var a in pointMovement.points)
        {
            Destroy(a);
        }
        pointMovement.points.Clear();
    }

}
