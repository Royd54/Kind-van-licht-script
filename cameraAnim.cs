using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraAnim : MonoBehaviour
{
    public Transform[] views;
    public float transitionSpeed;
    public Transform currentView;

    void Update()
    {
        //debugs
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentView = views[0];
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentView = views[1];
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentView = views[2];
        }

    }


    void LateUpdate()
    {
        //Lerp position
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);

        Vector3 currentAngle = new Vector3(
         Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
         Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
         Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));

        transform.eulerAngles = currentAngle;

    }

    //these fucntions set the current view to lerp to
    public void focusPlayer()
    {
        currentView = views[0];
    }

    public void focusAttack()
    {
        currentView = views[1];
    }

    public void focusRestore()
    {
        currentView = views[2];
    }

    public void focusXpEarned()
    {
        currentView = views[3];
    }
}