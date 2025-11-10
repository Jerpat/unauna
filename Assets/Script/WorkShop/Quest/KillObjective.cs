using System;
using UnityEngine;

public class KillObjective : IQuest
{
    private readonly int _targetCount;
    private int _currentCount;
    private readonly string _enemyName;
    

    public event Action OnObjectiveCompleted;

    public KillObjective(string name, int target)
    {
        _enemyName = name;
        _targetCount = target;
        _currentCount = 0;
    }
    public bool IsTarget(string targetId)
    {
        return targetId == _enemyName; // เช็คว่าชื่อที่รายงานตรงกับชื่อที่ต้องการฆ่าหรือไม่
    }
    public bool IsComplete => _currentCount >= _targetCount;

    public string GetProgressText()
    {
        return $"Defeat {_enemyName}: {_currentCount}/{_targetCount}";
    }

    public void UpdateProgress(int amount)
    {
        if (IsComplete) return;

        _currentCount += amount;

        if (IsComplete)
        {
            // ยิง Event เมื่อเควสสำเร็จ
            OnObjectiveCompleted?.Invoke();
        }
    }
}
