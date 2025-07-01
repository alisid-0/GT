using UnityEngine;

public class PlayerStatsManager : CharacterStatsManager
{

    PlayerManager player;

    protected override void Awake()
    {
        base.Awake();

        player = GetComponent<PlayerManager>();
    }

    protected override void Start()
    {
        base.Start();

        // WHY CALCULATE THSE HERE?
        // WHEN WE MAKE THE CHARACTER CREATION MENU AND SET THE STATS DEPENDING ON THE CLASS THIS WILL BE CALCULATED THERE
        // UNTIL THEN HOWEVER, STATS ARE NEVER CALCULACTED SO WE DO IT HERE ON START IF A SAVE FILE EXISTS THEY WILL BE OVER WRITTEN WHEN LOADING IN TO A SECNE
        CalculateHealthBasedOnVitalityLevel(player.playerNetworkManager.vitality.Value);
        CalculateStaminaBasedOnEnduranceLevel(player.playerNetworkManager.endurance.Value);
    }

}
