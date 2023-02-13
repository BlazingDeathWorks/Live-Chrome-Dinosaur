using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] public float scrollSpeed;
    [SerializeField] public float offset;
    [SerializeField] public Transform ground;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(scrollSpeed * Time.deltaTime, 0, 0);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            transform.position = new Vector3(ground.transform.position.x + offset, ground.transform.position.y, ground.transform.position.z);
        }
    }
}