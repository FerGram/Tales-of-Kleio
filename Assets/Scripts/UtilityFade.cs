using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UtilityFade
{
     public static IEnumerator FadeIn(SpriteRenderer yourSpriteRenderer)
     {
         float alphaVal = yourSpriteRenderer.color.a;
         Color tmp = yourSpriteRenderer.color;
 
         while (yourSpriteRenderer.color.a > 0)
         {
             alphaVal -= 0.01f;
             tmp.a = alphaVal;
             yourSpriteRenderer.color = tmp;
 
             yield return new WaitForSeconds(0.05f); // update interval
         }
     }
 
     public static IEnumerator FadeOut(SpriteRenderer yourSpriteRenderer)
     {
         float alphaVal = yourSpriteRenderer.color.a;
         Color tmp = yourSpriteRenderer.color;
 
         while (yourSpriteRenderer.color.a < 1)
         {
             alphaVal += 0.01f;
             tmp.a = alphaVal;
             yourSpriteRenderer.color = tmp;
 
             yield return new WaitForSeconds(0.05f); // update interval
         }
     }
}
