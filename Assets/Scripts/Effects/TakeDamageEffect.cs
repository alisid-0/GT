using UnityEngine;


[CreateAssetMenu(menuName = "Character Effects/Instant Effects/Take Damage")]
public class TakeDamageEffect : InstantCharacterEffect
{

    [Header("Character Causing Damage")]
    public CharacterManager characterCausingDamage; //if damage is caused by another character, we will store that character here

    [Header("Damage")]
    public float physicalDamage = 0; //IN THE FUTURE WILL BE SPLIT INTO STANDARD STRIKE SLASH AND PIERCE
    public float magicDamage = 0;
    public float fireDamage = 0;
    public float lightningDamage = 0;
    public float holyDamage = 0;

    [Header("Final Damage")]
    private int finalDamageDealt = 0; //the damage the charcter takes after ALL calculations have been made

    [Header("Poise")]
    public float poiseDamage = 0;
    public bool poiseIsBroken = false; // If a character's poise is broken, they will be stunned and play a damage animation

    // (TO DO) BUILD UPS

    [Header("Animation")]
    public bool playDamageAnimation = true;
    public bool manuallySelectDamageAnimation = false;
    public string damageAnimation;

    [Header("Sound FX")]
    public bool willPlayDamageSFX = true;
    public AudioClip elementalDamageSoundFX; // USED ON TOP OF REGULAR SFX IF THERE IS ELEMENTAL DAMAGE PRESENT

    [Header("Direction Damage Taken From")]
    public float angleHitFrom; // USED TO DETERMINE WHAT DAMAGE ANIMATION TO PLAY DEPENDING ON WHERE YOU WERE HIT
    public Vector3 contactPoint; // USED TO DETERMINE WHERE THE BLOOD FX INSTANTIATES


    public override void ProcessEffect(CharacterManager character)
    {
        base.ProcessEffect(character);

        // IF THE CHARACTER IS DEAD NO ADDITIONAL DAMAGE EFFECTS SHOULD BE PROCESSED 
        if (character.isDead.Value)
        {
            return;
        }

        // CHECK FOR INVULNERABILITY 

        CalculateDamage(character);
        // CHECK WHICH DIRECTION DAMAGE CAME FROM
        // PLAY A DAMAGE ANIMATION
        // CHECK FOR BUILDUPS
        // PLAY DAMAGE SOUND FX
        // PLAY DAMAGE VFX

        // IF CHARACTER IS AI, CHECK FOR NEW TARGET IF CHARACTER CAUSING DAMAGE IS PRESENT
    }

    private void CalculateDamage(CharacterManager character)
    {

        if (!character.IsOwner) return;

        if (characterCausingDamage != null)
        {
            // CHECK FOR DAMAGE MODIFIERS AND MODIFY BASE DAMAGE (PHYSICAL DAMAGE BUFF, ELEMENTAL DAMAGE BUFF ETC)

        }

        // CHECK CHARACTER FOR FLAT DAMAGE REDUCTION AND SUBTRACT THEM FROM THE DAMAGE

        // CHECK CHARACTER FOR ARMOR ABSORPTIONS, AND SUBTRACT THE PERCENTAGE FROM THE DAMAGE

        // ADD ALL DAMAGE TYPES TOGETHR AND APPLY FINAL DAMAGE
        finalDamageDealt = Mathf.RoundToInt(physicalDamage + magicDamage + fireDamage + lightningDamage + holyDamage);

        if (finalDamageDealt <= 0)
        {
            finalDamageDealt = 1;
        }

        character.characterNetworkManager.currentHealth.Value -= finalDamageDealt;

        // CALCULATE POISE DAMAGE TO DETERMINE IF THE CHARACTER PLAYS A DAMAGE ANIMATION
    }

}
