using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomSpriter : MonoBehaviour
{
    [SerializeField]
    private Sprite[] spriteList;

    private void Awake()
    {
        UpdateSprite();
    }

    [ContextMenu("Update Sprite")]
    private void UpdateSprite()
    {
        var sprite = spriteList[Random.Range(0, spriteList.Length)];
        var spr = GetComponent<SpriteRenderer>();
        spr.sprite = sprite;
    }
}
