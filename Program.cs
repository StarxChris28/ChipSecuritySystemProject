using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ChipSecuritySystem
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Please select which bag of chips you would like (Bag1, Bag2 or Bag3): ");
            var input = Console.ReadLine();

            
            List<ColorChip> chipBag1 = new List<ColorChip>() {
                { new ColorChip(Color.Blue, Color.Yellow) },
                { new ColorChip(Color.Red, Color.Green) },
                { new ColorChip(Color.Orange, Color.Purple) },
                { new ColorChip(Color.Yellow, Color.Red) }
            };

            List<ColorChip> chipBag2 = new List<ColorChip>() {
                { new ColorChip(Color.Blue, Color.Yellow) },
                { new ColorChip(Color.Yellow, Color.Red) },
                { new ColorChip(Color.Orange, Color.Purple) },
                { new ColorChip(Color.Yellow, Color.Red) },
                { new ColorChip(Color.Orange, Color.Purple) }

            };

            List<ColorChip> chipBag3 = new List<ColorChip>() {
                { new ColorChip(Color.Yellow, Color.Red) },
                { new ColorChip(Color.Orange, Color.Purple) },
                { new ColorChip(Color.Red, Color.Green) },
                { new ColorChip(Color.Orange, Color.Purple) },
                { new ColorChip(Color.Blue, Color.Yellow) },
                { new ColorChip(Color.Yellow, Color.Red) },
                { new ColorChip(Color.Orange, Color.Purple) },
                { new ColorChip(Color.Yellow, Color.Red) },
                { new ColorChip(Color.Orange, Color.Purple) }

            };
            List<ColorChip> chipBagSelected = new List<ColorChip>();

            switch (input.ToLower())
            {

                case "bag1":
                    chipBagSelected = chipBag1;
                    break;

                case "bag2":
                    chipBagSelected = chipBag2;
                    break;

                case "bag3":
                    chipBagSelected = chipBag3;
                    break;

                default:
                    chipBagSelected = chipBag1;
                    break;

            }
            ColorChip placeholder = new ColorChip(Color.Blue, Color.Yellow);

            bool greenFound = false;
            bool bluefound = false;

            for (int i = 0; i< chipBagSelected.Count(); i++)
            {
                if(chipBagSelected[i].StartColor == Color.Blue && i == 0 && !bluefound)
                {
                    bluefound = true;
                    continue;
                }
                if(chipBagSelected[i].EndColor == Color.Green &&  i == chipBagSelected.Count()-1 && !greenFound)
                {
                    greenFound = true;
                    continue;
                }

                if (chipBagSelected[i].StartColor == Color.Blue && i != 0 && !bluefound)
                {
                    placeholder = chipBagSelected[i];
                    chipBagSelected.RemoveAt(i);
                    chipBagSelected.Insert(0, placeholder);
                    bluefound = true;
                    continue;
                }

                if (chipBagSelected[i].EndColor == Color.Green && i != chipBagSelected.Count() - 1 && !greenFound)
                {
                    placeholder = chipBagSelected[i];
                    chipBagSelected.RemoveAt(i);
                    chipBagSelected.Insert(chipBagSelected.Count(), placeholder);
                    greenFound = true;
                    continue;
                }
                
            }
            Console.Write("Blue ");
            foreach (ColorChip chip in chipBagSelected)
            {
                Console.Write("["+ chip.ToString() + "] ");
            }

            Console.WriteLine("Green");
            if (greenFound && bluefound)
            {
                Console.WriteLine("Channel is succesfully connected");
            }
            else
            {
                Console.WriteLine("Channel is not successfully connected");
            }
            Console.ReadKey();

        }
    }
}
