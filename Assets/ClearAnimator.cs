using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearAnimator : MonoBehaviour
{
    public Animator anim;
    private GameObject shape;

    // Use this for initialization
    void Start()
    {
        shape = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            anim.Play("clearRight");
        }
        // shape follows transparency of animator
        shape.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
    }

    public void PlayClearAnimation(float angle)
    {
        StartCoroutine(ClearCoroutine(angle));
    }

    IEnumerator ClearCoroutine(float angle)
    {
        if (SoundController.instance != null)
        {

            SoundController.instance.Play("hit");
        }
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
