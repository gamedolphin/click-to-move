using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomSpriter : MonoBehaviour
{
    [SerializeField]
    private Sprite[] spriteList;

    private void Awake()
    {
        UpdateSprite();

        StartCoroutine(TimedUpdate());
    }

    private IEnumerator TimedUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            UpdateSprite();
        }
    }

    [ContextMenu("Update Sprite")]
    private void UpdateSprite()
    {
        var sprite = spriteList[Random.Range(0, spriteList.Length)];
        var spr = GetComponent<SpriteRenderer>();
        spr.sprite = sprite;
    }
}
