namespace Ex3_Builder
{
    public class Computer
    {
        public string CPU { get; private set; }
        public string RAM { get; private set; }
        public string? Storage { get; private set; }
        public string? GPU { get; private set; }

        private Computer(ComputerBuilder builder)
        {
            CPU = builder.CPU;
            RAM = builder.RAM;
            Storage = builder.Storage;
            GPU = builder.GPU;
        }

        public override string ToString()
        {
            return $"Computer Config: CPU={CPU}, RAM={RAM}, Storage={Storage}, GPU={GPU ?? "Integrated"}";
        }

        public class ComputerBuilder
        {
            public string CPU { get; private set; }
            public string RAM { get; private set; }
            public string? Storage { get; private set; }
            public string? GPU { get; private set; }

            public ComputerBuilder(string cpu, string ram)
            {
                CPU = cpu;
                RAM = ram;
            }

            public ComputerBuilder SetStorage(string storage)
            {
                Storage = storage;
                return this;
            }

            public ComputerBuilder SetGPU(string gpu)
            {
                GPU = gpu;
                return this;
            }

            public Computer Build()
            {
                return new Computer(this);
            }
        }
    }
}
