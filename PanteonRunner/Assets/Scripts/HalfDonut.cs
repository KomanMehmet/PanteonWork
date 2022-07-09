using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonut : MonoBehaviour
{
    Animator _animator;
    float duration = 2f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Animation_State(string state)
    {
        if (state == "true")
        {
            _animator.SetBool("Rotate", true);
        }
        else
        {
            _animator.SetBool("Rotate", false);
        }

        StartCoroutine(Animation_Trigger(duration));
    }


    IEnumerator Animation_Trigger(float coolDown)
    {
        yield return new WaitForSeconds(coolDown);
        Animation_State("true");
    }



}
