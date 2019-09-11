﻿// Just add this script to your camera. It doesn't need any configuration.

using UnityEngine;
using UnityEngine.EventSystems;

public class TouchCamera : MonoBehaviour
{

    public float maxCamMagnitude, minCamMagnitude, zoomSpeed = 0.005f;
    public Vector2 maxPoint, minPoint;

    Vector2?[] oldTouchPositions = { null, null };
    Vector2 oldTouchVector;
    Vector3 tempVec2;
    
    float oldTouchDistance;
    float temp;



    void FixedUpdate()
    {

        if (Input.touchCount == 0)
        {
            oldTouchPositions[0] = null;
            oldTouchPositions[1] = null;
        }
        else if (Input.touchCount == 1 && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            if (oldTouchPositions[0] == null || oldTouchPositions[1] != null)
            {
                oldTouchPositions[0] = Input.GetTouch(0).position;
                oldTouchPositions[1] = null;
            }
            else
            {
                Vector2 newTouchPosition = Input.GetTouch(0).position;

                tempVec2 = transform.position + transform.TransformDirection((Vector3)((oldTouchPositions[0] - newTouchPosition) * GetComponent<Camera>().orthographicSize / GetComponent<Camera>().pixelHeight * 2f));


                if(tempVec2.x > maxPoint.x)
                {
                    tempVec2.x = maxPoint.x;
                }
                else if(tempVec2.x < minPoint.x)
                {
                    tempVec2.x = minPoint.x;
                }

                if (tempVec2.y > maxPoint.y)
                {
                    tempVec2.y = maxPoint.y;
                }
                else if (tempVec2.y < minPoint.y)
                {
                    tempVec2.y = minPoint.y;
                }
                Debug.Log(tempVec2);

                transform.position  = tempVec2;

                oldTouchPositions[0] = newTouchPosition;
            }
        }
        else if (Input.touchCount == 2)
        {
            if (oldTouchPositions[1] == null)
            {
                oldTouchPositions[0] = Input.GetTouch(0).position;
                oldTouchPositions[1] = Input.GetTouch(1).position;
                oldTouchVector = (Vector2)(oldTouchPositions[0] - oldTouchPositions[1]);
                oldTouchDistance = oldTouchVector.magnitude;
            }
            else
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(1).fingerId))
                {
                    // Store both touches.
                    Touch touchZero = Input.GetTouch(0);
                    Touch touchOne = Input.GetTouch(1);

                    // Find the position in the previous frame of each touch.
                    Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                    Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                    // Find the magnitude of the vector (the distance) between the touches in each frame.
                    float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                    float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                    // Find the difference in the distances between each frame.
                    float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
                    //Debug.Log(GetComponent<Camera>().orthographicSize);

                    // ... change the orthographic size based on the change in distance between the touches.
                    temp = GetComponent<Camera>().orthographicSize + deltaMagnitudeDiff * zoomSpeed * Time.deltaTime;

                    if (temp > maxCamMagnitude)
                    {
                        temp = maxCamMagnitude;
                    }
                    else if (temp < minCamMagnitude)
                    {
                        temp = minCamMagnitude;
                    }

                    GetComponent<Camera>().orthographicSize = Mathf.Clamp(temp, minCamMagnitude, maxCamMagnitude);
                }
            }
        }

    }
}