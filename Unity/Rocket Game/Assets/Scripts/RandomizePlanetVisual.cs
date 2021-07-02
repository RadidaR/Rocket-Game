using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class RandomizePlanetVisual : MonoBehaviour
{
    public ColorLibrary colors;

    public SpriteResolver spriteResolverA;
    public SpriteResolver spriteResolverB;

    private void Awake()
    {
        int random = Random.Range(1, 9);

        spriteResolverA.SetCategoryAndLabel("Part A", $"Planet {random} A");
        spriteResolverB.SetCategoryAndLabel("Part B", $"Planet {random} B");

        int randomColor1 = Random.Range(0, colors.planetColors1.Length);
        int randomColor2 = Random.Range(0, colors.planetColors2.Length);

        spriteResolverA.gameObject.GetComponent<SpriteRenderer>().color = colors.planetColors1[randomColor1];
        spriteResolverB.gameObject.GetComponent<SpriteRenderer>().color = colors.planetColors2[randomColor2];
    }
}
