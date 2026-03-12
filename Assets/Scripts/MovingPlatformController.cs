using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    public float speed = 2f;
    public Transform[] points;

    private int i;
    void Start()
    {
        transform.position = points[0].position;//position will be set to the first point in the array
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, points[i].position) < 0.1f)
        {
            i++;
            if(i == points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collison)
    {
        if(collison.gameObject.tag == "Player")
        {
            collison.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collison)
    {
        if (collison.gameObject.tag == "Player")
        {
            collison.gameObject.transform.SetParent(null);
        }
    }
}
