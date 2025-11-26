using UnityEngine;

public class AlarmLightRotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 135, 0) * Time.deltaTime);
    }
}
