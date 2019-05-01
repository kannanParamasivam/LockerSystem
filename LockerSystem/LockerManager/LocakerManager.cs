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
        Dictionary<int, Queue<Slot>> availableSlotsBuckets;
        Dictionary<string, Slot> slotsWithBox;

        public int NumberOfLockers => noLockers;

        public int SlotsAvailable => smallSlotsAvailable.Count + mediumSlotsAvailable.Count + largeSlotsAvailable.Count + extraLargeSlotsAvailable.Count;

        public string ID => id;

        public int SlotsOccupied => slotsWithBox.Count;

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
            availableSlotsBuckets = new Dictionary<int, Queue<Slot>>
            {
                { 0, smallSlotsAvailable },
                { 1, mediumSlotsAvailable },
                { 2, largeSlotsAvailable },
                { 3, extraLargeSlotsAvailable }
            };
            slotsWithBox = new Dictionary<string, Slot>();
            CreateSlots();
        }

        private void CreateSlots()
        {
            foreach (int value in Enum.GetValues(typeof(Size)))
            {
                for (int i = 0; i < this.noLockers / 4; i++)
                {
                    Slot slot = new Slot((Size)value);
                    availableSlotsBuckets[value].Enqueue(slot);
                }
            }
        }

        public void PlaceBox(Box box) {
            if (box == null)
                throw new Exception("Box is not valid");

            if (this.SlotsAvailable == 0)
                throw new Exception("No slots available");

            int sizeBucket = (int)box.Size;

            while (sizeBucket < availableSlotsBuckets.Count)
            {
                if (availableSlotsBuckets[sizeBucket].Count > 0)
                {
                    Slot slot = availableSlotsBuckets[sizeBucket].Dequeue();
                    slot.PlaceBox(box);
                    slotsWithBox.Add(box.ID, slot);
                    return;
                }

                sizeBucket++;
            }

            throw new Exception("No slots available");
        }

        public Box PickUpBox(string boxId)
        {
            if (String.IsNullOrWhiteSpace(boxId))
                throw new Exception("Box number is not valid");

            if (this.SlotsOccupied == 0 || !this.slotsWithBox.ContainsKey(boxId))
                throw new Exception("Box is not available");

            Slot slot = slotsWithBox[boxId];
            slotsWithBox.Remove(boxId);
            Box box = slot.EmptyTheSlot();
            availableSlotsBuckets[(int)slot.Size].Enqueue(slot);
            return box;
        }

    }
}
