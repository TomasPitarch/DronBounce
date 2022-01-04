using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateComponent : MonoBehaviour
{
    [SerializeField]
    Vector3 RotationSpeed;

    RectTransform rectTransform;
    private void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
       
    }
    // Update is called once per frame
    void Update()
    {
        if (rectTransform == null)
        {
            print("null");
        }
        else
        {
            //rectTransform.rotation = Quaternion.Euler((rectTransform.rotation.eulerAngles + RotationSpeed) * Time.deltaTime);

        }
        transform.rotation = Quaternion.Euler((transform.rotation.eulerAngles) + (RotationSpeed * Time.deltaTime));


    }
}
