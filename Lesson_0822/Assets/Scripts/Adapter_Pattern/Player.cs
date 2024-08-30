using UnityEngine;

public class Player : MonoBehaviour //player를 기준으로 인터페이스 (상호작용 할 수 있게 만들기)
{
    [SerializeField] GameObject target;
    [SerializeField] int hp;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            I_Interactable interactable = target.GetComponent<I_Interactable>();

            if(interactable != null )
            {
                PlayerInteract(interactable);
            }
        }
    }
    private void PlayerInteract(I_Interactable interactable)
    {
        interactable.TargetInteract(this);
    }

    public void Heal (int amount)
    {
        hp += amount;
        Debug.Log($"플레이어의 체력이 {amount}올라 {hp}되었습니다.");
    }

}
