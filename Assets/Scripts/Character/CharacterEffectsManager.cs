using UnityEngine;

public class CharacterEffectsManager : MonoBehaviour
{

    // PROCESS INSTANT EFFECTS (TAKE DAMAGE, HEAL)

    // PROCESS TIMED EFFECTS (POISON, BUILDUPS)

    // PROCESS STATIC EFFECTS (ADDING OR REMOVING BUFFS FROM TALISMANS ETC)

    CharacterManager character;

    protected virtual void Awake()
    {
        character = GetComponent<CharacterManager>();
    }

    public virtual void ProcessInstantEffect(InstantCharacterEffect effect)
    {
        effect.ProcessEffect(character);
    }

}
