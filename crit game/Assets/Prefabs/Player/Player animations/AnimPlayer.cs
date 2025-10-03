using UnityEngine;

public class AnimPlayer : MonoBehaviour
{
    private Animator animatorController;
    private void Start()
    {
        animatorController = GetComponent<Animator>();
    }


}