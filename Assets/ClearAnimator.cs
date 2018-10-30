using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearAnimator : MonoBehaviour
{
    public Animator anim;
    private GameObject shape;
    //private float angle;

    // Use this for initialization
    void Start()
    {
        shape = gameObject.transform.GetChild(0).gameObject;
        //angle = shape.transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            anim.Play("clearRight");
        }
        // shape follows transparency of animator
        shape.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<SpriteRenderer>().color;
    }

    public void PlayClearAnimation(float angle)
    {
        StartCoroutine(Animate(angle));
    }

    IEnumerator Animate(float angle)
    {
        if (angle > 0)
        {
            anim.Play("clearLeft");
        }
        else
        {
            anim.Play("clearRight");
        }
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        Destroy(shape);
    }
}
