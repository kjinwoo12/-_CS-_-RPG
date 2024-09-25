public class LongSword : IEquipableItem
{
    public CharacterStats additionalStats
    {
        get
        {
            if(GameManager.instance.playerCharacter.equipmentComponent.equipSlot.TryGetValue("장신구", out IEquipableItem Accessory))
            {
                if(Accessory is SmartPhone)
                {
                    return new CharacterStats(0, 10, 10, 0, 0);
                }
            }
            return new CharacterStats(0, 4, 4, 0, 0);
        }
    }

    public string name => "롱소드";

    public string description
    {
        get
        {
            if (GameManager.instance.playerCharacter.equipmentComponent.equipSlot.TryGetValue("장신구", out IEquipableItem Accessory))
            {
                if (Accessory is SmartPhone)
                {
                    return "공격력(+10, +10) | 김상윤 유튜브 구독 좋아요 알림설정";
                }
            }
            return "공격력(+4, +4) | 유튜브로 검술을 익혀야 진정한 힘을 끌어낼 수 있다.";
        }
    }

    public string slotName => "무기";
}