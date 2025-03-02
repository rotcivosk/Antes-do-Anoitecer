using UnityEngine;
public class buttonsActions : MonoBehaviour
{
    [SerializeField] ActionsHandler actionsHandler;
    public void actionDefense() {
        actionsHandler.ImproveDefense(GameManager.Instance.GetSelectedPlace(), GameManager.Instance.GetSelectedPlayer());
    }
    public void actionLoot() {
        actionsHandler.StartLooting(GameManager.Instance.GetSelectedPlace(), GameManager.Instance.GetSelectedPlayer());
    }
    public void actionDanger() {
        actionsHandler.ClearDanger(GameManager.Instance.GetSelectedPlace(), GameManager.Instance.GetSelectedPlayer());
    }
    public void actionMove() {
        actionsHandler.MovePlayer(GameManager.Instance.GetSelectedPlace(), GameManager.Instance.GetSelectedPlayer());
    }
    public void actionRelax() {
        actionsHandler.RelaxInPlace(GameManager.Instance.GetSelectedPlace(), GameManager.Instance.GetSelectedPlayer());
    }
    public void actionObserve() {
        actionsHandler.ObservePlace(GameManager.Instance.GetSelectedPlace(), GameManager.Instance.GetSelectedPlayer());
    }
}
