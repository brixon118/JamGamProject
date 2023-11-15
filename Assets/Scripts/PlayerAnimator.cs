using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Sprite idleFrontSprite;
    [SerializeField] private Sprite idleBackSprite;
    [SerializeField] private Sprite idleSideSprite;
    [SerializeField] private Sprite[] walkFrontSprites;
    [SerializeField] private Sprite[] walkBackSprites;
    [SerializeField] private Sprite[] walkSideSprites;

    [SerializeField] private float animationSpeed;

    [SerializeField] private SpriteRenderer normalSR;
    [SerializeField] private SpriteRenderer reverseSR;

    private SpriteRenderer sr;
    private int animation;
    private Sprite[] sprites;
    private int spriteIndex;
    private float animationTime;

    // Start is called before the first frame update
    void Start()
    {
        reverseSR.gameObject.SetActive(false);
        sr = normalSR;
        sprites = walkFrontSprites;
        animation = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (animation < 0) return;
        animationTime += Time.deltaTime;
        if (animationTime >= 1f / animationSpeed)
        {
            animationTime = 0;
            spriteIndex = (spriteIndex + 1) % sprites.Length;
            sr.sprite = sprites[spriteIndex];
        }
    }

    public void SetAnimation(int a)
    {
        if (animation != a)
        {
            if (a < 0) sr.sprite = animation == 0 ? idleFrontSprite : animation == 1 ? idleBackSprite : idleSideSprite;
            else
            {
                if (a == 3)
                {
                    normalSR.gameObject.SetActive(false);
                    reverseSR.gameObject.SetActive(true);
                    sr = reverseSR;
                }
                else
                {
                    normalSR.gameObject.SetActive(true);
                    reverseSR.gameObject.SetActive(false);
                    sr = normalSR;
                }
                sprites = a == 0 ? walkFrontSprites : a == 1 ? walkBackSprites : walkSideSprites;
                sr.sprite = sprites[0];
                spriteIndex = 0;
            }
            animation = a;
        }
    }
}
