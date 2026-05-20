using UnityEngine;

public class ClickTest : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey)
        {
            Debug.Log("ANY INPUT DETECTED");
        }
    }
}