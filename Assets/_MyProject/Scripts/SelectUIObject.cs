using UnityEngine;
using UnityEngine.UI;


public class SelectUIObject : MonoBehaviour
{
    public Button FirstSelected;

    private void OnEnable()
    {
        FirstSelected.Select();
    }

}
