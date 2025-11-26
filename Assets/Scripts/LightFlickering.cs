using UnityEngine;

public class Flickering : MonoBehaviour
{
    public float timer = 0;
    public float pauseTimer = 0;
    public float flickeringTimer = 0;
    private bool isFlickering = false;
    public Light flickerLight;
    public GameObject objectOn;
    public GameObject objectOff;

    void Start()
    {
        NextFlick();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (!isFlickering && timer >= flickeringTimer)
        {
            objectOn.SetActive(true);
            objectOff.SetActive(false);
            flickerLight.enabled = true;
            isFlickering = true;
            timer = 0f;
        }
        
        if (isFlickering && timer >= 0.5f)
        {
            objectOn.SetActive(false);
            objectOff.SetActive(true);
            flickerLight.enabled = false;
            isFlickering = false;
            timer = 0f;
            NextFlick();
        }
    }

    void NextFlick()
    {
        flickeringTimer = UnityEngine.Random.Range(0f, 3f);
    }
}
