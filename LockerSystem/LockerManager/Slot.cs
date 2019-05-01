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
        public Box Box { get => box; set => box = value; }
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
    }
}