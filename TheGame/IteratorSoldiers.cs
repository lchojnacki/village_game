using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    class IteratorSoldiers
    {
        List<Human> list;
        int currentIndex;

        public IteratorSoldiers(List<Human> iterable_list)
        {
            list = iterable_list;
            First();
        }

        public void First()
        {
            currentIndex = 0;
            if (list[currentIndex].GetType() != new Soldier().GetType())
            {
                while(list[currentIndex].GetType() != new Soldier().GetType())
                {
                    Next();
                }
            }
        }

        public void Next()
        {
            currentIndex++;
            if (!IsDone())
            {
                if (list[currentIndex].GetType() != new Soldier().GetType())
                {
                    Next();
                }
            }
        }

        public bool IsDone()
        {
            return currentIndex >= list.Count;
        }

        public Soldier CurrentItem()
        {
            return (Soldier)list[currentIndex];
        }
    }
}
