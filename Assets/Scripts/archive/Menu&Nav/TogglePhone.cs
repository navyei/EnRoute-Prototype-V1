using UnityEngine;

public class TogglePhone : MonoBehaviour
{
    public Animator Animator;

    public void ToggleInput()
    {
        Animator.SetBool("PhoneToggled", !Animator.GetBool("PhoneToggled"));
    }
}
