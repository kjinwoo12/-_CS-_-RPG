using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


internal class HireMercenariesScene : IScene
{
    int minMercenaryCursorTop;
    int minMyMercenaryCursorTop;
    int alertCursorBelowMyMercenary;
    int alertCursorTop;
    int selectedMercenaryIndex;
    int selectedMyMercenaryIndex;
    IScene nextScene;

    public HireMercenariesScene()
    {
        selectedMercenaryIndex = 0;
        selectedMyMercenaryIndex = 0;
    }

    public void OnShow()
    {
        Console.WriteLine("고용중인 용병 ");
        ShowMyMercenaries();
        Console.WriteLine();

        alertCursorBelowMyMercenary = Console.CursorTop;

        ShowGold();

        Console.WriteLine("용병 목록\n");
        ShowMercenaries();

        Console.WriteLine("\n여관으로 돌아가려면 [1]을 눌러주세요.");
        Console.WriteLine("아이템을 선택하려면 방향키[↑,↓]를 입력해주세요.");
        Console.WriteLine("용병을 고용하려면 용병 고용 목록에서[space]를 눌러주세요.");
        alertCursorTop = Console.CursorTop + 1;

        ShowCursorInput();
    }

    public IScene GetNextScene()
    {
        return nextScene;
    }

    void ShowGold()
    {
        PlayerState playerState = GameManager.instance.playerState;
        Console.WriteLine("[보유 골드]");
        Console.WriteLine($"{playerState.gold} G");
    }

    void ShowMyMercenaries()
    {
        Console.WriteLine("[고용한 용병 목록]");

        SortedDictionary<int, Mercenary> mercenarySlot = GameManager.instance.mercenarySlot;

        minMyMercenaryCursorTop = Console.CursorTop;
        foreach (KeyValuePair<int, Mercenary> mercenary in mercenarySlot)
        {
            Console.WriteLine($"- {mercenary.Key} : {mercenary.Value.name}\t| Lv : {mercenary.Value.level} | 직업 : {mercenary.Value.jobName}\t| {mercenary.Value.description} |");
            Console.Write($"|체력 :  {mercenary.Value.stats.maxHealth}\t");
            Console.Write($"|공격력 : {mercenary.Value.stats.minAttack}~{mercenary.Value.stats.maxAttack}\t");
            Console.Write($"|방어력 : {mercenary.Value.stats.minArmor}~{mercenary.Value.stats.maxArmor}\t");
            Console.Write($"|민첩 : {mercenary.Value.stats.minAgility}~{mercenary.Value.stats.maxAgility}\t");
            Console.WriteLine($"|치명타율 : {mercenary.Value.stats.criticalRate}\t|");
            Console.WriteLine();
        }
    }

    void ShowMercenaries()
    {
        Console.WriteLine("[고용가능한 용병 목록]");

        List<Mercenary> Mercenaries = MercenaryManager.instance.Mercenaries;

        minMercenaryCursorTop = Console.CursorTop;
        foreach (Mercenary mercenary in Mercenaries)
        {
            Console.WriteLine($"- {mercenary.name}\t| Lv : {mercenary.level} | 직업 : {mercenary.jobName}\t| {mercenary.description} |");
            Console.Write($"|체력 : {mercenary.stats.maxHealth}\t");
            Console.Write($"|공격력 : {mercenary.stats.minAttack}~{mercenary.stats.maxAttack}\t");
            Console.Write($"|방어력 : {mercenary.stats.minArmor}~{mercenary.stats.maxArmor}\t");
            Console.Write($"|민첩 : {mercenary.stats.minAgility}~{mercenary.stats.maxAgility}\t");
            Console.Write($"|치명타율 : {mercenary.stats.criticalRate}\t");
            Console.WriteLine($"|가격 : {mercenary.price}\t|");
            Console.WriteLine();
        }
    }

    void ShowCursorInput()
    {
        PlayerState playerState = GameManager.instance.playerState;
        List<Mercenary> Mercenaries = MercenaryManager.instance.Mercenaries;
        while (true)
        {
            if (Mercenaries.Count <= selectedMercenaryIndex)
            {
                selectedMercenaryIndex = Mercenaries.Count - 1;
            }

            if (Mercenaries.Count > 0)
            {
                Console.SetCursorPosition(0, minMercenaryCursorTop + selectedMercenaryIndex * 3);
                Console.Write("*");
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                if (selectedMercenaryIndex <= 0)
                {
                    continue;
                }

                Console.SetCursorPosition(0, minMercenaryCursorTop + selectedMercenaryIndex  * 3);
                Console.Write("-");
                selectedMercenaryIndex -= 1;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                if (Mercenaries.Count - 1 <= selectedMercenaryIndex)
                {
                    continue;
                }

                Console.SetCursorPosition(0, minMercenaryCursorTop + selectedMercenaryIndex * 3);
                Console.Write("-");
                selectedMercenaryIndex += 1;
            }
            else if (keyInfo.Key == ConsoleKey.Spacebar)
            {
                Mercenary additonalMercenary = Mercenaries[selectedMercenaryIndex];

                if (playerState.gold < additonalMercenary.price)
                {
                    Console.SetCursorPosition(0, alertCursorTop);
                    Console.WriteLine("골드가 부족합니다.");
                    Thread.Sleep(500);
                }
                else
                {
                    Console.SetCursorPosition(0, alertCursorBelowMyMercenary);
                    Console.WriteLine("고용할 용병의 슬롯을 선택하세요");
                    Console.WriteLine("[고용가능한 용병 목록]으로 돌아가려면 [1]을 눌러주세요.");
                    Console.WriteLine("용병을 저장할 목록에서[space]를 눌러주세요.");
                    Console.WriteLine("이미 용병이 존재한다면 덮어쓰기가 가능합니다.");
                    Console.WriteLine();
                    ShowCursorInputInMyMercenary(additonalMercenary, playerState);
                }
                nextScene = new HireMercenariesScene();
                break;
            }
            else if (keyInfo.KeyChar == '1')
            {
                nextScene = new HotelScene();
                break;
            }
        }
    }

    void ShowCursorInputInMyMercenary(Mercenary additonalMercenary, PlayerState playerState)
    {
        SortedDictionary<int, Mercenary> mercenarySlot = GameManager.instance.mercenarySlot;
        while (true)
        {
            if (3 <= selectedMyMercenaryIndex)
            {
                selectedMyMercenaryIndex = 2;
            }

            Console.SetCursorPosition(0, minMyMercenaryCursorTop + selectedMyMercenaryIndex * 3);
            Console.Write("*");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                if (selectedMyMercenaryIndex <= 0)
                {
                    continue;
                }

                Console.SetCursorPosition(0, minMyMercenaryCursorTop + selectedMyMercenaryIndex * 3);
                Console.Write("-");
                selectedMyMercenaryIndex -= 1;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                if (3 <= selectedMyMercenaryIndex)
                {
                    continue;
                }

                Console.SetCursorPosition(0, minMyMercenaryCursorTop + selectedMyMercenaryIndex * 3);
                Console.Write("-");
                selectedMyMercenaryIndex += 1;
            }
            else if (keyInfo.Key == ConsoleKey.Spacebar)
            {
                Console.WriteLine("구매 완료");
                mercenarySlot[selectedMyMercenaryIndex] = additonalMercenary;
                playerState.gold -= additonalMercenary.price;
                Thread.Sleep(100);

                nextScene = new HireMercenariesScene();
                break;
            }
            else if (keyInfo.KeyChar == '1')
            {
                nextScene = new HireMercenariesScene();
                break;
            }
        }
    }
}
