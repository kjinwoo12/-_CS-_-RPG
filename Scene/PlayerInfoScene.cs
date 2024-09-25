using System;
public class PlayerInfoScene : IScene
{
    public void OnShow()
    {
        PlayerCharacter playerCharacter = GameManager.instance.playerCharacter;
        PlayerState playerState = GameManager.instance.playerState;
        Console.WriteLine("상태 보기");
        Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
        Console.WriteLine($"LV. {playerCharacter.level}");
        Console.WriteLine($"EXP. {playerCharacter.currentExp} / {playerCharacter.maxExp}");
        Console.WriteLine($"Name : {playerCharacter.name}");
        Console.WriteLine($"Job : {playerCharacter.jobName}");
        Console.WriteLine($"Attack : {playerCharacter.stats.minAttack} ~ {playerCharacter.stats.maxAttack}");
        Console.WriteLine($"Armor : {playerCharacter.stats.minArmor} ~ {playerCharacter.stats.maxArmor}");
        Console.WriteLine($"Health : {playerCharacter.health}/{playerCharacter.stats.maxHealth}");
        Console.WriteLine($"Gold : {playerState.gold} G");
        Console.WriteLine("\n[아무키]를 눌러 돌아가기");
        Console.ReadKey(true);
    }

    public IScene GetNextScene()
    {
        return new SpartaTownScene();
    }
}