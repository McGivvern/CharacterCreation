using UnityEngine;
using UnityEngine.UI;
public class NameHolder : MonoBehaviour
{
    public string characterName = "";

    public void SetName()
    {
        var holder = GameObject.Find("NameText").GetComponent<Text>().text;
        characterName = holder;
    }
}
