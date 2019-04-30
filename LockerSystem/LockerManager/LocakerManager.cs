using System;
using System.Collections.Generic;

namespace Locker
{
    public class LockerManager
    {
        private int noLockers;
        private string id;
        private Queue<Slot> smallSlotsAvailable;
        private Queue<Slot> mediumSlotsAvailable;

        public int NumberOfLockers { get => noLockers; }

        public string ID { get => id; }

        public LockerManager()
        {
            noLockers = noLockers == 0 ? 4 : noLockers;
            this.id = Util.CreateUniqueID();
            smallSlotsAvailable = new Queue<Slot>();
            mediumSlotsAvailable = new Queue<Slot>();

            CreateSlots(Size.Small);
        }

        public LockerManager(int noLockers) : this()
        {
            if (noLockers <= 0)
                throw new Exception($"Invalid number of lockers {noLockers}");

            if (noLockers % 4 > 0)
                throw new Exception($"Number of Lockers Should be multiples of 4");

            this.noLockers = noLockers;
        }

        private void CreateSlots(Size size)
        {
            for (int i = 0; i < this.noLockers / 4; i++)
            {
                Slot slot = new Slot(size);

                i
            }
        }
    }
}
