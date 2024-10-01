using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class MercenaryManager
{
    private static readonly Lazy<MercenaryManager> lazy = new Lazy<MercenaryManager>(() => new MercenaryManager());
    public static MercenaryManager instance { get { return lazy.Value; } }

    public List<Mercenary> Mercenaries { get; }

    private MercenaryManager()
    {
        Mercenaries = new List<Mercenary>();

        Mercenaries.Add(new SkilledArcher());
        Mercenaries.Add(new SkilledMagician());
        Mercenaries.Add(new SkilledMonk());
        Mercenaries.Add(new SkilledThief());
        Mercenaries.Add(new SkilledWarrior());

    }
}
