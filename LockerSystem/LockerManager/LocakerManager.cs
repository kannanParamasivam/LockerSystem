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
        private Queue<Slot> largeSlotsAvailable;
        private Queue<Slot> extraLargeSlotsAvailable;
        Dictionary<int, Queue<Slot>> availableSlots;

        public int NumberOfLockers => noLockers;

        public int LockersAvailable => smallSlotsAvailable.Count + mediumSlotsAvailable.Count + largeSlotsAvailable.Count + extraLargeSlotsAvailable.Count;

        public string ID => id;

        public LockerManager() : this(4)
        {

        }

        public LockerManager(int noLockers)
        {
            if (noLockers <= 0)
                throw new Exception($"Invalid number of lockers {noLockers}");

            if (noLockers % 4 > 0)
                throw new Exception($"Number of Lockers Should be multiples of 4");

            this.noLockers = noLockers;
            this.id = Util.CreateUniqueID();
            smallSlotsAvailable = new Queue<Slot>();
            mediumSlotsAvailable = new Queue<Slot>();
            largeSlotsAvailable = new Queue<Slot>();
            extraLargeSlotsAvailable = new Queue<Slot>();
            availableSlots = new Dictionary<int, Queue<Slot>>
            {
                { 0, smallSlotsAvailable },
                { 1, mediumSlotsAvailable },
                { 2, largeSlotsAvailable },
                { 3, extraLargeSlotsAvailable }
            };
            CreateSlots();
        }

        private void CreateSlots()
        {
            foreach (int value in Enum.GetValues(typeof(Size)))
            {
                for (int i = 0; i < this.noLockers / 4; i++)
                {
                    Slot slot = new Slot((Size)value);
                    availableSlots[value].Enqueue(slot);

                }
            }

        }
    }
}
