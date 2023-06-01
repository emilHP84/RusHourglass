using UnityEngine;

public class Manager : MonoBehaviour
{
    public InventoryPlayer _InventoryPlayer;
    void Start() {
        _InventoryPlayer.pointNumber = 0;
        QualitySettings.vSyncCount = 0;
    }

    private void Update() {
        if (_InventoryPlayer.pointNumber > _InventoryPlayer.PointsNumberReccord) {
            _InventoryPlayer.PointsNumberReccord = _InventoryPlayer.pointNumber;
        }
    }
}
