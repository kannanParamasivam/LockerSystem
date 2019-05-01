using System;
namespace Locker
{
    public class Slot
    {
        private Size size;
        private string id;
        private Box box = null;

        public Size Size { get => size; }
        public string ID { get => id; }
        public Box Box { get => box; }
        public bool IsEmpty { get => box == null; }

        public Slot()
        {
            this.id = Util.CreateUniqueID();
        }

        public Slot(Size size) : this()
        {
            this.size = size;
        }

        public Box EmptyTheSlot()
        {
            if (this.IsEmpty)
                throw new Exception("Slot Is Empty");

            Box tempBox = this.box;
            this.box = null;
            return tempBox;
        }

        public void PlaceBox(Box box)
        {
            if (box == null)
                throw new Exception("Box is not valid");

            if (!this.IsEmpty)
                throw new Exception("Slot is occupied");

            this.box = box;
        }
    }
}