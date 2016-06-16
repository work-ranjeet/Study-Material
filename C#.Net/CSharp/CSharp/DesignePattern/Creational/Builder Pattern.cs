using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.DesignePattern.Creational
{

    public enum ComputerType
    {
        Laptop,
        Desktop,
        Apple
    }
    public class Computer
    {
        private ComputerType _computerTyp;

        public string MotherBoard { get; set; }
        public string Processor { get; set; }
        public string HardDisk { get; set; }
        public string Screen { get; set; }

        public Computer(ComputerType computerTyp)
        {
            _computerTyp = computerTyp;
        }

        public void DisplayConfiguration()
        {
            string message;

            message = string.Format("Computer: {0}", _computerTyp);
            Console.WriteLine(message);

            message = string.Format("Motherboard: {0}", MotherBoard);
            Console.WriteLine(message);

            message = string.Format("Processor: {0}", Processor);
            Console.WriteLine(message);

            message = string.Format("Hard disk: {0}", HardDisk);
            Console.WriteLine(message);

            message = string.Format("Screen: {0}", Screen);
            Console.WriteLine(message);

            Console.WriteLine();
        }
    }

    public abstract class ComputerBuilder
    {
        public Computer Computer { get; set; }
        public string BrandName 
        { 
            get 
            { 
                return "IBM"; 
            } 
        }
        public abstract void BuildMotherboard();
        public abstract void BuildProcessor();
        public abstract void BuildHardDisk();
        public abstract void BuildScreen();
    }

    public class LaptopBuilder : ComputerBuilder
    {
        public LaptopBuilder()
        {
            Computer = new Computer(ComputerType.Laptop);
        }        

        public override void BuildMotherboard()
        {
            Computer.MotherBoard = "DELL MotherBoard";
        }

        public override void BuildProcessor()
        {
            Computer.Processor = "Intel Core 2 Duo";
        }

        public override void BuildHardDisk()
        {
            Computer.HardDisk = "250GB";
        }

        public override void BuildScreen()
        {
            Computer.Screen = "15.4-inch (1280 x 800)";
        }
    }

    public class DesktopBuilder : ComputerBuilder
    {
        public DesktopBuilder()
        {
            Computer = new Computer(ComputerType.Desktop);
        }

        public override void BuildMotherboard()
        {
            Computer.MotherBoard = "Asus P6X58D Premium";
        }

        public override void BuildProcessor()
        {
            Computer.Processor = "Intel Xeon 7500";
        }

        public override void BuildHardDisk()
        {
            Computer.HardDisk = "2TB";
        }

        public override void BuildScreen()
        {
            Computer.Screen = "21 inch (1980 x 1200)";
        }
    }

    public class AppleBuilder : ComputerBuilder
    {
        public AppleBuilder()
        {
            Computer = new Computer(ComputerType.Apple);
        }

        public override void BuildMotherboard()
        {
            Computer.MotherBoard = "iMac G5 PowerPC";
        }

        public override void BuildProcessor()
        {
            Computer.Processor = "Intel Core 2 Duo";
        }

        public override void BuildHardDisk()
        {
            Computer.HardDisk = "320GB";
        }

        public override void BuildScreen()
        {
            Computer.Screen = "24 inch (1980 x 1200)";
        }
    }


    public class ComputerShop
    {
        public void ConstructComputer(ComputerBuilder computerBuilder)
        {
            Console.WriteLine(computerBuilder.BrandName);

            computerBuilder.BuildMotherboard();
            computerBuilder.BuildProcessor();
            computerBuilder.BuildHardDisk();
            computerBuilder.BuildScreen();            
        }
    }

    public class Builder
    {
        private static void BuildComputer()
        {
            ComputerShop computerShop = new ComputerShop();
            ComputerBuilder computerBuilder;

            computerBuilder = new LaptopBuilder();
            computerShop.ConstructComputer(computerBuilder);
            computerBuilder.Computer.DisplayConfiguration();

            computerBuilder = new DesktopBuilder();
            computerShop.ConstructComputer(computerBuilder);
            computerBuilder.Computer.DisplayConfiguration();

            computerBuilder = new AppleBuilder();
            computerShop.ConstructComputer(computerBuilder);
            computerBuilder.Computer.DisplayConfiguration();
            Console.ReadKey();
        }
    }
}
