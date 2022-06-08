using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Dodge", fileName = "Effect_Dodge")]
public class Effect_Dodge : BaseEffect
{
    private float dodgeSpeedIncrease = 2.5f;
    public override bool Effect_IsDodging(bool originalDodging)
    {
        return true;
    }
    public override void OnEffectStart()
    {
        GameHandler.instance.player.GetComponent<BoxCollider2D>().enabled = false;
        GameHandler.instance.player.GetComponent<SpriteRenderer>().color = new Color(1,1,1,.35f);
        GameHandler.instance.player.GetComponent<PlayerMovement>().moveSpeed = GameHandler.instance.player.GetComponent<PlayerMovement>().moveSpeed + dodgeSpeedIncrease;
    }
    public override void OnEffectEnd()
    {
        GameHandler.instance.player.GetComponent<BoxCollider2D>().enabled = true;
        GameHandler.instance.player.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        GameHandler.instance.player.GetComponent<PlayerMovement>().moveSpeed = GameHandler.instance.player.GetComponent<PlayerMovement>().moveSpeed - dodgeSpeedIncrease;

    }
}