using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Remoting.Channels;
using UnityEngine;

public class Stacker : MonoBehaviour
{
    public GameObject[] shapes;
    private Stack stack;
    private string topShape;


    private void Awake()
    {
        stack = new Stack();
    }
    // Use this for initialization
    void Start()
    {
        stack.Push(gameObject);
        topShape = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("o"))
        {
            StackShape("Triangle");
        }
        if (Input.GetKeyDown("p"))
        {
            PopShape();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(topShape))
        {
            PopShape();
        }
        else
        {
            StackShape(other.tag);
        }
    }

    public int GetStackCount()
    {
        return stack.Count;
    }

    public void StackShape(string tag)
    {
        GameObject newShape;

        foreach (GameObject shape in shapes)
        {
            if (shape.CompareTag(tag))
            {
                newShape = Instantiate(shape, transform.position, transform.rotation);
                newShape.transform.Translate(Vector3.up * transform.localScale.y * stack.Count);
                newShape.transform.SetParent(gameObject.transform);
                stack.Push(newShape);

                topShape = tag;
                UpdateCollider();
            }
        }
    }

    public void PopShape()
    {
        GameController.instance.AddNumShapesCleared();

        // do not pop if only root is left
        if (stack.Count > 1)
        {
            GameObject toPop = (GameObject)stack.Pop();
            Destroy(toPop);

            topShape = ((GameObject)stack.Peek()).tag;
            UpdateCollider();
        }
    }

    private void UpdateCollider()
    {
        GetComponent<BoxCollider2D>().size = new Vector2(1, stack.Count);
        GetComponent<BoxCollider2D>().offset = new Vector2(0, 0.5f * (stack.Count - 1));
    }
}
