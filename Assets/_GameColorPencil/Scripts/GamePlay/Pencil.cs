using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Pencil : GameUnit
{
    public SpriteRenderer sprite;

    public int color;
    public void OnInit(int n)
    {
        sprite.sortingOrder = n;
    }

    public void Move(Vector3 pos1, Vector3 pos2, int layer1, int layer2)
    {
        TF.DOKill();
        GamePlayColorPencil.instance.canPlay = false;
        TF.DOMove(pos1 + GamePlayColorPencil.instance.movePosition, 0.2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            SetLayer(layer1);
            TF.DOMove(pos2 + GamePlayColorPencil.instance.movePosition, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                SetLayer(layer2);
                TF.DOMove(pos2, 0.2f).OnComplete(() =>
                {
                    GamePlayColorPencil.instance.canPlay = true;
                });
            });
        });
    }


    public void SelectPencil(Vector3 pos, float t)
    {
        GamePlayColorPencil.instance.canPlay = false;
        TF.DOMove(pos, t).OnComplete(() =>
        {
            GamePlayColorPencil.instance.canPlay = true;
        });
    }

    public void SetLayer(int n)
    {
        sprite.sortingOrder = n;
    }

    public void SetColor(ColorType colorType)
    {
        sprite.color = LevelManagerColorPencil.instance.colorDatas.GetColor(colorType);
        color = (int)colorType;
    }
}
