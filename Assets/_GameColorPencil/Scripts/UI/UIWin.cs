using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWin : UICanvas
{
    public CanvasGroup canvasGroup;
    public void OpenUIWin()
    {
        canvasGroup.DOFade(1f, 0.5f);
    }

    public void NextLevel()
    {
        CloseUIWin();
        UIManager.instance.GetUI<UIGamePlay>().CloseUIGamePlay(true);

    }
    public void CloseUIWin()
    {
        canvasGroup.DOFade(0, 0.5f).OnComplete(() =>
        {
            UIManager.instance.CloseUI<UIWin>();
        });
    }
}
