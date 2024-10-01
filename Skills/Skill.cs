using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


// 스킬을 관리하는 클래스
public class Skill
{
    public string skillName { get; set; }
    public string skillDescription { get; set; }

    public int targetCount { get; set; }

    public Skill(string name, string description, int targetCount)
    {
        skillName = name;
        skillDescription = description;

        this.targetCount = targetCount;

    }

    // 스킬을 실행하는 함수
    public void Use(Character user, List<Monster> monsters)
    {
        foreach (Monster target in monsters)
        {
            Console.WriteLine($"{target.name}에게 {skillName}을(를) 사용합니다.");
            Thread.Sleep(1000);
            Console.WriteLine($"{skillDescription}, {skillName}!");
            Thread.Sleep(1000);
        }
    }
}

// 스킬 목록을 관리하는 클래스
public class SkillManager
{
    private List<Skill> skills;

    public bool DisplaySkill(PlayerCharacter user, List<Monster> monsters)
    {
        int selectedSkillIndex = 0;  // 선택된 스킬 인덱스
        List<Skill> skills = user.skills;  // 캐릭터의 스킬 목록

        if (skills.Count == 0)
        {
            Console.WriteLine("사용 가능한 스킬이 없습니다.");
            return false;
        }

        Console.WriteLine("사용할 스킬을 선택하세요 (1번을 누르면 취소):");
        int topCursor = Console.CursorTop;

        // 스킬 목록을 처음 출력
        for (int i = 0; i < skills.Count; i++)
        {
            if (i == selectedSkillIndex)
            {
                Console.WriteLine($"* {skills[i].skillName}");
            }
            else
            {
                Console.WriteLine($"  {skills[i].skillName}");
            }
        }

        while (true)
        {
            Console.SetCursorPosition(0, topCursor + selectedSkillIndex);  // 커서를 현재 선택된 스킬로 이동
            Console.Write("*");  // 현재 선택된 스킬을 *로 표시

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            // 이전 선택을 지워주기
            Console.SetCursorPosition(0, topCursor + selectedSkillIndex);
            Console.Write(" ");  // 이전 선택된 스킬의 * 표시를 지움

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                if (selectedSkillIndex > 0)
                {
                    selectedSkillIndex--;
                }
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                if (selectedSkillIndex < skills.Count - 1)
                {
                    selectedSkillIndex++;
                }
            }
            else if (keyInfo.Key == ConsoleKey.Spacebar || keyInfo.Key == ConsoleKey.Enter)
            {
                Skill selectedSkill = skills[selectedSkillIndex];

                // 타겟 수만큼 몬스터 선택
                List<Monster> targets = PlayerAttackTargeting(user, monsters, selectedSkill.targetCount);

                if (targets.Count > 0)
                {
                    selectedSkill.Use(user, targets); // 함수 밖으로 나가면 좋을 것 같다
                }
                return true;
            }
            else if (keyInfo.KeyChar == '1')
            {
                Console.SetCursorPosition(0, topCursor + skills.Count);
                Console.WriteLine("스킬 선택을 취소했습니다.");
                return false;
            }
        }
    }

    private List<Monster> PlayerAttackTargeting(PlayerCharacter turnOwner, List<Monster> monsters, int targetCount)
    {
        Console.WriteLine("\n스킬을 사용할 대상을 선택하세요.");
        int minCursorTop = Console.CursorTop;
        int selectionResultTop = minCursorTop + monsters.Count + 2;  // 선택된 몬스터를 출력할 위치 설정
        List<Monster> targets = new List<Monster>();
        List<Monster> selectedTargets = new List<Monster>();

        // 살아있는 몬스터만 목록에 추가
        foreach (Monster monster in monsters)
        {
            if (!monster.isDead)
            {
                targets.Add(monster);
                Console.WriteLine($"- {monster.name}");
            }
        }

        int selectedTargetIndex = 0;
        while (selectedTargets.Count < targetCount)
        {
            Console.SetCursorPosition(0, minCursorTop + selectedTargetIndex);
            Console.Write("*");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Spacebar)
            {
                Monster attackTarget = targets[selectedTargetIndex];

                // 이미 선택한 대상이 아니면 추가
                if (!selectedTargets.Contains(attackTarget))
                {
                    selectedTargets.Add(attackTarget);
                    Console.SetCursorPosition(0, selectionResultTop + selectedTargets.Count - 1);  // 선택 결과 위치 설정
                    Console.WriteLine($"\n{attackTarget.name}을(를) 선택했습니다.");
                }

                if (selectedTargets.Count >= targetCount)
                {
                    break;  // 타겟 수만큼 선택했으면 종료
                }
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow && 0 < selectedTargetIndex)
            {
                Console.SetCursorPosition(0, minCursorTop + selectedTargetIndex);
                Console.Write("-");
                selectedTargetIndex--;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow && selectedTargetIndex < targets.Count - 1)
            {
                Console.SetCursorPosition(0, minCursorTop + selectedTargetIndex);
                Console.Write("-");
                selectedTargetIndex++;
            }
        }
        return selectedTargets;  // 여러 Monster 반환
    }
}