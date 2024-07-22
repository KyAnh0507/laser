using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class LevelManagerColorPencil : SingletonMonoBehaviour<LevelManagerColorPencil>
{
    public List<LevelColorPencil> levels;
    public ColorDatas colorDatas;

    internal LevelColorPencil currentLevel;
    private int indexLevel;

    public bool isNextLevel;
    private void Start()
    {
        
    }

    // Tải level
    public void LoadLevel()
    {
        if (currentLevel != null)
        {
            currentLevel.Despawn();
            Destroy(currentLevel.gameObject);
        }

        currentLevel = Instantiate(levels[DataManager.instance.dataSaved.indexLevelColorPencil]);
        currentLevel.OnInit();

        GamePlayColorPencil.instance.canPlay = true;
    }

    

    private void Update()
    {
        
    }

    public void Victory()
    {
        GamePlayColorPencil.instance.canPlay = false;

        DataManager.instance.dataSaved.indexLevelColorPencil = ++DataManager.instance.dataSaved.indexLevelColorPencil % levels.Count;

        DOVirtual.DelayedCall(1f, () =>
        {
            UIManager.instance.OpenUI<UIWin>().OpenUIWin();
        });
    }

    public void Defeat()
    {
        GamePlayColorPencil.instance.canPlay = false;
    }

    public int MaxNPencil()
    {
        if (currentLevel != null)
        {
            int m = currentLevel.rowPencils.Max(a => a.numberBox);
            return m;
        }
        return 1;
    }
}
