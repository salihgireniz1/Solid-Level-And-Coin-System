using UnityEngine;

public class KeyboardInputHandler : MonoBehaviour, IHandleInput
{
    const string HORIZONTAL = "Horizontal";
    const string VERTICAL = "Vertical";
    public Vector3 GiveInput()
    {
        Vector3 input = new Vector3(
            Input.GetAxis(HORIZONTAL), 
            0f, 
            Input.GetAxis(VERTICAL)
            );

        return input;
    }
}
