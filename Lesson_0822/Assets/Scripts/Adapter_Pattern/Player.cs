using UnityEngine;

public class Player : MonoBehaviour //player�� �������� �������̽� (��ȣ�ۿ� �� �� �ְ� �����)
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
        Debug.Log($"�÷��̾��� ü���� {amount}�ö� {hp}�Ǿ����ϴ�.");
    }

}
