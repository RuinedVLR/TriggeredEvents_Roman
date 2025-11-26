using UnityEngine;
using UnityEngine.Playables;

public class TriggerScript : MonoBehaviour
{
    [SerializeField] private PlayableDirector timeline;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timeline.Play();
        }
    }
}
