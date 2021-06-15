using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RecognizeMove : MonoBehaviour
{
    public XRNode inputSource;
    public InputHelpers.Button inputButton;
    public float inputThreshold = 0.1f;
    public Transform movementSource;
    public AudioSource audioSource;

    public float newPositionThresholdDistance = 0.05f;
    public GameObject debugCubePrefab;

    private bool isMoving = false;
    private List<Vector3> positionsList = new List<Vector3>();

    // Update is called once per frame
    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, inputThreshold);

        //Start movement
        if(!isMoving && isPressed)
        {
            StartMovement();
        }
        //End movement
        else if(isMoving && !isPressed)
        {
            EndMovement();
        }
        //Update movement
        else if(isMoving && isPressed)
        {
            UpdateMovement();
        }
    }

    void StartMovement()
    {
        Debug.Log("Start Movement");
        isMoving = true;
        positionsList.Clear();
        positionsList.Add(movementSource.position);
        Instantiate(debugCubePrefab, movementSource.position, Quaternion.identity);
        audioSource.Play();
    }

    void EndMovement()
    {
        Debug.Log("End Movement");
        isMoving = false;
    }

    void UpdateMovement()
    {
        Debug.Log("Update Movement");
        Vector3 lastPosition = positionsList[positionsList.Count - 1];

        if (Vector3.Distance(movementSource.position, lastPosition) > newPositionThresholdDistance)
        {
            positionsList.Add(movementSource.position);
            Destroy(Instantiate(debugCubePrefab, movementSource.position, Quaternion.identity), 7);
            audioSource.Play();
        }
    }
}
