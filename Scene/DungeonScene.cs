using System.Collections.Generic;
using System.Threading;
using System;
using System.Xml.Linq;

public class DungeonScene : IScene
{
    private PlayerCharacter playerCharacter;
    private Monster monster;

    // 이벤트 델리게이트 정의
    public delegate void OnCharacterDeathEvent(Character character);
    public event OnCharacterDeathEvent OnCharacterDeathDelegate;

    public DungeonScene(Monster monster)
    {
        this.playerCharacter = GameManager.instance.playerCharacter;
        this.monster = monster;
        OnCharacterDeathDelegate += OnCharacterDeath;
    }

    public IScene GetNextScene()
    {
        return new DungeonSelectionScene();
    }

    public void OnShow()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"플레이어 정보: 이름({playerCharacter.name}), 체력({playerCharacter.health}/{playerCharacter.stats.maxHealth}), 공격력({playerCharacter.stats.minAttack} ~ {playerCharacter.stats.maxAttack}), 방어력({playerCharacter.stats.minArmor}~{playerCharacter.stats.maxArmor})");
            Console.WriteLine($"몬스터 정보: 이름({monster.name}), 체력({monster.health}/{monster.stats.maxHealth}), 공격력({monster.stats.minAttack} ~ {monster.stats.maxAttack}), 방어력({monster.stats.minArmor}~{monster.stats.maxArmor})");
            Console.WriteLine("----------------------------------------------------");
            Thread.Sleep(1000);
            DoTurn(playerCharacter, monster);
            if (monster.isDead)
            {
                OnCharacterDeathDelegate?.Invoke(monster);
                break;
            }

            DoTurn(monster, playerCharacter);
            if (playerCharacter.isDead)
            {
                OnCharacterDeathDelegate?.Invoke(playerCharacter);
                break;
            }
        }
    }

    void DoTurn(Character turnOwner, Character enemy)
    {
        Console.WriteLine($"{turnOwner.name}의 턴!");
        TakeDamageResult takeDamageResult = enemy.takeDamage(turnOwner.DoAttack(enemy));
        enemy.health -= takeDamageResult.actualDamage;
        Console.WriteLine($"{enemy.name}이(가) {takeDamageResult.defenseAmount}의 데미지를 막아냈습니다");
        Console.WriteLine($"{enemy.name}이(가) {takeDamageResult.actualDamage}의 데미지를 받았습니다");
        
        Console.WriteLine();
        Thread.Sleep(3000);
    }

    private void OnCharacterDeath(Character character)
    {
        if (character is Monster)
        {
            Console.WriteLine($"스테이지 클리어! {character.name}를 물리쳤습니다!");
            Thread.Sleep(500);

            Console.WriteLine($"{monster.rewardExp} EXP 를 획득했습니다.");
            Console.Write($"LV{playerCharacter.level} EXP({playerCharacter.currentExp} / {playerCharacter.maxExp})");
            playerCharacter.AddExp(monster.rewardExp);
            Console.WriteLine($"-> LV{playerCharacter.level} EXP({playerCharacter.currentExp} / {playerCharacter.maxExp})");
            Thread.Sleep(500);

            Console.WriteLine($"{monster.rewardGold} G 를 획득했습니다!");
            GameManager.instance.playerState.gold += monster.rewardGold;

            if (monster.rewardItems != null && 0 < monster.rewardItems.Count)
            {
                Console.WriteLine("아래의 보상 아이템 중 하나를 선택하여 사용할 수 있습니다:");
                foreach (var item in monster.rewardItems)
                {
                    Console.WriteLine(item.name);
                }

                Console.Write("획득할 아이템 이름을 입력하세요:");
                string input = Console.ReadLine();

                IItem selectedItem = monster.rewardItems.Find(item => item.name == input);
                if (selectedItem != null)
                {
                    GameManager.instance.playerState.inventory.Add(selectedItem);
                }
            }
        }
        else
        {
            Console.WriteLine("패배했습니다...");
            playerCharacter.health = 1;
        }
        Thread.Sleep(1500);
    }
}