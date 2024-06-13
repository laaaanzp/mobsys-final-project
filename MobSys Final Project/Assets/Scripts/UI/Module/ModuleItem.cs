using UnityEngine;

[CreateAssetMenu]
public class ModuleItem : ScriptableObject
{
    public Sprite[] sprites;
    [TextArea(minLines: 10, maxLines: 30)] public string description;
}
