using DG.Tweening;
using UnityEngine;

public class StructureKiller : MonoBehaviour
{
    private GameObject Player;
    [SerializeField]private RectTransform UI;
    
    public void Start() {
        Player = GameObject.Find("Player");
        UI = GameObject.Find("PanelMort").GetComponent<RectTransform>();
    }

    public void OnTriggerEnter(Collider other) {
        if (other.name == "Player") {
            Player.SetActive(false);
            UI.DOAnchorPos(new Vector2(0, 0), 0.2f, false);
        }
    }
}
