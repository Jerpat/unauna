using UnityEngine;

public interface ITalkable
{

    bool isTalkable { get; set; }

    void Talk(Player _player);
}
