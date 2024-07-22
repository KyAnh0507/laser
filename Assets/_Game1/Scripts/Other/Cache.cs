using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Cache
{

    private static Dictionary<Collider2D, Blank> blanks = new Dictionary<Collider2D, Blank>();

    public static Blank GetBlank(Collider2D collider2D)
    {
        if (!blanks.ContainsKey(collider2D))
        {
            blanks.Add(collider2D, collider2D.GetComponent<Blank>());
        }

        return blanks[collider2D];
    }

    private static Dictionary<Collider2D, BoxPencil> boxPencils = new Dictionary<Collider2D, BoxPencil>();

    public static BoxPencil GetBoxPencil(Collider2D collider2D)
    {
        if (!boxPencils.ContainsKey(collider2D))
        {
            boxPencils.Add(collider2D, collider2D.GetComponent<BoxPencil>());
        }

        return boxPencils[collider2D];
    }
    
    private static Dictionary<Collider2D, Pencil> pencils = new Dictionary<Collider2D, Pencil>();

    public static Pencil GetPencil(Collider2D collider2D)
    {
        if (!pencils.ContainsKey(collider2D))
        {
            pencils.Add(collider2D, collider2D.GetComponent<Pencil>());
        }

        return pencils[collider2D];
    }
}
